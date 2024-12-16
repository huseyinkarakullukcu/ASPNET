using MovieApp.Models;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MovieApp.Data
{
    public class MovieRepository
    {
        private static readonly List<Movie> _movies = null;
         static MovieRepository()
        {
            _movies = new List<Movie>()
            {
                new Movie {
                    Id=1,
                    Title= "Avatar",
                    Description= "Years after a plague kills most of humanity and transforms the rest into monsters, the sole survivor in New York City struggles valiantly to find a cure.",
                    GenreId= 1,
                    Director= "James Cameron",
                    Image= "https://ia.media-imdb.com/images/M/MV5BMTYwOTEwNjAzMl5BMl5BanBnXkFtZTcwODc5MTUwMw@@._V1_SX300.jpg",
                    Players= ["Sam Worthington", "Zoe Saldana", "Sigourney Weaver", "Stephen Lang"]
                },
                new Movie {
                    Id=2,
                    Title= "I Am Legend",
                    Description= "Years after a plague kills most of humanity and transforms the rest into monsters, the sole survivor in New York City struggles valiantly to find a cure.",
                    GenreId= 2,
                    Director= "Francis Lawrence",
                    Image= "https://images-na.ssl-images-amazon.com/images/M/MV5BMTA0MTI2NjMzMzFeQTJeQWpwZ15BbWU2MDMwNDc3OA@@._V1_.jpg",
                    Players= ["Will Smith", "Alice Braga", "Charlie Tahan", "Salli Richardson-Whitfield"]
                },
                new Movie {
                    Id=3,
                    Title= "300",
                    Description= "King Leonidas of Sparta and a force of 300 men fight the Persians at Thermopylae in 480 B.C.",
                    GenreId= 4,
                    Director= "Zack Snyder",
                    Image= "https://ia.media-imdb.com/images/M/MV5BMjAzNTkzNjcxNl5BMl5BanBnXkFtZTYwNDA4NjE3._V1_SX300.jpg",
                    Players= ["Gerard Butler", "Lena Headey", "Dominic West", "David Wenham"]
                },
                new Movie {
                    Id=4,
                    Title= "The Avengers",
                    Description= "Earth's mightiest heroes must come together and learn to fight as a team if they are to stop the mischievous Loki and his alien army from enslaving humanity.",
                    GenreId= 4,
                    Director= "Joss Whedon",
                    Image= "https://ia.media-imdb.com/images/M/MV5BMTk2NTI1MTU4N15BMl5BanBnXkFtZTcwODg0OTY0Nw@@._V1_SX300.jpg",
                    Players= ["Robert Downey Jr.", "Chris Evans", "Mark Ruffalo", "Chris Hemsworth"]
                },
                new Movie {
                    Id=5,
                    Title= "Avatar",
                    Description= "Years after a plague kills most of humanity and transforms the rest into monsters, the sole survivor in New York City struggles valiantly to find a cure.",
                    GenreId= 1,
                    Director= "James Cameron",
                    Image= "https://ia.media-imdb.com/images/M/MV5BMTYwOTEwNjAzMl5BMl5BanBnXkFtZTcwODc5MTUwMw@@._V1_SX300.jpg",
                    Players= ["Sam Worthington", "Zoe Saldana", "Sigourney Weaver", "Stephen Lang"]
                },
                new Movie {
                    Id=6,
                    Title= "The Wolf of Wall Street",
                    Description= "Based on the true story of Jordan Belfort, from his rise to a wealthy stock-broker living the high life to his fall involving crime, corruption and the federal government.",
                    GenreId= 5,
                    Director= "Martin Scorsese",
                    Image= "https://ia.media-imdb.com/images/M/MV5BMjIxMjgxNTk0MF5BMl5BanBnXkFtZTgwNjIyOTg2MDE@._V1_SX300.jpg",
                    Players= ["Ellen Burstyn", "Matthew McConaughey", "Mackenzie Foy", "John Lithgow"]
                },
                new Movie {
                    Id=7,
                    Title= "Interstellar",
                    Description= "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.",
                    GenreId= 1,
                    Director= "Christopher Nolan",
                    Image= "https://ia.media-imdb.com/images/M/MV5BMjIxNTU4MzY4MF5BMl5BanBnXkFtZTgwMzM4ODI3MjE@._V1_SX300.jpg",
                    Players= ["Peter Dinklage", "Lena Headey", "Emilia Clarke", "Kit Harington"]
                },
                new Movie {
                    Id=8,
                    Title= "Game of Thrones",
                    Description= "While a civil war brews between several noble families in Westeros, the children of the former rulers of the land attempt to rise up to power. Meanwhile a forgotten race, bent on destruction, plans to return after thousands of years in the North.",
                    GenreId= 2,
                    Director= "Michael Hirst",
                    Image= "https://ia.media-imdb.com/images/M/MV5BMjM5OTQ1MTY5Nl5BMl5BanBnXkFtZTgwMjM3NzMxODE@._V1_SX300.jpg",
                    Players= ["Travis Fimmel", "Clive Standen", "Gustaf Skarsgård", "Katheryn Winnick"]
                },
                new Movie {
                    Id=9,
                    Title= "Vikings",
                    Description= "The world of the Vikings is brought to life through the journey of Ragnar Lothbrok, the first Viking to emerge from Norse legend and onto the pages of history - a man on the edge of myth.",
                    GenreId= 2,
                    Director= "N/A",
                    Image= "https://ia.media-imdb.com/images/M/MV5BOTEzNzI3MDc0N15BMl5BanBnXkFtZTgwMzk1MzA5NzE@._V1_SX300.jpg",
                    Players= ["Omari Hardwick", "Joseph Sikora", "Andy Bean", "Lela Loren"]
                },
                new Movie {
                    Id=10,
                    Title= "Gotham",
                    Description= "The story behind Detective James Gordon's rise to prominence in Gotham City in the years before Batman's arrival.",
                    GenreId= 4,
                    Director= "N/A",
                    Image= "https://ia.media-imdb.com/images/M/MV5BMTY2MjMwNDE4OV5BMl5BanBnXkFtZTgwNjI1NjU0OTE@._V1_SX300.jpg",
                    Players= ["Wagner Moura", "Boyd Holbrook", "Pedro Pascal", "Joanna Christie"]
                },
                new Movie {
                    Id=11,
                    Title= "Power",
                    Description= "James \"Ghost\" St. Patrick, a wealthy New York night club owner who has it all, catering for the city's elite and dreaming big, lives a double life as a drug kingpin.",
                    GenreId= 5,
                    Director= "Courtney Kemp Agboh",
                    Image= "https://ia.media-imdb.com/images/M/MV5BOTA4NTkzMjUzOF5BMl5BanBnXkFtZTgwNzg5ODkxOTE@._V1_SX300.jpg",
                    Players= ["Omari Hardwick", "Joseph Sikora", "Andy Bean", "Lela Loren"]
                },
                new Movie {
                    Id=12,
                    Title= "Avatar",
                    Description= "Years after a plague kills most of humanity and transforms the rest into monsters, the sole survivor in New York City struggles valiantly to find a cure.",
                    GenreId= 1,
                    Director= "James Cameron",
                    Image= "https://ia.media-imdb.com/images/M/MV5BMTYwOTEwNjAzMl5BMl5BanBnXkFtZTcwODc5MTUwMw@@._V1_SX300.jpg",
                    Players= ["Sam Worthington", "Zoe Saldana", "Sigourney Weaver", "Stephen Lang"]
                },
                new Movie {
                    Id=13,
                    Title= "Narcos",
                    Description= "A chronicled look at the criminal exploits of Colombian drug lord Pablo Escobar.",
                    GenreId= 5,
                    Director= "Carlo Bernard, Chris Brancato, Doug Miro, Paul Eckstein",
                    Image= "https://ia.media-imdb.com/images/M/MV5BMTU0ODQ4NDg2OF5BMl5BanBnXkFtZTgwNzczNTE4OTE@._V1_SX300.jpg",
                    Players= ["Wagner Moura", "Boyd Holbrook", "Pedro Pascal", "Joanna Christie"]
                },
                new Movie {
                    Id=14,
                    Title= "Doctor Strange",
                    Description= "After his career is destroyed, a brilliant but arrogant and conceited surgeon gets a new lease on life when a sorcerer takes him under her wing and trains him to defend the world against evil.",
                    GenreId= 5,
                    Director= "Scott Derrickson",
                    Image= "https://ia.media-imdb.com/images/M/MV5BNjgwNzAzNjk1Nl5BMl5BanBnXkFtZTgwMzQ2NjI1OTE@._V1_SX300.jpg",
                    Players= ["Rachel McAdams", "Benedict Cumberbatch", "Mads Mikkelsen", "Tilda Swinton"]
                },
                new Movie {
                    Id=15,
                    Title= "Rogue One= A Star Wars Story",
                    Description= "The Rebellion makes a risky move to steal the plans to the Death Star, setting up the epic saga to follow.",
                    GenreId= 6,
                    Director= "Gareth Edwards",
                    Image= "https://images-na.ssl-images-amazon.com/images/M/MV5BMjQyMzI2OTA3OF5BMl5BanBnXkFtZTgwNDg5NjQ0OTE@._V1_SY1000_CR0,0,674,1000_AL_.jpg",
                    Players= ["Felicity Jones", "Riz Ahmed", "Mads Mikkelsen", "Ben Mendelsohn"]
                },
                new Movie {
                    Id=16,
                    Title= "Assassin's Creed",
                    Description= "When Callum Lynch explores the memories of his ancestor Aguilar and gains the skills of a Master Assassin, he discovers he is a descendant of the secret Assassins society.",
                    GenreId= 2,
                    Director= "Justin Kurzel",
                    Image= "https://ia.media-imdb.com/images/M/MV5BMTU2MTQwMjU1OF5BMl5BanBnXkFtZTgwMDA5NjU5ODE@._V1_SX300.jpg",
                    Players= ["Michael Fassbender", "Michael Kenneth Williams", "Marion Cotillard", "Jeremy Irons"]
                },
                new Movie {
                    Id=17,
                    Title= "Luke Cage",
                    Description= "Given superstrength and durability by a sabotaged experiment, a wrongly accused man escapes prison to become a superhero for hire.",
                    GenreId= 6,
                    Director= "Cheo Hodari Coker",
                    Image= "https://ia.media-imdb.com/images/M/MV5BMTcyMzc1MjI5MF5BMl5BanBnXkFtZTgwMzE4ODY2OTE@._V1_SX300.jpg",
                    Players= ["Mahershala Ali", "Mike Colter", "Frankie Faison", "Erik LaRay Harvey"]
                },
            };
        }
        public static List<Movie> GetMovies
        {
            get {  return _movies; }
        }
        public static void AddMovie(Movie movie)
        {
            movie.Id = _movies.Count() + 1;
            movie.Players = ["Oyuncu 1", "Oyuncu 2"];
            _movies.Add(movie);
        }

        public static Movie GetById(int id)
        {
            return _movies.FirstOrDefault(x => x.Id == id);
        }

        public static void EditMovie(Movie model)
        {
            foreach (var movie in _movies)
            {
                if(movie.Id == model.Id)
                {
                    movie.Title = model.Title;
                    movie.Description = model.Description;
                    movie.Director = model.Director;
                    movie.Image = model.Image;
                    movie.Players = model.Players;
                    movie.GenreId = model.GenreId;
                    break;
                }
            }
        }

        public static void MovieDelete(int movieId)
        {
            var movie = GetById(movieId);
            if(movie !=null)
            {
                _movies.Remove(movie);
            }
        }
    }
}
