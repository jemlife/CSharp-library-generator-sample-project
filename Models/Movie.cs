using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryGenerator.Controllers;
using Newtonsoft.Json;

namespace LibraryGenerator
{
    [Serializable]
    public class Movie : ILibraryItem
    {
       
        public int Id { get; set; }
        public string Title { get; set; }             
        public string Writer { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Director { get; set; }


        
        public Movie()
        {
           
           
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
