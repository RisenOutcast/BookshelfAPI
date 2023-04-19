# Bookshelf API :books:
API for storing data on books, built using ASP.NET Core, .NET Entity Framework and SQLite. 

### How to run?
Runnable standalone (Does not require .NET 6 installation!) executable can be downloaded **[here](https://github.com/RisenOutcast/BookshelfAPI/releases)**, run the .exe and close with Ctrl+C.
Otherwise, you can build it yourself using Visual Studio or .NET CLI

### Getting data from the database:
The newly downloaded database is empty, you need to add books to it yourself.

`http://<url>:9000/books`

Returns all the books in the database
You can also use parameters `?author`, `?year` and `?publisher` to filter the books.

`http://<url>:9000/books/<id number>`

Returns the book with this id

### Posting new data:

New data can be added by POST to the `http://<url>:9000/books`

Example with curl using Powershell:
`curl -Method POST -Uri http://localhost:9000/books -ContentType 'application/json' -Body '{"title": "The Lord of the Rings","author": "J. R. R. Tolkien","year": 1954,"publisher": "Allen & Unwin","description": "A book about how one does not simply walk into Mordor"}' -UseBasicParsing`

### Deleting data:

by DELETE to the `http://<url>:9000/books/<id number>` which deletes the book with the specified id

### Updating the Database structure:

Changes to the database structure can be made with the `Update-Database` command. More info on it can be found [here](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli).

To quickly summarise the functionality of updating the database: Make changes to database code, run `Add-Migration <name>`, and run `Update-Database`.

