using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using YandexDiskSync.Forms;
using YandexDiskSync.Types;

namespace YandexDiskSync
{
  public class DatabaseVersion
  {
    public string Database;
    public string Name;
    public string Path;
    public string SHA256;
    public UInt64 Size;
    public DatabaseVersion(Database database, ResourceResponse item)
    {
      Database = database.Name;
      Name = item.modified.ToString("s").Replace("T", " ");
      Path = item.path;
      SHA256 = item.sha256;
      Size = item.size;
    }
  }
  public class Database
  {
    public string Name;
    public string Path;

    public Database(ResourceResponse item)
    {
      Name = item.name;
      Path = item.path;
    }
  }

  public class ApiUI
  {
    private Api Api;
    private Config Config;

    public ApiUI(Config config)
      : this(new Api(), config)
    {
    }
    public ApiUI(Api api, Config config)
    {
      Config = config;
      Api = api;
      Api.SetAuthorization(config.OAuthToken);
    }

    private T OnError<T>(Exception e)
    {
      if (e is HttpException)
      {
        var httpException = e as HttpException;
        if (httpException.ErrorCode == 401)
        {
          Auth.Authenticate(Config, Api);
        }
      }
      throw e;
    }

    private T Retry<T>(Func<T> asyncTask, int retryCount = 3)
    {
      return Async.Retry<T>(asyncTask, OnError<T>, retryCount);
    }

    public IEnumerable<Database> GetDatabases()
    {
      return Retry(() =>
      {
        var files = Api.GetFileInfo(Api.APP_PATH);
        return files._embedded.items
        .Where(item => item.type == Api.TYPE_DIR)
        .OrderByDescending(item => item.modified)
        .Select(item => new Database(item));
      });
    }

    public IEnumerable<DatabaseVersion> GetDatabaseVersions(Database database)
    {
      return Retry(() =>
      {
        var versions = Api.GetFileInfo(database.Path);
        return versions._embedded.items
        .Where(item => item.type == Api.TYPE_FILE)
        .OrderByDescending(item => item.created)
        .Select(item => new DatabaseVersion(database, item));
      });
    }

    public bool IsDatabaseSame(string filename)
    {
      var databaseName = Path.GetFileNameWithoutExtension(filename);
      var extension = Path.GetExtension(filename);
      var folderPath = string.Format("{0}{1}", Api.APP_PATH, databaseName);
      var currentVersion = string.Format("{0}/current{1}", folderPath, extension);

      return Retry(() => {
        var remoteFile = Api.GetFileInfo(currentVersion);
        if (remoteFile != null)
        {
          var file = new FileInfo(filename);
          if (file.Exists)
          {
            return remoteFile.md5 == file.MD5();
          }
        }
        return false;
      });
    }

    public ResourceResponse UploadDatabase(string filename, bool withBackup = true)
    {
      return Retry(() =>
      {
        var database = Path.GetFileNameWithoutExtension(filename);
        var extension = Path.GetExtension(filename);
        var folderPath = string.Format("{0}{1}", Api.APP_PATH, database);
        var folder = Api.CreateFolder(folderPath);
        var currentVersion = string.Format("{0}/current{1}", folder.path, extension);
        if (withBackup)
        {
          var backupFile = Api.GetFileInfo(currentVersion);
          if (backupFile != null)
          {
            var backupVersion = string.Format("{0}/{1}{2}", folder.path, backupFile.md5, extension);
            Api.CopyFile(currentVersion, backupVersion, true);
          }
        }
        return Api.UploadFile(filename, currentVersion);
      });
    }

    public FileInfo DownloadDatabase(DatabaseVersion databaseVersion, string filename)
    {
      return Retry(() =>
      {
        return Api.DownloadFile(databaseVersion.Path, filename);
      });
    }
    public FileInfo DownloadDatabase(string filename, string targetFile, string version = "current")
    {
      return Retry(() =>
      {
        var databaseName = Path.GetFileNameWithoutExtension(filename);
        var extension = Path.GetExtension(filename);
        var downloadVersion = string.Format("{0}{1}/{2}{3}", Api.APP_PATH, databaseName, version, extension);

        return Api.DownloadFile(downloadVersion, targetFile);
      });
    }

    public int CompactDatabase(string filename)
    {
      var database = Path.GetFileNameWithoutExtension(filename);
      var folderPath = string.Format("{0}{1}", Api.APP_PATH, database);
      var now = DateTime.Now;
      var compactDays = 30;

      return Retry(() =>
      {
        Api.DeleteFilesByFilter(folderPath, (response, id) =>
        {
          var span = now.Subtract(response.modified);
          return Math.Abs(span.TotalDays) > compactDays;
        });

        return 0;
      });
    }
  }
}
