using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YandexDiskSync
{
  public partial class DatabaseList : Form
  {
    private ApiUI _api;
    protected FileInfo File = null;

    public static FileInfo DownloadDatabase(ApiUI api)
    {
      var authForm = new DatabaseList(api);
      authForm.ShowDialog();

      return authForm.File;
    }

    protected DatabaseList(ApiUI api)
    {
      _api = api;
      InitializeComponent();
    }
    private string SelectFile(string defaultName = "")
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();

      saveFileDialog.Filter = "Database files (*.kbdx)|*.kbdx|All files (*.*)|*.*";
      saveFileDialog.RestoreDirectory = true;
      saveFileDialog.FileName = defaultName;
      if (saveFileDialog.ShowDialog() == DialogResult.OK)
      {
        return saveFileDialog.FileName;
      }

      return null;
    }

    private void SetVersions(IEnumerable<DatabaseVersion> versions)
    {
      versionList.Items.Clear();
      foreach (var version in versions)
      {
        var item = new ListViewItem(version.Name)
        {
          Tag = version,
        };
        item.SubItems.Add(version.Size.AsSize());

        versionList.Items.Add(item);
      }
    }

    private void SetDatabases(IEnumerable<Database> databases)
    {
      datebaseList.Items.Clear();
      foreach (var database in databases)
      {
        var item = new ListViewItem(database.Name)
        {
          Tag = database,
        };

        datebaseList.Items.Add(item);
      }
    }

    private void DatabaseList_Load(object sender, EventArgs e)
    {
      datebaseList.Enabled = false;
      var databases = _api.GetDatabases();
      SetDatabases(databases);
      datebaseList.Enabled = true;
    }

    private void versionList_SelectedIndexChanged(object sender, EventArgs e)
    {
      download.Enabled = versionList.SelectedItems.Count > 0;
    }

    private void datebaseList_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (datebaseList.SelectedItems.Count > 0)
      {
        versionList.Enabled = false;
        var database = (Database)datebaseList.SelectedItems[0].Tag;
        var versions = _api.GetDatabaseVersions(database);
        SetVersions(versions);
        versionList.Enabled = true;
      }
    }

    private void download_Click(object sender, EventArgs e)
    {
      var version = (DatabaseVersion)versionList.SelectedItems[0].Tag;
      var filename = SelectFile(version.Database);
      if (!string.IsNullOrEmpty(filename))
      {
        File = _api.DownloadDatabase(version, filename);
        Close();
      }

    }
  }
}
