using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryGenerator.Controllers;

namespace LibraryGenerator
{
    public class BooksController
    {
        public Book Book { get; set; }

        public PeopleController PeopleController { get; set; }
        public BooksController(PeopleController peopleController)
        {

            PeopleController = peopleController;
            Book = new Book(this);
        }

        public void AddBook(Book book)
        {
            Book.m_books.Add(book);
        }

        public void DeleteBook(Book book)
        {
            Book.m_books.Remove(book);
        }
    }
}
