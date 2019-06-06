using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Shortname { get; set; }
        public Brand Brand { get; set; }
        public string Image { get; set; }
        public string ReleaseYear { get; set; }
        public DeviceType DeviceType { get; set; }
        public List<Shop> Shops { get; set; }
    }
    public enum DeviceType
    {
        Handheld, Console, Hybrid
    }
}
