using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeePass.App.Configuration;

namespace YandexDiskSync
{
  public class Config
  {
    private const string OAuthTokenKey = @"YandexDiskSync_OAuthToken";
    private const string OAuthTokenExpireKey = @"YandexDiskSync_OAuthTokenExpire";
    private const string LimitHistoryKey = @"YandexDiskSync_LimitHistory";
    private const string LimitHistorySizeKey = @"YandexDiskSync_LimitHistorySize";
    private const string SyncOnOpenKey = @"YandexDiskSync_SyncOnOpen";
    private const string SyncOnSaveKey = @"YandexDiskSync_SyncOnSave";
    private const string SyncOnCloseKey = @"YandexDiskSync_SyncOnClose";

    private readonly AceCustomConfig _config;

    public Config(AceCustomConfig config)
    {
      _config = config;
    }
    public bool SyncOnOpen
    {
      get { return _config.GetBool(SyncOnOpenKey, false); }
      set { _config.SetBool(SyncOnOpenKey, value); }
    }
    public bool SyncOnSave
    {
      get { return _config.GetBool(SyncOnSaveKey, false); }
      set { _config.SetBool(SyncOnSaveKey, value); }
    }
    public bool SyncOnClose
    {
      get { return _config.GetBool(SyncOnCloseKey, false); }
      set { _config.SetBool(SyncOnCloseKey, value); }
    }

    public bool LimitHistory
    {
      get { return _config.GetBool(LimitHistoryKey, false); }
      set { _config.SetBool(LimitHistoryKey, value); }
    }
    public ulong LimitHistorySize
    {
      get { return _config.GetULong(LimitHistorySizeKey, 10); }
      set { _config.SetULong(LimitHistorySizeKey, value); }
    }
    public string OAuthToken
    {
      get { return _config.GetString(OAuthTokenKey, ""); }
      set { _config.SetString(OAuthTokenKey, value); }
    }

    public long OAuthTokenExpiresIn
    {
      get { return _config.GetLong(OAuthTokenExpireKey, (int)(DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds ); }
      set { _config.SetLong(OAuthTokenExpireKey, value); }
    }
    public DateTime OAuthTokenExpires
    {
      get { return OAuthTokenExpiresIn.AsUnixTimeStamp(); }
    }
    public bool IsAuthorized
    {
      get { return !string.IsNullOrEmpty(OAuthToken) && OAuthTokenExpires > DateTime.Now; }
    }

  }
}
