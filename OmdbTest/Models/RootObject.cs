using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OmdbTest.Models
{
    [System.Serializable]
    public class RootObject
    {
        //  public list<movie> movies { get; set; }  

        //}
        //public class movie
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
