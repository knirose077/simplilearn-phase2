using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bal;
using dataaccess;
namespace sept_28_assignments
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BOOKS DETAILS");
            Console.WriteLine("MENU");
            Console.WriteLine("1.list all book details\n 2.insert book details \n 3.update book details \n 4.delete book details\n 5.count book details\n");
            int ch=Convert.ToInt32(Console.ReadLine());
            CustomerOperations co = new CustomerOperations();

            book bal = new book();
            switch (ch)
            {
                case 1:
                   
                    List<book> customers = co.GetCustomers();
                    Console.WriteLine("BOOK ID            BOOKNAME                      BOOK AUTHOR");
                    foreach (var item in customers)
                    {

                        Console.WriteLine(item.book_id + "          " + item.book_name + "                                       " + item.book_author);
                    }
                    break;
                    case 2:
                     
                   
                    Console.WriteLine("enter  book id");

                    bal.book_id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("entr book name");
                    bal.book_name = Console.ReadLine();

                    Console.WriteLine("enter book author");
                    bal.book_author = Console.ReadLine();

                    co.Insertcustomer(bal);
                    Console.WriteLine("inserted succesfully");
                    break;
                case 3:
                  
                    Console.WriteLine("Update book details");
                    Console.WriteLine("enter bookid to update");
                    bal.book_id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("entr book name");
                    bal.book_name = Console.ReadLine();
                    Console.WriteLine("enter book author");
                    bal.book_author = Console.ReadLine();
                    co.UpdateCustomer(bal);
                    Console.WriteLine("Updated successfully....");
                    break;

                case 4:
                    Console.WriteLine("enter the book id to delete");
                    int bookid = Convert.ToInt32(Console.ReadLine());
                    
                    co.DeleteCustomer(bookid);
                    Console.WriteLine("Deleted successfully...."); 
                    break;
                case 5:
                     int c=co.bookcounts();
                    Console.WriteLine("count succesfully"+" "+c);
                    
                    break;
                        }
           
            Console.ReadLine();
        }
    }
}
