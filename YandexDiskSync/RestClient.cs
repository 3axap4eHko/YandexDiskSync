using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Script.Serialization;

namespace YandexDiskSync
{
  public class Params : Dictionary<string, string>
  {

  }

  abstract public class RestClient
  {
    private readonly string _baseUrl;

    private static readonly HttpClient client = new HttpClient();

    private string _authorization;

    static JavaScriptSerializer _js = new JavaScriptSerializer();

    public RestClient(string baseUrl)
    {
      _baseUrl = baseUrl;
    }

    protected static T Request<T>(string url, HttpMethod method = null, Params queryParams = null, IEnumerable<KeyValuePair<string, string>> data = null, Params headers = null)
    {
      if (method == null)
      {
        method = HttpMethod.Get;
      }
      var requestUri = new UriBuilder(url);
      if (queryParams != null)
      {
        requestUri.Query = String.Join("&", queryParams.Select(pair => string.Format("{0}={1}", HttpUtility.UrlEncode(pair.Key), HttpUtility.UrlEncode(pair.Value))));
      }

      var request = new HttpRequestMessage(method, requestUri.Uri);
      request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
      if (headers != null)
      {
        foreach (var pair in headers)
        {
          request.Headers.Add(pair.Key, pair.Value);
        }
      }

      if (data != null)
      {
        request.Content = new FormUrlEncodedContent(data);
      }
      var response = Async.Await(client.SendAsync(request));
      if (!response.IsSuccessStatusCode)
      {
        var errorCode = (int)response.StatusCode;
        throw new HttpException(response.ReasonPhrase, errorCode);
      }
      var result = Async.Await(response.Content.ReadAsStringAsync());
      return _js.Deserialize<T>(result);
    }

    protected T Resource<T>(string resource, HttpMethod method = null, Params queryParams = null, IEnumerable<KeyValuePair<string, string>> data = null)
    {
      var headers = new Params();
      if (IsAuthorized)
      {
        headers.Add("Authorization", _authorization);
      }
      var url = new UriBuilder(_baseUrl);
      url.Path = url.Path + resource;
      try
      {
        return Request<T>(url.ToString(), method, queryParams, data, headers);
      }
      catch(HttpException ex)
      {
        if (ex.ErrorCode == 404)
        {
          return default(T);
        }
        throw ex;
      }
      
    }

    protected FileInfo DownloadFileFromUrl(string url, string filename)
    {
      var webClient = new WebClient();
      if (!string.IsNullOrEmpty(_authorization))
      {
        webClient.Headers.Add(HttpRequestHeader.Authorization, _authorization);
      }
      var uri = new Uri(url);
      webClient.DownloadFile(uri, filename);
      return new FileInfo(filename);
    }
    protected void UploadFileToUrl(string filename, string url, string method)
    {
      var webClient = new WebClient();
      if (!string.IsNullOrEmpty(_authorization))
      {
        webClient.Headers.Add(HttpRequestHeader.Authorization, _authorization);
      }
      var uri = new Uri(url);
      webClient.UploadFile(uri, method, filename);
    }

    public bool IsAuthorized { get { return !string.IsNullOrEmpty(_authorization); } }
    public void SetAuthorization(string authorization)
    {
      _authorization = authorization;
    }
  }
}
