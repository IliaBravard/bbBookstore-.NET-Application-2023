using bbBookstore.Data.Static;
using bbBookstore.Models;
using Microsoft.AspNetCore.Identity;

namespace bbBookstore.Data
{
    public class ApplicationDbInitializer
    {
        public static void Seed(IApplicationBuilder appBuilder)
        {
            using (var serviceScope = appBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                // Authors
                if (!context.Authors.Any())
                {
                    context.Authors.AddRange(new List<Author>() {
                        new Author()
                        {
                            ProfileImage = "http://pics.cdn.librarything.com//picsizes/5a/6b/5a6b2518a66774a654d323068414463414e7741_v5.jpg",
                            FirstName = "Taylor",
                            LastName = "Jenkins",
                            Background = "Taylor Jenkins Reid is an author, essayist, and TV writer. Her debut novel, Forever, Interrupted, has been optioned with Dakota Johnson attached to star. She is adapting her second book, After I Do, for ABC Family. Her most recent novel, Maybe In Another Life has become a best-selling e-book. In addition to her novels, Taylor's essays have appeared in the Los Angeles Times, The Huffington Post, and a number of other publications.",
                        },

                        new Author()
                        {
                            ProfileImage = "https://th.bing.com/th/id/OIP.ndvaVbB0E7WCoENd8kefKAHaHf?pid=ImgDet&rs=1",
                            FirstName = "Emily",
                            LastName = "Henry",
                            Background = "Emily Henry studied creative writing at Hope College and the New York Center for Art and Media Studies. She is a full-time writer and proofreader. Her first book, The Love That Split the World, was published in 2016."
                        },

                        new Author()
                        {
                            ProfileImage = "https://th.bing.com/th/id/R.c1301d8877c794c836c798bbdf8f6865?rik=VT75hyvl4OEEUA&riu=http%3a%2f%2fwww.laurellkhamilton.com%2fwp-content%2fuploads%2f2015%2f03%2fLaurell.jpg&ehk=ZmzAMfNa5ZbiTXcE1NvXFSROH%2bO66QVPiw1AuJGwGVw%3d&risl=&pid=ImgRaw&r=0",
                            FirstName = "Laurell",
                            LastName = "Hamilton",
                            Background = "Laurell K. Hamilton was born in Heber Springs, Arkansas on February 19, 1963. She received degrees in English and biology from Marion College, which is now Indiana Wesleyan University. She writes the Anita Blake: Vampire Hunter series and the Meredith Gentry series."
                        },
                    });
                    context.SaveChanges();
                }

                // Publishers
                if (!context.Publishers.Any())
                {
                    context.Publishers.AddRange(new List<Publisher>() {
                        new Publisher()
                        {
                            Name = "Atria Books",
                            Country = "USA",
                            Year = 2017
                        },

                        new Publisher()
                        {
                            Name = "Jove",
                            Country = "USA",
                            Year = 2021
                        },

                        new Publisher()
                        {
                            Name = "Berkley Books",
                            Country = "USA",
                            Year = 2023
                        }
                    });
                    context.SaveChanges();
                }

                // Books
                if (!context.Books.Any())
                {
                    context.Books.AddRange(new List<Book>() {
                        new Book()
                        {
                            BookTitle = "The Seven Husbands of Evelyn Hugo",
                            Review = "A spellbinding novel about love, glamour, and the price of fame - Emily Giffin",
                            Description = "Aging and reclusive Hollywood movie icon Evelyn Hugo is finally ready to tell the truth about her glamorous and scandalous life. But when she chooses unknown magazine reporter Monique Grant for the job, no one in the journalism community is more astounded than Monique herself. Summoned to Evelyn's Upper East Side apartment, Monique listens as Evelyn unfurls her story: from making her way to Los Angeles in the 1950s to her decision to leave show business in the late 80s, and, of course, the seven husbands along the way. As Evelyn's life unfolds, Monique begins to feel a very a real connection to the actress. But as Evelyn's story catches up with the present, it becomes clear that her life intersects with Monique's own in tragic and irreversible ways.",
                            Price = 20.80,
                            BookImage = "https://secure.syndetics.com/index.aspx?isbn=9781501139239/mc.gif&upc=&client=amesvega&type=unbound",
                            BookGenre = Enums.Genre.Fiction,
                            NumOfPages = 389,
                            ISBN = "9781508236627",
                            PublisherId = 1,
                            AuthorId = 1
                        },

                        new Book()
                        {
                            BookTitle = "People We Meet on Vacation",
                            Review = "The perfect getaway - Jodi Picoult",
                            Description = "When Poppy met Alex, there was no spark, no chemistry, and no reason to think they'd ever talk again. Alex is quiet, studious, and destined for a future in academia. Poppy is a wild child who only came to U of Chicago to escape small-town life. But after sharing a ride home for the summer, the two form a surprising friendship. After all, who better to confide in than someone you could never, ever date? Over the years, Alex and Poppy's lives take them in different directions, but every summer the two find their way back to each other for a magical week long vacation. Until one trip goes awry, and in the fallout, they lose touch. Now, two years later, Poppy's in a rut. Her dream job, her relationships, her life - none of it is making her happy. In fact, the last time she remembers feeling truly happy was on that final, ill-fated Summer Trip. The answer to all her problems is obvious: She needs one last vacation to win back her best friend. As a hilariously disastrous week unfolds and tensions rise, Poppy and Alex are forced to confront what drove them apart - and decide what they're willing to risk for the chance to be together.",
                            Price = 9.50,
                            BookImage = "https://secure.syndetics.com/index.aspx?isbn=9781984806758/mc.gif&upc=&client=amesvega&type=unbound",
                            BookGenre = Enums.Genre.Comedy,
                            NumOfPages = 364,
                            ISBN = "9781984806758",
                            PublisherId = 2,
                            AuthorId = 2
                        },

                        new Book()
                        {
                            BookTitle = "Smolder #29",
                            Review = "Hamilton remains one of the most inventive writers - Charlaine Harris",
                            Description = "The wedding of the century between vampire hunter Anita Blake and the vampire king of America Jean-Claude is almost here, but an ancient evil arrives in St. Louis and even Jean-Claude's unmatched power isn't enough to save them. Only with the return of a lost love can they hope to combat the monster and save their loved ones and every vampire in the country from being consumed by darkness.",
                            Price = 18.76,
                            BookImage = "https://secure.syndetics.com/index.aspx?isbn=9781984804495/mc.gif&upc=&client=amesvega&type=unbound",
                            BookGenre = Enums.Genre.Fantasy,
                            NumOfPages = 372,
                            ISBN = "9781984804495",
                            PublisherId = 3,
                            AuthorId = 3
                        }
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                }

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
                }

                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@bbbookstore.com";
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
                    await userManager.CreateAsync(newAdminUser, "FinalProject@2023_?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "user@bbbookstore.com";
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
                    await userManager.CreateAsync(newAppUser, "FinalProject@2023_?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}