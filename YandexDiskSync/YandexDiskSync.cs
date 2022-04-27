using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using KeePass;
using KeePass.Ecas;
using KeePass.Forms;
using KeePass.Plugins;
using KeePass.UI;
using KeePassLib;
using KeePassLib.Serialization;
using YandexDiskSync.Forms;
using YandexDiskSync.Properties;
using YandexDiskSync.Types;
using System.Web;
using System.IO;

namespace YandexDiskSync
{
  public sealed partial class YandexDiskSyncExt : Plugin
  {
    public const string YandexDiskSyncName = "YandexDiskSync Settings";
    public readonly byte[] YandexDiskSyncUuid = {
                0xBC,0x30,0x12,0x6C,0xE3,0xE2,0xA7,0x4E,
                0xB4,0x15,0x21,0x01,0x88,0x84,0xB0,0x7C
                                                };

    private IPluginHost _host;
    public override string UpdateUrl
    {
      get { return @"https://raw.githubusercontent.com/3axap4eHko/YandexDiskSync/master/version_manifest.txt"; }
    }


    private Config Config;
    private ApiUI Api;

    public override bool Initialize(IPluginHost host)
    {
      var optionsMenu = new ToolStripMenuItem("&YandexDiskSync Settings ...");
      optionsMenu.Click += DisplayOptions;
      optionsMenu.Image = Resources.disk_image;

      var openDb = new ToolStripMenuItem("Open &Yandex.Disk ...");
      openDb.Click += DownloadDatabase;
      openDb.Image = Resources.disk_image;
      openDb.ShortcutKeys = Keys.Control | Keys.Shift | Keys.Y;

      _host = host;
      _host.MainWindow.ToolsMenu.DropDownItems.Add(optionsMenu);
      var openFile = _host.MainWindow.MainMenu.Items.Find("m_menuFileOpen", true).FirstOrDefault() as ToolStripMenuItem;
      if (openFile != null)
      {
        openFile.DropDownItems.Add(openDb);
      }

      _host.MainWindow.FileOpened += OnOpenDatabase;
      _host.MainWindow.FileSaved += OnSaveDatabase;

      Config = new Config(_host.CustomConfig);
      Api = new ApiUI(Config);

      return true;
    }

    void DisplayOptions(object sender, EventArgs e)
    {
      var optionsForm = new Options(Config);
      optionsForm.ShowDialog();

    }

    void Syncronize(PwDatabase database)
    {
      try
      {
        var filename = database.IOConnectionInfo.Path;
        var isSame = Api.IsDatabaseSame(filename);
        if (!isSame)
        {
          var tempFilename = Path.GetTempPath() + String.Concat(Guid.NewGuid().ToString(), ".temp");
          var tempFile = Api.DownloadDatabase(filename, tempFilename);
          if (tempFile != null)
          {
            var serialinfo = new IOConnectionInfo { Path = tempFile.FullName };
            var db = new PwDatabase();
            var log = new Log();
            db.Open(serialinfo, database.MasterKey, log);
            database.MergeIn(db, PwMergeMethod.Synchronize);
            db.Close();
            tempFile.Delete();
          }
          Api.UploadDatabase(filename);
          Api.CompactDatabase(filename);
        }
      }
      catch (Exception ex)
      {
        ShowNotification(ex.Message);
      }

    }
    void DownloadDatabase(object sender, EventArgs e)
    {
      try
      {
        var file = DatabaseList.DownloadDatabase(Api);
        if (file != null)
        {
          var ioConnection = IOConnectionInfo.FromPath(file.FullName);
          _host.MainWindow.OpenDatabase(ioConnection, null, false);
        }
      }
      catch (Exception ex)
      {
        ShowNotification(ex.Message);
      }
    }

    async void OnOpenDatabase(object sender, FileOpenedEventArgs e)
    {
      await Task.Run(() => Syncronize(e.Database));
    }

    async void OnSaveDatabase(object sender, FileSavedEventArgs e)
    {
      await Task.Run(() => Syncronize(e.Database));
    }

  }
}
