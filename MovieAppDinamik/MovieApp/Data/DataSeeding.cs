using Microsoft.EntityFrameworkCore;
using MovieApp.Entity;

namespace MovieApp.Data
{
    public static class DataSeeding
    {
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<MovieContext>();

            context.Database.Migrate(); //dotnet ef database update
            var genres = new List<Genre>()
                     {
                        new Genre { Name = "Macera", Movies=
                            new List<Movie>()
                            {
                                new Movie
                                {
                                    Title = "New Adventure movie 1",
                                    Description = "Years after a plague kills most of humanity and transforms the rest into monsters, the sole survivor in New York City struggles valiantly to find a cure.",
                                    Image = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTA0MTI2NjMzMzFeQTJeQWpwZ15BbWU2MDMwNDc3OA@@._V1_.jpg",
                                },
                                new Movie
                                {
                                    Title = "New Adventure movie 2",
                                    Description = "King Leonidas of Sparta and a force of 300 men fight the Persians at Thermopylae in 480 B.C.",
                                    Image = "https://ia.media-imdb.com/images/M/MV5BMjAzNTkzNjcxNl5BMl5BanBnXkFtZTYwNDA4NjE3._V1_SX300.jpg",
                                },
                            }
                        },
                        new Genre { Name = "Komedi" },
                        new Genre { Name = "Korku" },
                        new Genre { Name = "Drama" },
                        new Genre { Name = "Suç" },
                        new Genre { Name = "Aksiyon" }
                    };

            var movies = new List<Movie>()
                        {
                            new Movie
                            {
                                Title = "Avatar",
                                Description = "Years after a plague kills most of humanity and transforms the rest into monsters, the sole survivor in New York City struggles valiantly to find a cure.",
                                Genre = genres[0],
                                Image = "https://ia.media-imdb.com/images/M/MV5BMTYwOTEwNjAzMl5BMl5BanBnXkFtZTcwODc5MTUwMw@@._V1_SX300.jpg",
                            },
                            new Movie
                            {
                                Title = "I Am Legend",
                                Description = "Years after a plague kills most of humanity and transforms the rest into monsters, the sole survivor in New York City struggles valiantly to find a cure.",
                                Genre = genres[0],
                                Image = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTA0MTI2NjMzMzFeQTJeQWpwZ15BbWU2MDMwNDc3OA@@._V1_.jpg",
                            },
                            new Movie
                            {
                                Title = "300",
                                Description = "King Leonidas of Sparta and a force of 300 men fight the Persians at Thermopylae in 480 B.C.",
                                Genre = genres[0],
                                Image = "https://ia.media-imdb.com/images/M/MV5BMjAzNTkzNjcxNl5BMl5BanBnXkFtZTYwNDA4NjE3._V1_SX300.jpg",
                            },
                            new Movie
                            {
                                Title = "The Avengers",
                                Description = "Earth's mightiest heroes must come together and learn to fight as a team if they are to stop the mischievous Loki and his alien army from enslaving humanity.",
                                Genre = genres[1],
                                Image = "https://ia.media-imdb.com/images/M/MV5BMTk2NTI1MTU4N15BMl5BanBnXkFtZTcwODg0OTY0Nw@@._V1_SX300.jpg",
                            },
                            new Movie
                            {
                                Title = "Avatar",
                                Description = "Years after a plague kills most of humanity and transforms the rest into monsters, the sole survivor in New York City struggles valiantly to find a cure.",
                                Genre = genres[1],
                                Image = "https://ia.media-imdb.com/images/M/MV5BMTYwOTEwNjAzMl5BMl5BanBnXkFtZTcwODc5MTUwMw@@._V1_SX300.jpg",
                            },
                            new Movie
                            {
                                Title = "The Wolf of Wall Street",
                                Description = "Based on the true story of Jordan Belfort, from his rise to a wealthy stock-broker living the high life to his fall involving crime, corruption and the federal government.",
                                Genre = genres[1],
                                Image = "https://ia.media-imdb.com/images/M/MV5BMjIxMjgxNTk0MF5BMl5BanBnXkFtZTgwNjIyOTg2MDE@._V1_SX300.jpg",
                            },
                            new Movie
                            {
                                Title = "Interstellar",
                                Description = "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.",
                                Genre = genres[3],
                                Image = "https://ia.media-imdb.com/images/M/MV5BMjIxNTU4MzY4MF5BMl5BanBnXkFtZTgwMzM4ODI3MjE@._V1_SX300.jpg",
                            },
                            new Movie
                            {
                                Title = "Game of Thrones",
                                Description = "While a civil war brews between several noble families in Westeros, the children of the former rulers of the land attempt to rise up to power. Meanwhile a forgotten race, bent on destruction, plans to return after thousands of years in the North.",
                                Genre = genres[4],
                                Image = "https://ia.media-imdb.com/images/M/MV5BMjM5OTQ1MTY5Nl5BMl5BanBnXkFtZTgwMjM3NzMxODE@._V1_SX300.jpg",
                            },
                            new Movie
                            {
                                Title = "Vikings",
                                Description = "The world of the Vikings is brought to life through the journey of Ragnar Lothbrok, the first Viking to emerge from Norse legend and onto the pages of history - a man on the edge of myth.",
                                Genre = genres[3],
                                Image = "https://ia.media-imdb.com/images/M/MV5BOTEzNzI3MDc0N15BMl5BanBnXkFtZTgwMzk1MzA5NzE@._V1_SX300.jpg",
                            },
                            new Movie
                            {
                                Title = "Gotham",
                                Description = "The story behind Detective James Gordon's rise to prominence in Gotham City in the years before Batman's arrival.",
                                Genre = genres[4],
                                Image = "https://ia.media-imdb.com/images/M/MV5BMTY2MjMwNDE4OV5BMl5BanBnXkFtZTgwNjI1NjU0OTE@._V1_SX300.jpg",
                            },
                            new Movie
                            {
                                Title = "Power",
                                Description = "James \"Ghost\" St. Patrick, a wealthy New York night club owner who has it all, catering for the city's elite and dreaming big, lives a double life as a drug kingpin.",
                                Genre = genres[4],
                                Image = "https://ia.media-imdb.com/images/M/MV5BOTA4NTkzMjUzOF5BMl5BanBnXkFtZTgwNzg5ODkxOTE@._V1_SX300.jpg",
                            },
                            new Movie
                            {
                                Title = "Avatar",
                                Description = "Years after a plague kills most of humanity and transforms the rest into monsters, the sole survivor in New York City struggles valiantly to find a cure.",
                                Genre = genres[5],
                                Image = "https://ia.media-imdb.com/images/M/MV5BMTYwOTEwNjAzMl5BMl5BanBnXkFtZTcwODc5MTUwMw@@._V1_SX300.jpg",
                            },
                            new Movie
                            {
                                Title = "Narcos",
                                Description = "A chronicled look at the criminal exploits of Colombian drug lord Pablo Escobar.",
                                Genre = genres[5],
                                Image = "https://ia.media-imdb.com/images/M/MV5BMTU0ODQ4NDg2OF5BMl5BanBnXkFtZTgwNzczNTE4OTE@._V1_SX300.jpg",
                            },
                            new Movie
                            {
                                Title = "Doctor Strange",
                                Description = "After his career is destroyed, a brilliant but arrogant and conceited surgeon gets a new lease on life when a sorcerer takes him under her wing and trains him to defend the world against evil.",
                                Genre = genres[5],
                                Image = "https://ia.media-imdb.com/images/M/MV5BNjgwNzAzNjk1Nl5BMl5BanBnXkFtZTgwMzQ2NjI1OTE@._V1_SX300.jpg",
                            },
                            new Movie
                            {
                                Title = "Rogue One= A Star Wars Story",
                                Description = "The Rebellion makes a risky move to steal the plans to the Death Star, setting up the epic saga to follow.",
                                Genre = genres[4],
                                Image = "https://images-na.ssl-images-amazon.com/images/M/MV5BMjQyMzI2OTA3OF5BMl5BanBnXkFtZTgwNDg5NjQ0OTE@._V1_SY1000_CR0,0,674,1000_AL_.jpg",
                            },
                            new Movie
                            {
                                Title = "Assassin's Creed",
                                Description = "When Callum Lynch explores the memories of his ancestor Aguilar and gains the skills of a Master Assassin, he discovers he is a descendant of the secret Assassins society.",
                                Genre = genres[3],
                                Image = "https://ia.media-imdb.com/images/M/MV5BMTU2MTQwMjU1OF5BMl5BanBnXkFtZTgwMDA5NjU5ODE@._V1_SX300.jpg",
                            },
                            new Movie
                            {
                                Title = "Luke Cage",
                                Description = "Given superstrength and durability by a sabotaged experiment, a wrongly accused man escapes prison to become a superhero for hire.",
                                Genre = genres[4],
                                Image = "https://ia.media-imdb.com/images/M/MV5BMTcyMzc1MjI5MF5BMl5BanBnXkFtZTgwMzE4ODY2OTE@._V1_SX300.jpg",
                            }
                        };

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Genres.Count() == 0)
                {
                    context.Genres.AddRange(genres);
                }
                if (context.Movies.Count() == 0) 
                {
                    context.Movies.AddRange(movies);
                }
                context.SaveChanges();
            }

        }
    }
}
