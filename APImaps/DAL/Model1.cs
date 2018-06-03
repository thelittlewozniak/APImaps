namespace APImaps
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        private static Model1 instance = null;

        private Model1(): base("name=Model1"){}

        public virtual DbSet<Player> players { get; set; }
        public virtual DbSet<Rapidity> rapidities { get; set; }
        public virtual DbSet<Route> routes { get; set; }
        public virtual DbSet<Status> status { get; set; }
        public virtual DbSet<Trust> trusts { get; set; }

        public static Model1 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Model1();
                }
                return instance;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .Property(e => e.nickname)
                .IsUnicode(false);

            modelBuilder.Entity<Player>()
                .HasMany(e => e.routes)
                .WithRequired(e => e.player)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rapidity>()
                .Property(e => e.RapidityName)
                .IsUnicode(false);

            modelBuilder.Entity<Rapidity>()
                .HasMany(e => e.players)
                .WithRequired(e => e.rapidity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Route>()
                .Property(e => e.wazelink)
                .IsUnicode(false);

            modelBuilder.Entity<Route>()
                .Property(e => e.mapslink)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .Property(e => e.statusName)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.routes)
                .WithRequired(e => e.status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trust>()
                .Property(e => e.trustName)
                .IsUnicode(false);

            modelBuilder.Entity<Trust>()
                .HasMany(e => e.players)
                .WithRequired(e => e.trust)
                .WillCascadeOnDelete(false);
        }
    }
}
