using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexDiskSync
{
  public delegate Func<Task<T>> AsyncTask<T>();
  public class Async
  {
    public static EventHandler<T> Catch<T>(Func<object, T, Task> func, Action<Exception> onError) where T: EventArgs
    {
      return async (object sender, T e) =>
      {
        try
        {
          await func(sender, e);
        }
        catch (Exception ex)
        {
          onError(ex);
        }
      };
    }
    public static EventHandler Catch(EventHandler func, Action<Exception> onError)
    {
      return Catch(func, onError);
    }
    public static T Await<T>(Task<T> task)
    {
      task.Wait();
      return task.Result;
    }

    public static void Await(Task task)
    {
      task.Wait();
    }

    public static T Retry<T>(Func<T> func, Func<Exception, T> onError, int retryCount = 3)
    {
      while (true)
      {
        try
        {
          Exception exception = null;
          try
          {
            return func();
          }
          catch (Exception e)
          {
            exception = e;
          }
          return onError(exception);
        }
        catch (Exception e)
        {
          if (--retryCount == 0)
          {
            throw e;
          }
        }

      }
    }

  }
}
