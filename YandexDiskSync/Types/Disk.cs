using System;
using System.Collections.Generic;

namespace YandexDiskSync.Types
{
  public class DiskRequest
  {

  }

  public class DiskResponse
  {
    public UInt64 trash_size { get; set; }
    public UInt64 total_space { get; set; }
    public UInt64 used_space { get; set; }
    public Dictionary<string, string> system_folders { get; set; }
  }
}
