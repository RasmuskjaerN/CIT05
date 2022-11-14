using DataLayer.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;


namespace DataLayer
{
    public class IMDBContext : DbContext
    {
        const string ConnectionString = "host=cit.ruc.dk;db=cit05;uid=cit05;pwd=nR0RFohmp9iY";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            optionsBuilder.UseNpgsql(ConnectionString);
        }

        public DbSet<akaAttribute>? Attributes { get; set; }
        public DbSet<akaType>? Types { get; set; }
        public DbSet<titleDirector>? Directors { get; set; }
        public DbSet<knownFor>? knownFor { get; set; }
        public DbSet<nameBasic>? nameBasics { get; set; }
        public DbSet<omdbData>? omdbData { get; set; }
        public DbSet<Role>? Roles { get; set; }
        public DbSet<titleAka>? titleAkas { get; set; }
        public DbSet<titleBasic>? titleBasics { get; set; }
        public DbSet<titleEpisode>? titleEpisodes { get; set; }
        public DbSet<titleGenre>? titleGenres { get; set; }
        public DbSet<titlePrincipal>? titlePrincipals { get; set; }
        public DbSet<titleRating>? titleRatings { get; set; }
        public DbSet<titleWriter>? titleWriters { get; set; }
        public DbSet<userBookmark>? userBookmarks { get; set; }
        public DbSet<userHistory>? userHistory { get; set; }
        public DbSet<userMain>? userMain { get; set; }
        public DbSet<userRate>? userRate { get; set; }
        public DbSet<wi>? wi { get; set; }
        public DbSet<workedAs>? workedAs { get; set; }

        //kom så
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<akaAttribute>().ToTable("aka_attributes");
            modelBuilder.Entity<akaAttribute>().HasKey(x => new { x.Tconst, x.Ordering });
            modelBuilder.Entity<akaAttribute>().Property(x => x.Tconst).HasColumnName("tconst");
            modelBuilder.Entity<akaAttribute>().Property(x => x.Ordering).HasColumnName("ordering");
            modelBuilder.Entity<akaAttribute>().Property(x => x.Attribute).HasColumnName("attributes");

            modelBuilder.Entity<akaType>().ToTable("aka_type");
            modelBuilder.Entity<akaType>().HasKey(x => new { x.Tconst, x.Ordering });
            modelBuilder.Entity<akaType>().Property(x => x.Tconst).HasColumnName("tconst");
            modelBuilder.Entity<akaType>().Property(x => x.Ordering).HasColumnName("ordering");
            modelBuilder.Entity<akaType>().Property(x => x.Type).HasColumnName("type");


            modelBuilder.Entity<knownFor>().ToTable("known_for");
            modelBuilder.Entity<knownFor>().HasKey(x => new { x.Tconst, x.Nconst });
            modelBuilder.Entity<knownFor>().Property(x => x.Nconst).HasColumnType("nconst");
            modelBuilder.Entity<knownFor>().Property(x => x.Tconst).HasColumnType("tconst");

            modelBuilder.Entity<nameBasic>().ToTable("name_basics");
            modelBuilder.Entity<nameBasic>().HasKey(x => x.Nconst);
            modelBuilder.Entity<nameBasic>().Property(x => x.Nconst).HasColumnType("nconst");
            modelBuilder.Entity<nameBasic>().Property(x => x.PrimaryName).HasColumnType("primaryname");
            modelBuilder.Entity<nameBasic>().Property(x => x.Birthyear).HasColumnType("birthyear");
            modelBuilder.Entity<nameBasic>().Property(x => x.Deathyear).HasColumnType("deathyear");
            modelBuilder.Entity<nameBasic>().Property(x => x.NameRating).HasColumnType("name_rating");

            modelBuilder.Entity<omdbData>().ToTable("omdb_data");
            modelBuilder.Entity<omdbData>().HasKey(x => x.Tconst);
            modelBuilder.Entity<omdbData>().Property(x => x.Tconst).HasColumnType("tconst");
            modelBuilder.Entity<omdbData>().Property(x => x.Poster).HasColumnType("poster");
            modelBuilder.Entity<omdbData>().Property(x => x.Plot).HasColumnType("plot");

            modelBuilder.Entity<Role>().ToTable("roles");
            modelBuilder.Entity<Role>().HasKey(x => new { x.Tconst, x.Nconst, x.Character });
            modelBuilder.Entity<Role>().Property(x => x.Nconst).HasColumnType("nconst");
            modelBuilder.Entity<Role>().Property(x => x.Tconst).HasColumnType("tconst");
            modelBuilder.Entity<Role>().Property(x => x.Character).HasColumnType("characters");

            modelBuilder.Entity<titleAka>().ToTable("title_akas");
            modelBuilder.Entity<titleAka>().HasKey(x => new { x.Tconst, x.Ordering });
            modelBuilder.Entity<titleAka>().Property(x => x.Tconst).HasColumnType("tconst");
            modelBuilder.Entity<titleAka>().Property(x => x.Ordering).HasColumnType("ordering");
            modelBuilder.Entity<titleAka>().Property(x => x.Title).HasColumnType("title");
            modelBuilder.Entity<titleAka>().Property(x => x.Region).HasColumnType("region");
            modelBuilder.Entity<titleAka>().Property(x => x.Language).HasColumnType("language");
            modelBuilder.Entity<titleAka>().Property(x => x.Type).HasColumnType("types");
            modelBuilder.Entity<titleAka>().Property(x => x.Attribute).HasColumnType("attributes");
            modelBuilder.Entity<titleAka>().Property(x => x.IsOriginalTitle).HasColumnType("isoriginaltitle");

            modelBuilder.Entity<titleBasic>().ToTable("title_basics");
            modelBuilder.Entity<titleBasic>().HasKey(x => x.Tconst);
            modelBuilder.Entity<titleBasic>().Property(x => x.Tconst).HasColumnType("tconst");
            modelBuilder.Entity<titleBasic>().Property(x => x.TitleType).HasColumnType("titletype");
            modelBuilder.Entity<titleBasic>().Property(x => x.PrimaryTitle).HasColumnType("primarytitle");
            modelBuilder.Entity<titleBasic>().Property(x => x.OriginalTitle).HasColumnType("originaltitle");
            modelBuilder.Entity<titleBasic>().Property(x => x.IsAdult).HasColumnType("isadult");
            modelBuilder.Entity<titleBasic>().Property(x => x.StartYear).HasColumnType("startyear");
            modelBuilder.Entity<titleBasic>().Property(x => x.EndYear).HasColumnType("endyear");
            modelBuilder.Entity<titleBasic>().Property(x => x.RunTimeMinutes).HasColumnType("runtimeminutes");
            modelBuilder.Entity<titleBasic>().Property(x => x.Genre).HasColumnType("genres");

            modelBuilder.Entity<titleDirector>().ToTable("title_directors");
            modelBuilder.Entity<titleDirector>().HasKey(x => new { x.Nconst, x.Tconst });
            modelBuilder.Entity<titleDirector>().Property(x => x.Tconst).HasColumnType("tconst");
            modelBuilder.Entity<titleDirector>().Property(x => x.Nconst).HasColumnType("directors");

            modelBuilder.Entity<titleEpisode>().ToTable("title_episodes");
            modelBuilder.Entity<titleEpisode>().HasKey(x => x.Tconst);
            modelBuilder.Entity<titleEpisode>().Property(x => x.Tconst).HasColumnType("tconst");
            modelBuilder.Entity<titleEpisode>().Property(x => x.ParentTconst).HasColumnType("parenttconst");
            modelBuilder.Entity<titleEpisode>().Property(x => x.SeasonNumber).HasColumnType("seasonnumber");
            modelBuilder.Entity<titleEpisode>().Property(x => x.EpisodeNumber).HasColumnType("episodenumber");

            modelBuilder.Entity<titleGenre>().ToTable("title_genres");
            modelBuilder.Entity<titleGenre>().HasKey(x => new { x.Tconst, x.Genre });
            modelBuilder.Entity<titleGenre>().Property(x => x.Tconst).HasColumnType("tconst");
            modelBuilder.Entity<titleGenre>().Property(x => x.Genre).HasColumnType("genre");

            modelBuilder.Entity<titlePrincipal>().ToTable("title_principals");
            modelBuilder.Entity<titlePrincipal>().HasKey(x => new { x.Tconst, x.Ordering });
            modelBuilder.Entity<titlePrincipal>().Property(x => x.Tconst).HasColumnType("tconst");
            modelBuilder.Entity<titlePrincipal>().Property(x => x.Ordering).HasColumnType("ordering");
            modelBuilder.Entity<titlePrincipal>().Property(x => x.Nconst).HasColumnType("nconst");
            modelBuilder.Entity<titlePrincipal>().Property(x => x.Category).HasColumnType("akaType");
            modelBuilder.Entity<titlePrincipal>().Property(x => x.Job).HasColumnType("job");

            modelBuilder.Entity<titleRating>().ToTable("title_ratings");
            modelBuilder.Entity<titleRating>().HasKey(x => x.Tconst);
            modelBuilder.Entity<titleRating>().Property(x => x.Tconst).HasColumnType("tconst");
            modelBuilder.Entity<titleRating>().Property(x => x.AverageRating).HasColumnType("averagerating");
            modelBuilder.Entity<titleRating>().Property(x => x.NumVotes).HasColumnType("numvotes");

            modelBuilder.Entity<titleWriter>().ToTable("title_writers");
            modelBuilder.Entity<titleWriter>().HasKey(x => new { x.Tconst, x.Nconst });
            modelBuilder.Entity<titleWriter>().Property(x => x.Tconst).HasColumnType("tconst");
            modelBuilder.Entity<titleWriter>().Property(x => x.Nconst).HasColumnType("writers");

            modelBuilder.Entity<userBookmark>().ToTable("user_bookmark");
            modelBuilder.Entity<userBookmark>().HasKey(x => new { x.Tconst, x.Uid });
            modelBuilder.Entity<userBookmark>().Property(x => x.Uid).HasColumnType("uid");
            modelBuilder.Entity<userBookmark>().Property(x => x.Tconst).HasColumnType("tconst");
            modelBuilder.Entity<userBookmark>().Property(x => x.Nconst).HasColumnType("nconst");
            modelBuilder.Entity<userBookmark>().Property(x => x.Note).HasColumnType("note");

            modelBuilder.Entity<userHistory>().ToTable("user_history");
            modelBuilder.Entity<userHistory>().HasKey(x => x.Uid);
            modelBuilder.Entity<userHistory>().Property(x => x.Uid).HasColumnType("uid");
            modelBuilder.Entity<userHistory>().Property(x => x.Date).HasColumnType("date");
            modelBuilder.Entity<userHistory>().Property(x => x.SearchInput).HasColumnType("searchinput");

            modelBuilder.Entity<userMain>().ToTable("user_main");
            modelBuilder.Entity<userMain>().HasKey(x => x.Uid);
            modelBuilder.Entity<userMain>().Property(x => x.Uid).HasColumnType("uid");
            modelBuilder.Entity<userMain>().Property(x => x.Name).HasColumnType("name");
            modelBuilder.Entity<userMain>().Property(x => x.Password).HasColumnType("password");

            modelBuilder.Entity<userRate>().ToTable("user_rate");
            modelBuilder.Entity<userRate>().HasKey(x => new { x.Uid, x.Tconst });
            modelBuilder.Entity<userRate>().Property(x => x.Uid).HasColumnType("uid");
            modelBuilder.Entity<userRate>().Property(x => x.Tconst).HasColumnType("tconst");
            modelBuilder.Entity<userRate>().Property(x => x.Rate).HasColumnType("rate");

            modelBuilder.Entity<wi>().ToTable("wi");
            modelBuilder.Entity<wi>().HasKey(x => x.Tconst);
            modelBuilder.Entity<wi>().Property(x => x.Tconst).HasColumnType("tconst");
            modelBuilder.Entity<wi>().Property(x => x.Word).HasColumnType("word");
            modelBuilder.Entity<wi>().Property(x => x.Field).HasColumnType("field");
            modelBuilder.Entity<wi>().Property(x => x.Lexeme).HasColumnType("lexeme");

            modelBuilder.Entity<workedAs>().ToTable("worked_as");
            modelBuilder.Entity<workedAs>().HasKey(x => new { x.Nconst, x.PrimaryProfession });
            modelBuilder.Entity<workedAs>().Property(x => x.Nconst).HasColumnType("nconst");
            modelBuilder.Entity<workedAs>().Property(x => x.PrimaryProfession).HasColumnType("primaryprofession");
        }

    }
}
