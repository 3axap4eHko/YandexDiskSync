using System.Collections.Generic;

namespace YandexDiskSync.Types
{
    public class ResourceListResponse
    {
        public string sort { get; set; }
        public List<ResourceResponse> items { get; set; }
        public uint limit { get; set; }
        public uint offset { get; set; }
        public string path { get; set; }
        public uint total { get; set; }

        public ResourceListResponse()
        {
            
        }
    }
}
