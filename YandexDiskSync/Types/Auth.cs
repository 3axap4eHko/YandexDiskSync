using System;

namespace YandexDiskSync.Types
{
  public class AuthRequest : Params
  {
    public string grant_type { get { return this["grant_type"]; } set { this.Add("grant_type", value); } }
    public string code { get { return this["code"]; } set { this.Add("code", value); } }
    public string client_id { get { return this["client_id"]; } set { this.Add("client_id", value); } }
    public string client_secret { get { return this["client_secret"]; } set { this.Add("client_secret", value); } }

  }

  public class AuthResponse
  {
    public string access_token { get; set; }
    public Int64 expires_in
    {
      get { return _created.GetTotalSeconds() + _exprires - DateTime.Now.GetTotalSeconds(); }
      set { _created = DateTime.Now; _exprires = value; }
    }
    public string token_type { get; set; }

    private Int64 _exprires;
    private DateTime _created;

    public AuthResponse()
    {
      _created = DateTime.Now;
    }
  }
}
