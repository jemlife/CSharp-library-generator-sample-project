using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using LibraryGenerator.Controllers;

namespace LibraryGenerator
{
    public class BooksController : IController
    {

        public LibraryController LibraryController { get; set; }
        public Book Book { get; set; }

      

        public BooksController(LibraryController libraryController)
        {

            LibraryController = libraryController;
        }

        public void BookModificationMenu()
        {
            Console.WriteLine("What would you like to modify in your book list?");
            Console.WriteLine("1- Add a book");
            Console.WriteLine("2- Delete a book");
            Console.WriteLine("3- List books");
            Console.WriteLine("4- Back to Main menu");

        }

        public void AddLogic()
        {
            ItemInput();

            var containsBook = PeopleController.Person.Library.Books.GetLibraryItem(Book.Title);
            //PeopleController.Person.Library.Books.Any(
            //    per => per.Title == Book.Title);
            if (!containsBook)
            {

                AddObject(Book);

            }

            else
            {
                Console.WriteLine("Book already exists!");
                Console.WriteLine();


            }
        }

        public void DeleteLogic()
        {
            Console.WriteLine("Enter book title:");
            Book = new Book();
            Book.Title = Console.ReadLine();

            var containsBook = PeopleController.Person.Library.Books.GetLibraryItem(Book.Title);

            //bool containsBook =
            //    PeopleController.Person.Library.Books.Any(
            //        per => per.Title == Book.Title);
            if (containsBook)
            {
                DeleteObject(Book);

            }

            else
            {
                Console.WriteLine("That book doesn't exist!");
            }
        }

        public void ViewLogic()
        {
             if (!PeopleController.Person.Library.Books.Any())
            {
                Console.WriteLine("There aren't any books!");
            }

            else
            {
                ListLibraryItem(Book);
                Console.WriteLine();
            }
        }

        public void ItemInput()
        {
            Console.WriteLine("Enter Id");
            Book = new Book();
            Book.BookId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter title");
            Book.Title = Console.ReadLine();

            Console.WriteLine("Enter author");
            Book.Author = Console.ReadLine();

            Console.WriteLine("Enter publisher");
            Book.Publisher = Console.ReadLine();

            Console.WriteLine("Enter publishing date");
            Book.Published = Convert.ToInt32(Console.ReadLine());
        }

        public void AddObject(ILibraryItem item)
        {
            if (item.Title != string.Empty) PeopleController.Person.Library.Books.AddLibraryItem(Book);
            else
                Console.WriteLine("Book title is required!");
        }

        public void DeleteObject(ILibraryItem item)
        {
            PeopleController.Person.Library.Books.DeleteLibraryItem(item.Title);
            
        }

        public IEnumerable<ILibraryItem> ListLibraryItem(ILibraryItem item)
        {
            foreach (var b in PeopleController.Person.Library.Books)
            {
                Console.WriteLine("Books: ");
                Console.WriteLine("Id: {0} ", b.BookId);
                Console.WriteLine("Title: {0} ", item.Title);
                Console.WriteLine("Author: {0} ", b.Author);
                Console.WriteLine("Publisher: {0} ", b.Publisher);
                Console.WriteLine("Published: {0} ", b.Published);

            }
            return PeopleController.Person.Library.Books;
        }
    }
}
