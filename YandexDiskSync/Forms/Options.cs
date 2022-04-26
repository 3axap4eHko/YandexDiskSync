using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeePass.App.Configuration;
using YandexDiskSync.Types;

namespace YandexDiskSync.Forms
{
  public partial class Options : Form
  {
    public Options(Config config)
    {
      InitializeComponent();

      limitHistory.Checked = config.LimitHistory;
      limitHistorySize.Enabled = config.LimitHistory;
      limitHistorySize.Value = config.LimitHistorySize;

      openSync.Checked = config.SyncOnOpen;
      saveSync.Checked = config.SyncOnSave;
      closeSync.Checked = config.SyncOnClose;

      limitHistory.CheckedChanged += (sender, e) =>
      {
        config.LimitHistorySize = (ulong)limitHistorySize.Value;
        limitHistorySize.Enabled = limitHistory.Checked;
      };
      limitHistorySize.ValueChanged += (sender, e) =>
      {
        config.LimitHistorySize = (ulong)limitHistorySize.Value;
      };
      openSync.CheckedChanged += (sender, e) =>
      {
        config.SyncOnOpen = openSync.Checked;
      };
      saveSync.CheckedChanged += (sender, e) =>
      {
        config.SyncOnSave = openSync.Checked;
      };
      closeSync.CheckedChanged += (sender, e) =>
      {
        config.SyncOnClose = closeSync.Checked;
      };
    }

    private void Options_Load(object sender, EventArgs e)
    {

    }
  }
}
