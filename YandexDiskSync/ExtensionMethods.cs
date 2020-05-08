using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace YandexDiskSync
{
  public static class ExtensionMethods
  {
    public static readonly DateTime UnixDateTimeStart = new DateTime(1970, 1, 1, 0, 0, 0, 0);

    public static string Format(this string formatString, IEnumerable<KeyValuePair<string, string>> args)
    {
      return args.Aggregate(formatString, (current, arg) => current.Replace("{" + arg.Key + "}", arg.Value));
    }
    public static long NowUTS(this DateTime date)
    {
      return (long)(date - UnixDateTimeStart).TotalSeconds;
    }
    public static DateTime AsUnixTimeStamp(this long unixTimeStamp)
    {
      return UnixDateTimeStart.AddSeconds(unixTimeStamp);
    }
    public static DateTime ToDateTime(this long totalSeconds)
    {
      return DateTime.MinValue.AddSeconds(totalSeconds);
    }

    public static long ExpireToSeconds(this long exprireTime)
    {
      return exprireTime + DateTime.Now.GetTotalSeconds();
    }
    public static long SecondsToExpire(this long totalSeconds)
    {
      return totalSeconds - DateTime.Now.GetTotalSeconds();
    }

    public static long GetTotalSeconds(this DateTime datetime)
    {
      var diff = datetime.ToUniversalTime() - DateTime.MinValue;
      return Convert.ToInt64(diff.TotalSeconds);
    }

    public static void ForEach<TSource, TResult>(this IEnumerable<TSource> source, Action<TSource> selector)
    {
      foreach (var item in source)
      {
        selector(item);
      }
    }

    public static string MD5(this FileInfo file)
    {
      using (var md5 = System.Security.Cryptography.MD5.Create())
      {
        using (var stream = File.OpenRead(file.FullName))
        {
          return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", String.Empty).ToLower();
        }
      }
    }

    public static string SHA256(this FileInfo file)
    {
      using (var sha256 = new System.Security.Cryptography.SHA256Managed())
      {
        using (var stream = File.OpenRead(file.FullName))
        {
          return BitConverter.ToString(sha256.ComputeHash(stream)).Replace("-", String.Empty).ToLower();
        }
      }
    }

    public static string AsSize(this ulong size)
    {
      string[] sizes = { "B", "KB", "MB", "GB", "TB" };
      int order = 0;
      while (size >= 1000 && order < sizes.Length - 1)
      {
        order++;
        size = size / 1000;
      }
      return string.Format("{0:0.##} {1}", size, sizes[order]);
    }

    public static void Delete(this FileInfo file)
    {
      File.WriteAllBytes(file.FullName, new byte[file.Length]);
      File.WriteAllBytes(file.FullName, new byte[0]);
      File.Delete(file.FullName);
    }
  }
}
