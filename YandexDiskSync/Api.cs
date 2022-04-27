using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using YandexDiskSync.Types;

namespace YandexDiskSync
{
  public class Api : RestClient
  {
    public const string APP_PATH = "app:/";
    public const string TYPE_FILE = "file";
    public const string TYPE_DIR = "dir";

    public const string AuthorizeUrl = @"https://oauth.yandex.ru/authorize?response_type=code&client_id=" + Credentials.Id;

    public Api()
      : base(@"https://cloud-api.yandex.net/v1/")
    {
    }

    public AuthResponse Authorize(string code)
    {
      var data = new AuthRequest
      {
        grant_type = "authorization_code",
        code = code,
        client_id = Credentials.Id,
        client_secret = Credentials.Secret
      };
      try
      {
        var auth = Request<AuthResponse>(@"https://oauth.yandex.ru/token", HttpMethod.Post, null, data);
        SetAuthorization(string.Format("OAuth {0}", auth.access_token));
        return auth;
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
        throw e;
      }
    }
    public DiskResponse GetDiskInfo()
    {
      return Resource<DiskResponse>("disk");
    }

    public ResourceResponse GetFileInfo(string drivepath)
    {
      return Resource<ResourceResponse>("disk/resources", null, new Params { { "path", drivepath } });
    }

    public ResourceListResponse GetFilesInfo(int offset, int limit)
    {
      return Resource<ResourceListResponse>("disk/resources/files", null, new Params { { "offset", offset.ToString() }, { "limit", limit.ToString() } });
    }
    public ResourceListResponse GetFilesInfo(int offset)
    {
      return GetFilesInfo(offset, 20);
    }
    public ResourceResponse CreateFolder(string drivepath)
    {
      try
      {
        Resource<LinkResponse>("disk/resources", HttpMethod.Put, new Params { { "path", drivepath } });
      }
      catch
      {
        // folder exists
      }
      return GetFileInfo(drivepath);
    }
    public LinkResponse CopyFile(string fromDrivepath, string toDrivepath, bool overwrite)
    {
      return Resource<LinkResponse>("disk/resources/copy", HttpMethod.Post, new Params { { "path", toDrivepath }, { "from", fromDrivepath }, { "overwrite", overwrite.ToString() } });
    }
    public LinkResponse CopyFile(string fromDrivepath, string toDrivepath)
    {
      return CopyFile(fromDrivepath, toDrivepath, false);
    }
    public LinkResponse MoveFile(string fromDrivepath, string toDrivepath, bool overwrite)
    {
      return Resource<LinkResponse>("disk/resources/move", HttpMethod.Post, new Params { { "path", toDrivepath }, { "from", fromDrivepath }, { "overwrite", overwrite.ToString() } });
    }
    public LinkResponse MoveFile(string fromDrivepath, string toDrivepath)
    {
      return MoveFile(fromDrivepath, toDrivepath, false);
    }
    public LinkResponse DeleteFile(string drivepath, bool permanently)
    {
      return Resource<LinkResponse>("disk/resources", HttpMethod.Delete, new Params { { "path", drivepath }, { "permanently", permanently.ToString() } });
    }
    public LinkResponse DeleteFile(string drivepath)
    {
      return DeleteFile(drivepath, false);
    }
    public LinkResponse GetDownloadLink(string drivepath)
    {
      return Resource<LinkResponse>("disk/resources/download", null, new Params { { "path", drivepath } });
    }

    public FileInfo DownloadFile(string drivepath, string filename)
    {
      var link = GetDownloadLink(drivepath);
      if (link != null)
      {
        return DownloadFileFromUrl(link.href, filename);
      }
      return null;
    }

    public LinkResponse GetUploadLink(string drivepath)
    {
      return Resource<LinkResponse>("disk/resources/upload", null, new Params { { "path", drivepath }, { "overwrite", "true" } });
    }

    public ResourceResponse UploadFile(string filepath, string drivepath)
    {
      var link = GetUploadLink(drivepath);
      if (link != null)
      {
        UploadFileToUrl(filepath, link.href, link.method);
      }
      return GetFileInfo(drivepath);
    }

    public int DeleteFilesByFilter(string path, Func<ResourceResponse, int, bool> filter)
    {
      var folder = GetFileInfo(path);
      var toDelete = folder._embedded.items.Where(filter);

      return toDelete.Select(file => DeleteFile(file.path)).Count();
    }


    public bool IsAuthenticated()
    {
      try
      {
        Resource<DiskResponse>("disk");
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }

  }
}
