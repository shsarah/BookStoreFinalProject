using System;
using System.Collections;
using BookStore.Enums;

namespace BookStore.DataModels
{
	public class Book:IEquatable<Book>
	{
		static int counter = 0;
		public Book()
		{
			counter++;
			this.Id = counter;
		}

		public int Id { get; private set; }

		public string? Name { get; set; }

		public int PageCount { get; set; }

		public decimal Price { get; set; }

		public int AuthorId { get; set; }

		public Genre genre { get; set; }

        public bool Equals(Book? other)
        {
			return other?.Id == this.Id||other?.AuthorId==this.AuthorId;
        }

		public Book(int id)
		{
			this.Id = id;
		}

        public override string ToString()
        {
            return $"{Id} | {Name} ";
        }

    }
}

