using I3.WAD21.MyFirstMVC.Models;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I3.WAD21.MyFirstMVC.Handlers
{
    public class SessionManager
    {
        private readonly ISession _session;
        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
        }

        public int? ValeurInt {
            get {
                return _session.GetInt32("ValeurInt");
            }
            set {
                _session.SetInt32("ValeurInt", value.Value);
            } 
        }

        public string ValeurText
        {
            get {
                return _session.GetString("ValeurText");
            }
            set {
                _session.SetString("ValeurText", value);
            }
        }

        public byte[] MonTableauDeByte
        {
            get {
                return _session.Get("MonTableauDeByte");
            }
            set {
                _session.Set("MonTableauDeByte", value);
            }
        }

        public IEnumerable<Movie> FavoriteMovies
        {
            get {
                if (_session.GetString(nameof(FavoriteMovies)) is null)
                    FavoriteMovies = new List<Movie>();
                return JsonSerializer.Deserialize<Movie[]>(_session.GetString(nameof(FavoriteMovies)));
            }
            set {
                _session.SetString(nameof(FavoriteMovies), JsonSerializer.Serialize(value));
            }
        }

        public bool IsConnected { get { return _session.GetString("user") != null; } }

        public void AddMovie(Movie movie)
        {
            List<Movie> movies = new List<Movie>(FavoriteMovies);
            movies.Add(movie);
            FavoriteMovies = movies;
        }

        public void SetUser(LoginForm form)
        {
            _session.SetString("user", form.Email);
        }
    }
}
