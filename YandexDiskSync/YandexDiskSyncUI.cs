using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Globalization;
using System.Windows.Forms;
using KeePass.Plugins;
using KeePassLib;
using KeePassLib.Security;

namespace YandexDiskSync
{
  public sealed partial class YandexDiskSyncExt
  {
    private void ShowNotification(string text, EventHandler onclick = null, EventHandler onclose = null)
    {
      MethodInvoker m = delegate
      {
        var notify = _host.MainWindow.MainNotifyIcon;
        if (notify == null)
          return;

        EventHandler clicked = null;
        EventHandler closed = null;

        clicked = delegate
        {
          notify.BalloonTipClicked -= clicked;
          notify.BalloonTipClosed -= closed;
          if (onclick != null)
            onclick(notify, null);
        };
        closed = delegate
        {
          notify.BalloonTipClicked -= clicked;
          notify.BalloonTipClosed -= closed;
          if (onclose != null)
            onclose(notify, null);
        };

        notify.BalloonTipIcon = ToolTipIcon.Info;
        notify.BalloonTipTitle = "YandexDiskSync";
        notify.BalloonTipText = text;
        notify.ShowBalloonTip(5000);
        // need to add listeners after showing, or closed is sent right away
        notify.BalloonTipClosed += closed;
        notify.BalloonTipClicked += clicked;
      };
      if (_host.MainWindow.InvokeRequired)
        _host.MainWindow.Invoke(m);
      else
        m.Invoke();
    }
    private void UpdateUI(PwGroup group)
    {
      var win = _host.MainWindow;
      if (group == null) group = _host.Database.RootGroup;
      var f = (MethodInvoker)(() => win.UpdateUI(false, null, true, @group, true, null, true));
      if (win.InvokeRequired)
        win.Invoke(f);
      else
        f.Invoke();
    }

    private PwEntry GetConfigEntry(bool create)
    {
      var root = _host.Database.RootGroup;
      var uuid = new PwUuid(YandexDiskSyncUuid);
      var entry = root.FindEntry(uuid, false);
      if (entry == null && create)
      {
        entry = new PwEntry(false, true) { Uuid = uuid };
        entry.Strings.Set(PwDefs.TitleField, new ProtectedString(false, YandexDiskSyncName));
        root.AddEntry(entry, true);
        UpdateUI(null);
      }
      return entry;
    }
  }
}
