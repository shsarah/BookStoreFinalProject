using System;
namespace BookStore.DataModels
{
	
	public class Author:IEquatable<Author>
	{
		static int counter = 0;
		public Author()
		{
			counter++;
			this.Id = counter;
		}

		public int Id { get; private set; }

		public string? Name { get; set;  }

		public string?  Surname { get; set; }

		public Author(int id)
		{
			this.Id = id;
		}

        public override string ToString()
        {
			return $"{Id} | {Name} {Surname} ";
        }

        public bool Equals(Author? other)
        {
			return other?.Id == this.Id;
        }
    }
}

