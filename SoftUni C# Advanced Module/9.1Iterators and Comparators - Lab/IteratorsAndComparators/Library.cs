using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        public Library(params Book[] books)
        {
            Books = books.ToList();
        }

        public List<Book> Books { get; set; }

        public IEnumerator<Book> GetEnumerator()
        {
           return new LibraryIteratir(Books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        class LibraryIteratir : IEnumerator<Book>
        {
            private int index = -1;
            private List<Book> books;
            public LibraryIteratir (List<Book> books)
            {
                this.books = books;
                books.Sort(new BookComparator());
            }

            public Book Current => books[index];

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                
            }

            public bool MoveNext()
            {              
                return ++index < books.Count;
            }

            public void Reset()
            {
                index = -1;
            }
        }
    }
}
