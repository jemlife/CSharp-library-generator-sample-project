using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryGenerator.Controllers;

namespace LibraryGenerator
{
    public static class LibraryExtensionMethods 
    {

        public static bool GetLibraryItem<T> (this IEnumerable<T> libItems, string itemTitle) where T : ILibraryItem
        {

            return libItems.Any(t => t.Title == itemTitle);
        }

        public static void AddLibraryItem<T> (this IList<T> libItems, T item) where T : ILibraryItem
        {

            libItems.Add(item);

        }

        public static void DeleteLibraryItem<T>(this List<T> libItems, string itemTitle) where T : ILibraryItem
        {
            
            
            libItems.RemoveAll(x => x.Title == itemTitle);

        }

    }
}
