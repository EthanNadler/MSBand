using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MSBandHealth.Models
{
    public class Pulse
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Time { get; set; }
        public int BPM { get; set; }
    }
}