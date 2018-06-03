namespace APImaps
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("route")]
    public partial class Route
    {
        [Key]
        public int idroute { get; set; }

        public double? distance { get; set; }

        public double? time { get; set; }

        [StringLength(1)]
        public string wazelink { get; set; }

        [StringLength(1)]
        public string mapslink { get; set; }

        public int idplayer { get; set; }

        public int idstatus { get; set; }

        public virtual Player player { get; set; }

        public virtual Status status { get; set; }
    }
}
