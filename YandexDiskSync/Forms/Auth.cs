using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YandexDiskSync.Forms
{
  public partial class Auth : Form
  {
    private Config _config;
    private Api _api;

    public static void Authenticate(Config config, Api api)
    {
      var authForm = new Auth(config, api);
      authForm.ShowDialog();
    }
    protected Auth(Config config, Api api)
    {
      _config = config;
      _api = api;
      InitializeComponent();
    }

    private void Authorize_Click(object sender, EventArgs e)
    {
      Authorize.Enabled = false;
      try
      {
        var auth = _api.Authorize(CodeInput.Text);
        _config.OAuthToken = auth.access_token;
        _config.OAuthTokenExpiresIn = auth.expires_in;
        errorLabel.Visible = false;
        Close();
      }
      catch (Exception ex)
      {
        errorLabel.Text = ex.Message;
        errorLabel.Visible = true;
      }
      finally
      {
        Authorize.Enabled = true;
      }
    }

    private void CodeLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      System.Diagnostics.Process.Start(Api.AuthorizeUrl);
    }
  }
}
