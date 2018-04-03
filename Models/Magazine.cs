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
    public class Magazine : ILibraryItem
    {
       
        public int Id { get; set; }
        public string Publisher { get; set; }
        public string Title { get; set; }
        public string Writer { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Volume { get; set; }

      
        public Magazine()
        {
           
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
