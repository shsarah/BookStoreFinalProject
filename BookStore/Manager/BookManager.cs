using System;
using System.Collections;
using BookStore.DataModels;
using BookStore.Helper;
using BookStore.Infrastructure;

namespace BookStore.Manager
{
    public class BookManager : IManager<Book>,IEnumerable<Book>
    {
        Book[] data = new Book[0];

        public void Add(Book item)
        {
            int len = data.Length;
            Array.Resize(ref data, len + 1);
            data[len] = item;
        }

        public void Remove(Book item)
        {
            int index = Array.IndexOf(data, item);
            if (index == -1)
            {
                ColorChange.ColorChangeToRed("Nothing to delete, please try again");
            }

            for (int i = index; i < data.Length-1; i++)
            {
                data[i] = data[i + 1];
            }
            Array.Resize(ref data, data.Length - 1);
        }

        public void Edit(Book item)
        {
            int index = Array.IndexOf(data, item);
            if (index == -1)
            {
                ColorChange.ColorChangeToRed("Nothing to delete, please try again");
            }

            var found = data[index];
            found.Name = item.Name;
        }

        public Book this[int index]
        {
            get
            {
                return data[index];
            }
        }

        public IEnumerator<Book> GetEnumerator()
        {
            foreach (var item in data)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public Book GetById(int id)
        {
            return Array.Find(data, item => item.Id == id);
        }

        public Book[] FindByName(string name)
        {
            return Array.FindAll(data, item => item.Name.ToLower().StartsWith(name.ToLower()));
        }
    }
}

