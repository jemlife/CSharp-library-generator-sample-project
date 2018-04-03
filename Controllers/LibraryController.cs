using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryGenerator.Controllers;
using Newtonsoft.Json;


namespace LibraryGenerator
{

    public class LibraryController
    {

        public PeopleController PeopleController { get; set; }
        public BooksController BookController { get; set; }
        public MagazineController MagazineController { get; set; }
        public MovieController MovieController { get; set; }
        public Library Library { get; set; }



        public LibraryController(PeopleController peopleController)
        {

            PeopleController = peopleController;
            BookController = new BooksController(this);
            MagazineController = new MagazineController(this);
            MovieController = new MovieController(this);
           
          


        }

        public void DeleteLibrary(Book book, Movie movie, Magazine magazine)
        {

            Console.WriteLine("Please enter name of person:");
            PeopleController.Person.Name = Console.ReadLine();

            bool containsName =
                PeopleController.People
                    .Any(p => p.Name == PeopleController.Person.Name);
            if (containsName)
            {
                bool confirmed = false;
                string Key;
                ConsoleKey response;


                Console.WriteLine(
                    "Are you sure you want to delete this library? [y/n]");
                response = Console.ReadKey(false).Key;

                if (response != ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    DeleteLogic(book, movie, magazine);

                }
            }

            else
            {

                Console.WriteLine("This user doesn't exist!");
                LibraryMenu();

            }

        }

        public void DeleteLogic(Book book, Movie movie, Magazine magazine)
        {
            PeopleController.Person.Library.Books.Remove(book);
            PeopleController.Person.Library.Movies.Remove(movie);
            PeopleController.Person.Library.Magazines.Remove(magazine);
        }

        public void ListLibrary(Library library)
        {
            foreach (var b in PeopleController.Person.Library.Books)
            {

                Console.WriteLine("Books: ");
                Console.WriteLine("Id: {0} ", b.BookId);
                Console.WriteLine("Title: {0} ", b.Title);
                Console.WriteLine("Author: {0} ", b.Author);
                Console.WriteLine("Publisher: {0} ", b.Publisher);
                Console.WriteLine("Published: {0} ", b.Published);

            }
            foreach (var mov in PeopleController.Person.Library.Movies)
            {
                Console.WriteLine("Movies: ");
                Console.WriteLine("Title: {0} ", mov.Title);
                Console.WriteLine("Director: {0} ", mov.Director);
                Console.WriteLine("Release Date: {0} ", mov.ReleaseDate);


            }
            foreach (var mag in PeopleController.Person.Library.Magazines)
            {
                Console.WriteLine("Magazines: ");
                Console.WriteLine("Title: {0} ", mag.Title);
                Console.WriteLine("Writer: {0} ", mag.Writer);
                Console.WriteLine("Publisher: {0} ", mag.Publisher);
                Console.WriteLine("Volume: {0} ", mag.Volume);

            }
            
        }

        public void ViewLogic()
        {

            Console.WriteLine("Please enter name of person:");
            PeopleController.Person.Name = Console.ReadLine();

            bool containsName =
                PeopleController.People
                    .Any(x => x.Name == PeopleController.Person.Name);
            if (containsName)
            {
                if (PeopleController.Person.Library.Books.Count == 0 && PeopleController.Person.Library.Movies.Count == 0 && PeopleController.Person.Library.Magazines.Count == 0)
                {
                    Console.WriteLine("This person's library is empty!");
                }

                else
                {

                    PeopleController.LibraryController.ListLibrary(Library);
                    Console.WriteLine();

                }

            }
        }

        public void LibraryMenu()
        {

            Console.WriteLine();
            Console.WriteLine("Library");
            Console.WriteLine();
            Console.WriteLine("What would you like to modify in your libraries?");
            Console.WriteLine("1- Modify a library");
            Console.WriteLine("2- Delete a library");
            Console.WriteLine("3- View a library");
            Console.WriteLine("4- Back to Main menu");

        }

        public void LibraryModificationMenu()
        {

            Console.WriteLine("What Section would you like to modify?");
            Console.WriteLine("1- Books");
            Console.WriteLine("2- Magazines");
            Console.WriteLine("3- Movies");

        }

       
    }
}


