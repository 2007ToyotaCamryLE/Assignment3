using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new singly linked list
            SLL myList = new SLL();

            // Add some users to the list
            myList.AddLast(new User(1, "Alice Johnson", "alice@example.com", "password123"));
            myList.AddLast(new User(2, "Bob Smith", "bob@example.com", "password456"));

            // Print the list contents
            Console.WriteLine("Current List:");
            PrintList(myList);

            // Reverse the list
            myList.Reverse();

            // Print the reversed list contents
            Console.WriteLine("Reversed List:");
            PrintList(myList);

            // Clear the list
            myList.Clear();
            Console.WriteLine($"List cleared. Is list empty? {myList.IsEmpty()}");

            // Keep the console window open
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }

        // Helper method to print the list
        static void PrintList(SLL list)
        {
            for (int i = 0; i < list.Count(); i++)
            {
                User user = list.GetValue(i);
                Console.WriteLine($"User {i}: {user.Name}, {user.Email}");
            }
        }
    }
}
