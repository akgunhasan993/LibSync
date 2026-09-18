using System;
using System.Collections.Concurrent;

namespace  MyNamespace
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Book> library = new List<Book>();
            bool situation = true;

            while (situation)
            {
                int choice = Process();

                if (choice == 1)
                {
                    Book book = new Book();

                    Console.Write("Please enter the name of the book you wish to add: ");
                    book.Name = Console.ReadLine();

                    Console.Write("Please enter the writer of the book you wish to add: ");
                    book.Writer = Console.ReadLine();

                    Console.Write("Please enter the category of the book you wish to add: ");
                    book.Category = Console.ReadLine();

                    Console.Write("Please enter the stock of the book you wish to add: ");
                    book.Stock = int.Parse(Console.ReadLine());

                    library.Add(book);
                    Console.WriteLine("Book added successfully!\n");
                }
                else if (choice == 2)
                {
                    Console.Write("Enter the name of the book you want to loan/return: ");
                    string targetBookName = Console.ReadLine();

                    bool isFound = false;

                    foreach (Book b in library)
                    {
                        if (b.Name.ToLower() == targetBookName.ToLower())
                        {
                            isFound = true;
                            Console.WriteLine($"Book found! '{b.Name}' (Current Stock: {b.Stock})");
                            
                            Console.Write("Type '1' to borrow (decrease stock), '2' to return (increase stock): ");
                            int action = int.Parse(Console.ReadLine());

                            if (action == 1)
                            {
                                if (b.Stock > 0)
                                {
                                    b.Stock--;
                                    Console.WriteLine("Book successfully borrowed. Remaining stock: " + b.Stock);
                                }
                                else
                                {
                                    Console.WriteLine("Sorry, out of stock!");
                                }
                            }
                            else if (action == 2)
                            {
                                b.Stock++;
                                Console.WriteLine("Book successfully returned. New stock: " + b.Stock);
                            }
                        }
                    }

                    if (!isFound)
                    {
                        Console.WriteLine("Such a book was not found in the library!");
                    }
                    Console.WriteLine();
                }
                else if (choice == 3)
                {
                    Console.WriteLine("\n--- BOOK LIST ---");
                    if (library.Count == 0)
                    {
                        Console.WriteLine("The library is currently empty.");
                    }
                    else
                    {
                        foreach (Book b in library)
                        {
                            Console.WriteLine($"Name: {b.Name} | Writer: {b.Writer} | Category: {b.Category} | Stock: {b.Stock}");
                        }
                    }
                    Console.WriteLine("-----------------\n");
                }
                else if (choice == 4)
                {
                    situation = false;
                    Console.WriteLine("Exiting the system. Have a good day!");
                }
                else
                {
                    Console.WriteLine("You pressed the wrong key! Please try again.\n");
                }
            }
        }

        public static int Process()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1- Add Book");
            Console.WriteLine("2- Loan / Return Book");
            Console.WriteLine("3- List Books");
            Console.WriteLine("4- Exit");
            Console.Write("Your choice: ");
            
            int vote = Convert.ToInt32(Console.ReadLine());
            return vote;
        }
	}
}

