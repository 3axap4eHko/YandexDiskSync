using KeePassLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexDiskSync
{
  public class Log : IStatusLogger
  {
    #region IStatusLogger Members

    public bool ContinueWork()
    {
      return true;
    }

    public void EndLogging()
    {
      return;
    }

    public bool SetProgress(uint uPercent)
    {
      return true;
    }

    public bool SetText(string strNewText, LogStatusType lsType)
    {
      return true;
    }

    public void StartLogging(string strOperation, bool bWriteOperationToLog)
    {
      throw new NotImplementedException();
    }

    #endregion
  }
}
