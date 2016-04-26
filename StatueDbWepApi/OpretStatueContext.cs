namespace StatueDbWepApi
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OpretStatueContext : DbContext
    {
        public OpretStatueContext()
            : base("name=OpretStatueContext")
        {
        }

        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Culturalvalue> Culturalvalue { get; set; }
        public virtual DbSet<CulturalValueList> CulturalValueList { get; set; }
        public virtual DbSet<Description> Description { get; set; }
        public virtual DbSet<GPSLocation> GPSLocation { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<ImageList> ImageList { get; set; }
        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<MaterialList> MaterialList { get; set; }
        public virtual DbSet<Placement> Placement { get; set; }
        public virtual DbSet<PlacementList> PlacementList { get; set; }
        public virtual DbSet<Statue> Statue { get; set; }
        public virtual DbSet<StatueType> StatueType { get; set; }
        public virtual DbSet<StatueTypeList> StatueTypeList { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<database_firewall_rules> database_firewall_rules { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .Property(e => e.Zipcode)
                .IsUnicode(false);

            modelBuilder.Entity<City>()
                .Property(e => e.City1)
                .IsUnicode(false);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Statue)
                .WithRequired(e => e.City)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Culturalvalue>()
                .Property(e => e.CulturalValue1)
                .IsUnicode(false);

            modelBuilder.Entity<Culturalvalue>()
                .HasMany(e => e.CulturalValueList)
                .WithRequired(e => e.Culturalvalue)
                .HasForeignKey(e => e.FK_CulturalValue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GPSLocation>()
                .Property(e => e.Coordinates)
                .IsUnicode(false);

            modelBuilder.Entity<Image>()
                .Property(e => e.Image1)
                .IsUnicode(false);

            modelBuilder.Entity<Image>()
                .HasMany(e => e.ImageList)
                .WithRequired(e => e.Image)
                .HasForeignKey(e => e.FK_Image)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Material>()
                .Property(e => e.Material1)
                .IsUnicode(false);

            modelBuilder.Entity<Material>()
                .Property(e => e.Types)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Material>()
                .HasMany(e => e.MaterialList)
                .WithRequired(e => e.Material)
                .HasForeignKey(e => e.FK_Material)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Placement>()
                .Property(e => e.Placement1)
                .IsUnicode(false);

            modelBuilder.Entity<Placement>()
                .HasMany(e => e.PlacementList)
                .WithRequired(e => e.Placement)
                .HasForeignKey(e => e.FK_Placement)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Statue>()
                .Property(e => e.Adress)
                .IsUnicode(false);

            modelBuilder.Entity<Statue>()
                .Property(e => e.Zipcode)
                .IsUnicode(false);

            modelBuilder.Entity<Statue>()
                .HasMany(e => e.CulturalValueList)
                .WithRequired(e => e.Statue)
                .HasForeignKey(e => e.FK_Statue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Statue>()
                .HasMany(e => e.Description)
                .WithRequired(e => e.Statue)
                .HasForeignKey(e => e.FK_Statue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Statue>()
                .HasMany(e => e.GPSLocation)
                .WithRequired(e => e.Statue)
                .HasForeignKey(e => e.FK_Statue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Statue>()
                .HasMany(e => e.ImageList)
                .WithRequired(e => e.Statue)
                .HasForeignKey(e => e.FK_Statue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Statue>()
                .HasMany(e => e.MaterialList)
                .WithRequired(e => e.Statue)
                .HasForeignKey(e => e.FK_Statue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Statue>()
                .HasMany(e => e.PlacementList)
                .WithRequired(e => e.Statue)
                .HasForeignKey(e => e.FK_Statue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Statue>()
                .HasMany(e => e.StatueTypeList)
                .WithRequired(e => e.Statue)
                .HasForeignKey(e => e.FK_Statue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StatueType>()
                .Property(e => e.StatueType_)
                .IsUnicode(false);

            modelBuilder.Entity<StatueType>()
                .HasMany(e => e.StatueTypeList)
                .WithRequired(e => e.StatueType)
                .HasForeignKey(e => e.FK_StatueType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<database_firewall_rules>()
                .Property(e => e.start_ip_address)
                .IsUnicode(false);

            modelBuilder.Entity<database_firewall_rules>()
                .Property(e => e.end_ip_address)
                .IsUnicode(false);
        }
    }
}
