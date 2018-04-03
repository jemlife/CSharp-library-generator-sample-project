using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryGenerator.Controllers
{
    public class MovieController : IController
    {
        public LibraryController LibraryController { get; set; }
        public Movie Movie { get; set; }



        public MovieController(LibraryController libraryController)
        {
            LibraryController = libraryController;
          
        }

        public void MovieModificationMenu()
        {
            Console.WriteLine("What would you like to modify in your movie list?");
            Console.WriteLine("1- Add a movie");
            Console.WriteLine("2- Delete a movie");
            Console.WriteLine("3- List movies");
            Console.WriteLine("4- Back to Main menu");
        }

        public void AddLogic()
        {
            ItemInput();

            var containsMovie = PeopleController.Person.Library.Movies.GetLibraryItem(Movie.Title);

            //bool containsMovie =
            //    PeopleController.Person.Library.Movies.Any(
            //        per => per.Title == Movie.Title);
            if (!containsMovie)
            {

                AddObject(Movie);


            }

            else
            {
                Console.WriteLine("Movie already exists!");
                Console.WriteLine();

            }
        }

        public void DeleteLogic()
        {
            Console.WriteLine("Enter movie title:");
            Movie.Title = Console.ReadLine();

            var containsMovie = PeopleController.Person.Library.Movies.GetLibraryItem(Movie.Title);
            //bool containsMovie =
            //    PeopleController.Person.Library.Movies.Any(
            //        per => per.Title == Movie.Title);
            if (containsMovie)
            {
                DeleteObject(Movie);

            }

            else
            {
                Console.WriteLine("Movie doesn't exist!");
            }
        }

        public void ViewLogic()
        {

            if (!PeopleController.Person.Library.Movies.Any())
            {
                Console.WriteLine("There aren't any movies!");
            }

            else
            {
                ListLibraryItem(Movie);
                Console.WriteLine();
            }
        }

        public void ItemInput()
        {
            Console.WriteLine("Enter title of movie");
            Movie = new Movie();
            Movie.Title = Console.ReadLine();

            Console.WriteLine("Enter director of movie");
            Movie.Director = Console.ReadLine();

            Console.WriteLine("Enter release date of movie");
            Movie.ReleaseDate = new DateTime(Convert.ToInt32(Console.ReadLine()));
        }

        public void AddObject(ILibraryItem item)
        {
            if (item.Title != string.Empty) PeopleController.Person.Library.Movies.AddLibraryItem(Movie);
            else
                Console.WriteLine("Movie title is required!");

        }

        public void DeleteObject(ILibraryItem item)
        {
            PeopleController.Person.Library.Movies.DeleteLibraryItem(item.Title);
        }

        public IEnumerable<ILibraryItem> ListLibraryItem(ILibraryItem item)
        {
            foreach (var mov in PeopleController.Person.Library.Movies)
            {
                Console.WriteLine("Movies: ");
                Console.WriteLine("Title: {0} ", item.Title);
                Console.WriteLine("Director: {0} ", mov.Director);
                Console.WriteLine("Release Date: {0} ", item.ReleaseDate);

            }
            return PeopleController.Person.Library.Movies;
        }
    }
}
