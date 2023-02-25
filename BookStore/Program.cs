using BookStore.DataModels;
using BookStore.Enums;
using BookStore.Manager;
using BookStore.Helper;

namespace BookStore;
class Program
{
    static void Main(string[] args)
    {
        AuthorManager authorManager = new AuthorManager();

        BookManager bookManager = new BookManager();

        MenuTypes selectedMenu;

        int count = 0;

        int countBook = 0;

        int income;

        Author author;

        Book book;

        int id;

        ColorChange.ColorChangeToGreen("Welcome!");
        l1:
        ColorChange.ColorChangeToGreen("---Choose an option, please---");

        selectedMenu = EnumHelpers.ReadEnum<MenuTypes>("Your option is: ");

        switch (selectedMenu)
        {
            case MenuTypes.AuthorAdd:
                Console.Clear();
                author = new Author();
                count++;

                ColorChange.ColorChangeToRed("Type 'Exit/exit/EXIT' to return main menu or continue process.");
                l3:
                author.Name = PrimitiveHelper.ReadString("Enter name of author.");

                if (author.Name == "Exit"||author.Name=="exit"||author.Name=="EXIT")
                {
                    goto l1;
                }

                if (author.Name.Length < 3)
                {
                    ColorChange.ColorChangeToRed("Enter a valid name.");
                    goto l3;
                }

                author.Surname = PrimitiveHelper.ReadString("Enter surname of author.");

                if (author.Surname == "EXIT" || author.Surname == "exit"||author.Surname=="Exit")
                {
                    goto l1;
                }

                if (author.Surname.Length < 3)
                {
                    ColorChange.ColorChangeToRed("Enter a valid surname.");
                    goto l3;
                }

                authorManager.Add(author);

                goto l1;
                
            case MenuTypes.AuthorEdit:

                if (count == 0)
                {
                    ColorChange.ColorChangeToRed("Nothing to edit.");
                    goto l1;
                }

                Console.Clear();
                ColorChange.ColorChangeToRed("Press 0 to return main menu or continue process.");

                ColorChange.ColorChangeToGreen("Choose the author to edit:");

                foreach (var item in authorManager)
                {
                    Console.WriteLine(item);
                }

                id = PrimitiveHelper.ReadInt("Author's id: ",0,count);

                if (id == 0)
                {
                    goto l1;
                }

                author = authorManager.GetById(id);

                if (author == null)
                {
                    ColorChange.ColorChangeToRed("Not found. Try again.");
                    Console.Clear();
                    goto case MenuTypes.AuthorEdit;
                }
                author.Name = PrimitiveHelper.ReadString("Author's new name: ");
                author.Surname = PrimitiveHelper.ReadString("Author's new surname: ");
                Console.Clear();

                foreach (var item in authorManager)
                {
                    ColorChange.ColorChangeToGreen($"{item}");
                }

                goto l1;

            case MenuTypes.AuthorFindByName:
                
                if (count==0)
                {
                    ColorChange.ColorChangeToRed("Nothing to search.");
                    goto l1;
                }
                ColorChange.ColorChangeToRed("Type 'Exit/exit/EXIT' to return main menu or continue process.");
                string name = PrimitiveHelper.ReadString("Enter something to search.");

                if (name == "Exit"||name=="exit"||name=="EXIT")
                {
                    goto l1;
                }
               
                var found = authorManager.FindByName(name);

                if (found.Length == 0)
                {
                    ColorChange.ColorChangeToRed("Not found, try again.");
                    goto case MenuTypes.AuthorFindByName;
                }

                foreach (var item in found)
                {
                    ColorChange.ColorChangeToGreen($"{item}");
                }

                goto l1;

            case MenuTypes.AuthorGetById:
                if (count == 0)
                {
                    ColorChange.ColorChangeToRed("Nothing to get.");
                    goto l1;
                }

                ColorChange.ColorChangeToRed("Press 0 to return main menu or continue process.");

                id = PrimitiveHelper.ReadInt("Enter the id please.",0,count);

                if (id == 0)
                {
                    goto l1;
                }

                author = authorManager.GetById(id);

                if (author == null)
                {
                    Console.Clear();
                    ColorChange.ColorChangeToRed("Not found, try again.");
                    goto case MenuTypes.AuthorGetById;
                }

                ColorChange.ColorChangeToGreen($"{author}");
                goto l1;

            case MenuTypes.AuthorGetAll:

                if (count == 0)
                {
                    ColorChange.ColorChangeToRed("Nothing to show.");
                    goto l1;
                }

                foreach (var item in authorManager)
                {
                    ColorChange.ColorChangeToGreen($"{item}");
                }

                goto l1;

            case MenuTypes.AuthorRemove:

                if (count == 0)
                {
                    ColorChange.ColorChangeToRed("Nothing to delete.");
                    goto l1;
                }

                ColorChange.ColorChangeToRed("Press 0 to return main menu or continue process.");

                ColorChange.ColorChangeToGreen("Choose an author to delete.");

                foreach (var item in authorManager)
                {
                    Console.WriteLine(item);
                }

                id = PrimitiveHelper.ReadInt("Author id: ",0,count);

                if (id == 0)
                {
                    goto l1;
                }

                author = authorManager.GetById(id);

                if (author == null)
                {
                    Console.Clear();
                    goto case MenuTypes.AuthorRemove;
                }

                authorManager.Remove(author);

                Console.Clear();

                foreach (var item in authorManager)
                {
                    ColorChange.ColorChangeToGreen($"{item}");
                }

                goto l1;

            case MenuTypes.BookAdd:
                
                if (count == 0)
                {
                    ColorChange.ColorChangeToRed("Enter author first, please.");
                    goto l1;
                }
                ColorChange.ColorChangeToRed("Type 'Exit/exit/EXIT' to return main menu");
                book = new Book();
                countBook++;

                book.Name = PrimitiveHelper.ReadString("Enter name of book: ");

                if (book.Name == "EXIT" || book.Name == "exit"||book.Name=="Exit")
                {
                    goto l1;
                }

                book.PageCount = PrimitiveHelper.ReadInt("Enter count of pages: ",1,int.MaxValue);

                book.Price = PrimitiveHelper.ReadDecimal("Enter price of book: ",1m,decimal.MaxValue);

                book.genre = EnumHelpers.ReadEnum<Genre>("Choose genre of book: ");

                foreach (var item in authorManager)
                {
                    ColorChange.ColorChangeToGreen($"{item}");
                }

                book.AuthorId = PrimitiveHelper.ReadInt("Choose author of book from the list: ", 1, count);
                
                bookManager.Add(book);

                goto l1;

            case MenuTypes.BookGetAll:

                if (countBook == 0)
                {
                    ColorChange.ColorChangeToRed("Nothing to show.");
                    goto l1;
                }

                foreach (var item in bookManager)
                {
                    ColorChange.ColorChangeToGreen($"{item}");
                }

                goto l1;

            case MenuTypes.BookEdit:

                if (countBook == 0)
                {
                    ColorChange.ColorChangeToRed("Nothing to edit.");
                    goto l1;
                }

                Console.Clear();

                ColorChange.ColorChangeToRed("Press 0 to return main menu or continue process.");

                ColorChange.ColorChangeToGreen("Choose the book to edit:");

                foreach (var item in bookManager)
                {
                    Console.WriteLine(item);
                }

                id = PrimitiveHelper.ReadInt("Book's id: ", 0, count);

                if (id == 0)
                {
                    goto l1;
                }

                book = bookManager.GetById(id);

                if (book == null)
                {
                    ColorChange.ColorChangeToRed("Not found. Try again.");
                    Console.Clear();
                    goto case MenuTypes.BookEdit;
                }
                book.Name = PrimitiveHelper.ReadString("New book's name: ");

                Console.Clear();

                foreach (var item in bookManager)
                {
                    ColorChange.ColorChangeToGreen($"{item}");
                }

                goto l1;

            case MenuTypes.BookRemove:
                if (countBook == 0)
                {
                    ColorChange.ColorChangeToRed("Nothing to delete.");
                    goto l1;
                }

                ColorChange.ColorChangeToRed("Press 0 to return main menu or continue process.");

                ColorChange.ColorChangeToGreen("Choose a book to delete.");

                foreach (var item in bookManager)
                {
                    Console.WriteLine(item);
                }

                id = PrimitiveHelper.ReadInt("Book id: ", 0, countBook);

                if (id == 0)
                {
                    goto l1;
                }

                book = bookManager.GetById(id);

                if (book == null)
                {
                    Console.Clear();
                    goto case MenuTypes.AuthorRemove;
                }

                bookManager.Remove(book);

                Console.Clear();

                foreach (var item in bookManager)
                {
                    ColorChange.ColorChangeToGreen($"{item}");
                }

                goto l1;

            case MenuTypes.BookGetById:

                if (countBook == 0)
                {
                    ColorChange.ColorChangeToRed("Nothing to get");
                    goto l1;
                }

                ColorChange.ColorChangeToRed("Press 0 to return main menu or continue process.");

                id = PrimitiveHelper.ReadInt("Enter the id please.", 0, countBook);

                if (id == 0)
                {
                    goto l1;
                }

                book = bookManager.GetById(id);

                if (book == null)
                {
                    Console.Clear();
                    ColorChange.ColorChangeToRed("Not found, try again.");
                    goto case MenuTypes.BookGetById;
                }

                ColorChange.ColorChangeToGreen($"{book}");

                goto l1;

            case MenuTypes.BookFindByName:

                if (countBook == 0)
                {
                    ColorChange.ColorChangeToRed("Nothing to search.");
                    goto l1;
                }

                ColorChange.ColorChangeToRed("Type 'Exit/exit/EXIT' to return main menu or continue process.");

                string nameBook = PrimitiveHelper.ReadString("Enter something to search.");

                if (nameBook == "EXIT"||nameBook=="exit"||nameBook=="Exit")
                {
                    goto l1;
                }

                var foundBook = bookManager.FindByName(nameBook);

                if (foundBook.Length == 0)
                {
                    ColorChange.ColorChangeToRed("Not found, try again.");
                    goto l1;
                }

                foreach (var item in foundBook)
                {
                    ColorChange.ColorChangeToGreen($"{item}");
                }

                goto l1;
               
        }

    }
}

