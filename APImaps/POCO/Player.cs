namespace APImaps.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("player")]
    public partial class Player
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Player()
        {
            routes = new HashSet<Route>();
        }

        [Key]
        public int idplayer { get; set; }

        [StringLength(50)]
        public string nickname { get; set; }

        public int idrapidity { get; set; }

        public int idtrust { get; set; }

        public virtual Rapidity rapidity { get; set; }

        public virtual Trust trust { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Route> routes { get; set; }
    }
}
