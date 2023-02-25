using System;
namespace BookStore.Enums
{
	public enum MenuTypes:byte
	{
        AuthorAdd = 1,
        AuthorEdit,
        AuthorRemove,
        AuthorGetAll,
        AuthorFindByName,
        AuthorGetById,

        BookAdd,
        BookEdit,
        BookRemove,
        BookGetAll,
        BookFindByName,
        BookGetById,
    }
}

