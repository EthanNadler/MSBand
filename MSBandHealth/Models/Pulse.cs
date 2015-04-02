using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSBandHealth.Models
{
    public class Pulse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public int BPM { get; set; }
    }
}