using Microsoft.EntityFrameworkCore;
using Try.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Try.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Try.Models.DTOs;
//using Try.DAL.Entities;
using System.Text.Json.Serialization;
//using Try.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Try.DAL.Database
{
    public class DbContainer : IdentityDbContext<Users>
    {
        //public class ApplicationUser : IdentityUser
        //{
        //    // add properties here.
        //    [StringLength(50)]
        //    public string Fname { get; set; }
        //    [StringLength(50)]
        //    public string Lname { get; set; }

        //   // public string Email { get; set; }
        //    public string Password { get; set; }
        //    [StringLength(20)]
        //    public string Phone { get; set; }
    
        //}

        public DbContainer(DbContextOptions<DbContainer> opts) : base(opts) { }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        //  public DbSet<Users> Users { get; set; }

        // public DbSet<Users> Users { get; set; }
        //public DbSet<Employee> Employees { get; set; }
        public DbSet<Estate> Estates { get; set; }
        public DbSet<FavoriteEstate> FavoriteEstates { get; set; }
       public DbSet<RecommendedEstate> RecommendedEstates { get; set; }

        //public DbSet<FavoriteVillas> FavoriteVillas { get; set; }
        //public DbSet<FavoriteDuplexes> FavoriteDuplexes { get; set; }
        //public DbSet<RecommendedEstate> FavoriteChalets { get; set; }
        //   public DbSet<CartItem> Favorites { get; set; }
        // public DbSet<CartItem> CartItem { get; set; }


        //public DbSet<Apartments> Apartmentsx { get; set; }
        //public DbSet<ApartmentsImages> ApartmentsImagesx { get; set; }
        //public DbSet<Villas> Villasx { get; set; }
        //public DbSet<VillaImage> VillaImagesx { get; set; }
        //public DbSet<Duplex> Duplexx { get; set; }
        //public DbSet<DuplexImage> DuplexImagesx { get; set; }
        //public DbSet<Chalets> Chaletsx { get; set; }
        //public DbSet<ChaletsImage> ChaletsImagesx { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    //modelBuilder.Entity<ApartmentsImages>()
        //    //    .HasOne(s => s.Apartments)
        //    //    .WithMany(c => c.Images);

        //    //modelBuilder.Entity<Apartments>()
        //    //    .HasMany(s => s.Images)
        //    //    .WithOne(c => c.Apartments);

        //    modelBuilder.Entity<VillaImage>()
        //    .HasOne(s => s.Villas)
        //    .WithMany(c => c.Images);

        //    modelBuilder.Entity<Villas>()
        //        .HasMany(s => s.Images)
        //        .WithOne(c => c.Villas);

        //    modelBuilder.Entity<ChaletsImage>()
        //    .HasOne(s => s.Chalets)
        //    .WithMany(c => c.Images);

        //    modelBuilder.Entity<Chalets>()
        //        .HasMany(s => s.Images)
        //        .WithOne(c => c.Chalets);
        //    modelBuilder.Entity<DuplexImage>()
        //    .HasOne(s => s.Duplex)
        //    .WithMany(c => c.Images);

        //    modelBuilder.Entity<Duplex>()
        //        .HasMany(s => s.Images)
        //        .WithOne(c => c.Duplex);



        //}
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<ApartmentsImages>()
        //        .HasOne(s => s.Apartments)
        //        .WithMany(e => e.ApartmentsImagesa);

        //    modelBuilder.Entity<Apartments>()
        //        .HasMany(s => s.ApartmentsImagesa)
        //        .WithOne(c => c.Apartments);
        //}
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Stadium>()
        //        .HasMany(s => s.Images)
        //        .WithOne(e => e.Stadium);
        //}
     

        //public DbSet<PhotoGraphy> PhotoGraphy { get; set; }


        //public DbSet<Image> Image { get; set; }
        //public DbSet<ImageUpload> ImageUploads { get; set; }


        //public DbSet<Album> Album { get; set; }
        //public DbSet<Photo> Photo { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Photo>()
        //        .HasOne(s => s.Album)
        //        .WithMany(c => c.Photos);
        //    //  base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Album>()
        //        .HasMany(s => s.Photos)
        //        .WithOne(c => c.Album);
        //}
        //public DbSet<Stadium> Stadiums { get; set; }



        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Stadium>()
        //        .HasMany(s => s.Images)
        //        .WithOne(e => e.Stadium);
        //}
        // public DbSet<Estate> Estate { get; set; }
        //public DbSet<ImageUpload> ImageUpload { get; set; }


        //public DbSet<Stadium> Stadiums { get; set; }
        //public DbSet<Imagex> Images { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Stadium>()
        //        .HasMany(s => s.Images)
        //        .WithOne(e => e.Stadium);
        //}
    

        //public DbSet<GalleryModel> GalleryModel { get; set; }
        //public DbSet<BookModel> BookModel { get; set; }

            // public DbSet<xD> xD { get; set; }
            //public DbSet<ProductImage> ProductImages { get; set; }

            // public DbSet<Order_Estate> order_product { get; set; }
            // public DbSet<Uploadimages> Uploadimages { get; set; }
            //    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
            //public DbSet<Try.Models.AdsVM> AdsVM { get; set; }
            //public DbSet<Try.Models.Client_interesetsVM> Client_interesetsVM { get; set; }
            //public DbSet<Try.Models.Client_ordersVM> Client_ordersVM { get; set; }
            //public DbSet<Try.Models.ClientsVM> ClientsVM { get; set; }
            //public DbSet<Try.Models.EstateVM> EstateVM { get; set; }
            //public DbSet<Try.Models.FeedbackVM> FeedbackVM { get; set; }
            //public DbSet<Try.Models.InterestsVM> InterestsVM { get; set; }
            //public DbSet<Try.Models.Order_EstateVM> Order_EstateVM { get; set; }
            //public DbSet<Try.Models.OrdersVM> OrdersVM { get; set; }
            //public DbSet<Try.Models.PropertiesVM> PropertiesVM { get; set; }
            //public DbSet<Try.Models.UserGroupVM> UserGroupVM { get; set; }
            //public DbSet<Try.Models.UsersVM> UsersVM { get; set; }
        //public DbSet<Try.DAL.Entity.Properties> Properties { get; set; }
        //public DbSet<Try.Models.AdsVM> AdsVM { get; set; }
        //public DbSet<Try.Models.Client_interesetsVM> Client_interesetsVM { get; set; }
        //public DbSet<Try.Models.Client_ordersVM> Client_ordersVM { get; set; }
        //public DbSet<Try.Models.ClientsVM> ClientsVM { get; set; }
        //public DbSet<Try.Models.EstateVM> EstateVM { get; set; }
        //public DbSet<Try.Models.FeedbackVM> FeedbackVM { get; set; }
        //public DbSet<Try.Models.InterestsVM> InterestsVM { get; set; }
        //public DbSet<Try.Models.Order_EstateVM> Order_EstateVM { get; set; }
        //public DbSet<Try.Models.OrdersVM> OrdersVM { get; set; }
        //public DbSet<Try.Models.PropertiesVM> PropertiesVM { get; set; }
        //public DbSet<Try.Models.UserGroupVM> UserGroupVM { get; set; }
        //public DbSet<Try.Models.UsersVM> UsersVM { get; set; }

        //public DbSet<Try.Models.AdsVM> AdsVM { get; set; }
        //public DbSet<Try.Models.Client_interesetsVM> Client_interesetsVM { get; set; }
        //public DbSet<Try.Models.Client_ordersVM> Client_ordersVM { get; set; }
        //public DbSet<Try.Models.ClientsVM> ClientsVM { get; set; }
        //public DbSet<Try.Models.EstateVM> EstateVM { get; set; }
        //public DbSet<Try.Models.FeedbackVM> FeedbackVM { get; set; }
        //public DbSet<Try.Models.InterestsVM> InterestsVM { get; set; }
        //public DbSet<Try.Models.Order_EstateVM> Order_EstateVM { get; set; }
        //public DbSet<Try.Models.OrdersVM> OrdersVM { get; set; }
        //public DbSet<Try.Models.PropertiesVM> PropertiesVM { get; set; }
        //public DbSet<Try.Models.UserGroupVM> UserGroupVM { get; set; }
        //public DbSet<Try.Models.UsersVM> UsersVM { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<>
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Users>().HasKey(e => e);
        //    modelBuilder.Entity<UserAccount>().ToTable("userTable");
        //    modelBuilder.Entity<UserAccount>().HasIndex(e => e.Username).HasName("IX_tblAccount");
        //    modelBuilder.Entity<UserAccount>().Property(e => e.AccountId).HasColumnName("AccountID");
        //    modelBuilder.Entity<UserAccount>()
        //        .HasOne(e => e.UserTable)
        //        .WithOne(u => u.UserAccount)
        //        .HasForeignKey<UserAccount>(e => e.UserId);
        //}
        //}

    }
}
