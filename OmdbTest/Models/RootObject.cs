using System.Collections.Generic;

namespace OmdbTest.Models
{
    [System.Serializable]
    public class RootObject
    {
    //  public List<Movie> Movies { get; set; }  
        
    //}
    //public class Movie
    //{
        public string Title { get; set; }
        public string Year { get; set; }
        public string Rated { get; set; }
        public string Genre { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }
        public string imdbID { get; set; }
    }
}
