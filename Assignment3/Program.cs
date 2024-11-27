namespace Assignment3
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool Availability { get; set; }
        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            Availability = true;
        }
    }
    class Library
    {
        List<Book> books=new List<Book>();
        public void AddBook(Book book)
        {
            books.Add(book);
        }
        public bool SearchBook(string Searchh)
        {
            bool titleMatch = false;
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Title == Searchh)
                {
                    titleMatch = true;
                    Console.WriteLine("Your book is here :)");
                    return true;
                }
            }
            if (!titleMatch)
            {
                Console.WriteLine("The book isn't here. :(");
                return false;
            }
            else
                return true;
        }
        public bool BorrowBook(string Ntitle)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Title == Ntitle && books[i].Availability)
                {
                    books[i].Availability = false; // لما هو هياخد الكتاب مش هيبقى متاح عشان كده عملت false
                    Console.WriteLine("Borrow process complete :)");
                    return true;
                }
            }
            Console.WriteLine("This book isn't in the library");
            return false;
        }
        public bool ReturnBook(string Atitle) 
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Title == Atitle && !books[i].Availability)
                {
                    books[i].Availability = true; // لما هو يرجع الكتاب هيبقى متاح عشان كده عملت true
                    Console.WriteLine("Return process complete :)");
                    return true;
                }
            }
            Console.WriteLine("This book isn't borrowed"); 
            return false;
        }
        
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            // Adding books to the library
            library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565"));
            library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));
            library.AddBook(new Book("1984", "George Orwell", "9780451524935"));

            // Searching and borrowing books
            Console.WriteLine("Searching and borrowing books...");
            library.BorrowBook("The Great Gatsby");//Availabile
            library.BorrowBook("Nader Foda");//Not in the library
            library.BorrowBook("The Great Gatsby");//Already taken
            library.BorrowBook("1984"); //Availabile

            // Returning books
            Console.WriteLine("\nReturning books...");
            library.ReturnBook("The Great Gatsby");//Well process
            library.ReturnBook("Harry Potter"); // This book is not borrowed bcz tin't in the library
            library.ReturnBook("1984");//Well process
            Console.WriteLine("\nSearching books...");
            library.SearchBook("Nader Foda");//Not in the library
            library.SearchBook("To Kill a Mockingbird");//In the library


        }
    }
}
