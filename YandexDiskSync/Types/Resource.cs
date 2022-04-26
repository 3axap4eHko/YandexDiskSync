using System;

namespace YandexDiskSync.Types
{
    public class ResourceResponse
    {
        public string public_key { get; set; }
        public string origin_path { get; set; }
        public string public_url { get; set; }
        public string preview { get; set; }
        public string name { get; set; }
        public DateTime created { get; set; }
        public DateTime modified { get; set; }
        public string media_type { get; set; }
        public string path { get; set; }
        public string md5 { get; set; }
        public string sha256 { get; set; }
        public string type { get; set; }
        public string mime_type { get; set; }
        public UInt64 size { get; set; }
        public ResourceListResponse _embedded { get; set; }

        public ResourceResponse()
        {
            
        }
    }
}
