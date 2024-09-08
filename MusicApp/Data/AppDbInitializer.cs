using Microsoft.AspNetCore.Identity;
using MusicApp.Data.Enums;
using MusicApp.Data.Static;
using MusicApp.Models;

namespace MusicApp.Data
{
    public class AppDbInitializer
    {

        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Plases
                if (!context.Places.Any())
                {
                    context.Places.AddRange(new List<Place>()
                    {
                        new Place()
                        {
                            Name = "Place 1",
                            Logo = "https://images.pexels.com/photos/114296/pexels-photo-114296.jpeg",
                            Description = "Stadium Allianz Arena"
                        },
                        new Place()
                        {
                            Name = "Place 2",
                            Logo = "https://images.pexels.com/photos/114296/pexels-photo-114296.jpeg",
                            Description = "Greece "
                        },
                        new Place()
                        {
                            Name = "Place 3",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            Description = "Cinema as place"
                        },
                        new Place()
                        {
                            Name = "Place 4",
                            Logo = "https://images.pexels.com/photos/167636/pexels-photo-167636.jpeg",
                            Description = "Usa"
                        },
                
                    });
                    context.SaveChanges();
                }
                //Songs
                if (!context.Songs.Any())
                {
                    context.Songs.AddRange(new List<Song>()
                    {
                        new Song()
                        {
                            FullName = "Song 1",
                            Bio = "This is the Info of the first song",
                            ProfilePictureURL = "http://dotnethow.net/images/songs/song-1.jpeg"

                        },
                        new Song()
                        {
                            FullName = "Song 2",
                            Bio = "This is the Info of the second song",
                            ProfilePictureURL = "http://dotnethow.net/images/songs/song-2.jpeg"
                        },
                        new Song()
                        {
                            FullName = "Song 3",
                            Bio = "This is the Info of the second song",
                            ProfilePictureURL = "http://dotnethow.net/images/songs/song-3.jpeg"
                        },
                        new Song()
                        {
                            FullName = "Song 4",
                            Bio = "This is the Info of the second song",
                            ProfilePictureURL = "http://dotnethow.net/images/songs/song-4.jpeg"
                        },
                        new Song()
                        {
                            FullName = "Song 5",
                            Bio = "This is the Info of the second song",
                            ProfilePictureURL = "http://dotnethow.net/images/songs/song-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                //Organisators
                if (!context.Organisators.Any())
                {
                    context.Organisators.AddRange(new List<Organisator>()
                    {
                        new Organisator()
                        {
                            FullName = "Organisator 1",
                            Bio = "This is the Bio of the first Organisator",
                            ProfilePictureURL = "http://dotnethow.net/images/singers/singer-1.jpeg"

                        },
                        new Organisator()
                        {
                            FullName = "Organisator 2",
                            Bio = "This is the Bio of the second Organisator",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-2.jpeg"
                        },
                        new Organisator()
                        {
                            FullName = "Organisator 3",
                            Bio = "This is the Bio of the second Organisator",
                            ProfilePictureURL = "http://dotnethow.net/images/organisators/organisator-3.jpeg"
                        },
                        new Organisator()
                        {
                            FullName = "Organisator 4",
                            Bio = "This is the Bio of the second Organisator",
                            ProfilePictureURL = "http://dotnethow.net/images/organisators/organisator-4.jpeg"
                        },
                        new Organisator()
                        {
                            FullName = "Organisator 5",
                            Bio = "This is the Bio of the second Organisator",
                            ProfilePictureURL = "http://dotnethow.net/images/singers/singer-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                //Concerts
                if (!context.Concerts.Any())
                {
                    context.Concerts.AddRange(new List<Concert>()
                    {
                        new Concert()
                        {
                            Name = "Life",
                            Description = "This is the Life concert description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            PlaceId = 3,
                            OrganisatorId = 3,
                            ConcertCategory = ConcertCategory.Mixed
                        },
                        new Concert()
                        {
                            Name = "The Festival ",
                            Description = "This is the Festival description",
                            Price = 29.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            PlaceId = 1,
                            OrganisatorId = 5,
                            ConcertCategory = ConcertCategory.Festival
                        },
                        new Concert()
                        {
                            Name = "Rock",
                            Description = "This is the new release of Rock music description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            PlaceId = 4,
                            OrganisatorId = 4,
                            ConcertCategory = ConcertCategory.Charity
                        },
                        new Concert()
                        {
                            Name = "Pop",
                            Description = "This is the Pop charity description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            PlaceId = 1,
                            OrganisatorId = 2,
                            ConcertCategory = ConcertCategory.Charity
                        },
                        new Concert()
                        {
                            Name = "Bob",
                            Description = "This is the new Bob album description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-7.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            PlaceId = 2,
                            OrganisatorId = 3,
                            ConcertCategory = ConcertCategory.NewReleaseAlbum
                        },
                        new Concert()
                        {
                            Name = "Cold ",
                            Description = "This is the Cold-Rock description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-8.jpeg",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            PlaceId = 1,
                            OrganisatorId = 1,
                            ConcertCategory = ConcertCategory.Festival
                        }
                    });
                    context.SaveChanges();
                }
                //Songs & Concerts
                if (!context.Songs_Concerts.Any())
                {
                    context.Songs_Concerts.AddRange(new List<Song_Concert>()
                    {
                        new Song_Concert()
                        {
                            SongId = 1,
                            ConcertId = 1
                        },
                        new Song_Concert()
                        {
                            SongId = 3,
                            ConcertId = 1
                        },

                         new Song_Concert()
                        {
                            SongId = 1,
                            ConcertId = 2
                        },
                         new Song_Concert()
                        {
                            SongId = 4,
                            ConcertId = 2
                        },

                        new Song_Concert()
                        {
                            SongId = 1,
                            ConcertId = 3
                        },
                        new Song_Concert()
                        {
                            SongId = 2,
                            ConcertId = 3
                        },
                        new Song_Concert()
                        {
                            SongId = 5,
                            ConcertId = 3
                        },


                        new Song_Concert()
                        {
                            SongId = 2,
                            ConcertId = 4
                        },
                        new Song_Concert()
                        {
                            SongId = 3,
                            ConcertId = 4
                        },
                        new Song_Concert()
                        {
                            SongId = 4,
                            ConcertId = 4
                        },


                        new Song_Concert()
                        {
                            SongId = 2,
                            ConcertId = 5
                        },
                        new Song_Concert()
                        {
                            SongId = 3,
                            ConcertId = 5
                        },
                        new Song_Concert()
                        {
                            SongId = 4,
                            ConcertId = 5
                        },
                        new Song_Concert()
                        {
                            SongId = 1,
                            ConcertId = 5
                        },


                        new Song_Concert()
                        {
                            SongId = 3,
                            ConcertId = 3
                        },
                        new Song_Concert()
                        {
                            SongId = 4,
                            ConcertId = 6
                        },
                        new Song_Concert()
                        {
                            SongId = 5,
                            ConcertId = 6
                        },
                    });
                    context.SaveChanges();
                }
            }

        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@etickets.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}

