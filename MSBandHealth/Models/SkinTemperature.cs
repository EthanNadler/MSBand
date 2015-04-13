using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MSBandHealth.Models
{
    public class SkinTemperature
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Time { get; set; }
        public double Temperature { get; set; }
    }
}