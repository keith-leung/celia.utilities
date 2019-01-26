using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BR.MicroServices.Utilities
{
    [Table("__migrationversions")]
    public class MigrationVersion
    {
        [Key]
        public string VersionCode { get; set; }
        public string Version { get; set; }
        public DateTime CTIME { get; set; }
    }
}
