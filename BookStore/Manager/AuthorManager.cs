using System;
using System.Collections;
using BookStore.DataModels;
using BookStore.Infrastructure;
using BookStore.Helper;


namespace BookStore.Manager
{
    public class AuthorManager : IManager<Author>, IEnumerable<Author>
    {
        Author[] data = new Author[0];

        public void Add(Author item)
        {
            int len = data.Length;
            Array.Resize(ref data, len + 1);
            data[len] = item;
       }
        
        public void Remove(Author item)
        {
            l1:
            int index = Array.IndexOf(data, item);

            if (index == -1)
            {
                ColorChange.ColorChangeToRed("Nothing found.");
                goto l1;
            }

            for (int i = index; i < data.Length - 1; i++)
            {
                data[i] = data[i + 1];
            }
            Array.Resize(ref data, data.Length - 1);
        }

        public void Edit(Author item)
        {
            l2:
            int index = Array.IndexOf(data, item);

            if (index == -1)
            {
                ColorChange.ColorChangeToRed("Nothing to edit.");
                goto l2;
            }
            var found = data[index];
            found.Name = item.Name;
        }

        public Author this[int index]
        {
            get
            {
                return data[index];
            }
        }

        public IEnumerator<Author> GetEnumerator()
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

        public Author GetById(int id)
        {
            return Array.Find(data, item => item.Id == id);
        }

        public Author[] FindByName(string name)
        {
            return Array.FindAll(data, item => item.Name.ToLower().StartsWith(name.ToLower()));
        }
    }
}

