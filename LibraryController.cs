using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryGenerator.Controllers;

namespace LibraryGenerator
{
    public class LibraryController
    {
        public Library Library { get; set; }
        public PeopleController PeopleController { get; set; }
       
        public LibraryController(PeopleController peopleController)
        {
           
            PeopleController = peopleController;
            Library = new Library(this);
        }
    }
}

  
