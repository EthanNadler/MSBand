using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MSBandHealth.Models
{
    public class ActivityLevel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Time { get; set; }
        public String Level { get; set; }

        public enum ActivityLevels {IDLE, WALKING, JOGGING, RUNNING};
    }
}