using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using helper;
using bussinesslogic;
using System.Configuration;

namespace sept_27_assignments
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Employee Management System");
            Console.WriteLine("--------------------------------");
            EmployeeHelper helper = new EmployeeHelper();
            Console.WriteLine("Menu");
            Console.WriteLine("-----");
            Console.WriteLine("1. Add New Employee \n 2. Update Employee \n 3. Find Employee \n 4. Show All \n 5.Delete \n  6. Employee count \n 7. Exit ");
            int userchoice = Convert.ToInt32(Console.ReadLine());
            Employee_BAL emp = new Employee_BAL();

            switch (userchoice)
            {
                case 1:

                    Console.WriteLine("Enter firstname");
                    emp.FirstName = Console.ReadLine().Trim();

                    Console.WriteLine("Enter lastname");
                    emp.LastName = Console.ReadLine().Trim();
                    Console.WriteLine("Enter title");
                    emp.Title = Console.ReadLine().Trim();
                    Console.WriteLine("Enter birthdate");
                    emp.BirthDate = Convert.ToDateTime(Console.ReadLine());

                    bool queryStatus = helper.AddNewEmployee(emp);
                    if (queryStatus)
                    {
                        Console.WriteLine("Employee added successfully.....");
                    }
                    else
                    {
                        Console.WriteLine("Some error occured...");
                    }
                    break;
                case 2:
                    Console.WriteLine("enter original emp id");
                    int empid = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("enter new emp id");
                    emp.EmployeeID = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter firstname");
                    emp.FirstName = Console.ReadLine().Trim();

                    Console.WriteLine("Enter lastname");
                    emp.LastName = Console.ReadLine().Trim();
                    Console.WriteLine("Enter title");
                    emp.Title = Console.ReadLine().Trim();
                    Console.WriteLine("Enter birthdate");
                    emp.BirthDate = Convert.ToDateTime(Console.ReadLine());

                    queryStatus = helper.EditEmployeeData(empid, emp);
                    if (queryStatus)
                    {
                        Console.WriteLine("Employee updated successfully.....");
                    }
                    else
                    {
                        Console.WriteLine("Some error occured...");
                    }

                    break;
                case 3:
                    Console.WriteLine("enter  emp id");
                    emp.EmployeeID = Convert.ToInt32(Console.ReadLine());
                    Employee_BAL data = helper.LocateEmployee(emp.EmployeeID);
                    if (data != null)
                    {
                        Console.WriteLine("Following are the details");
                        Console.WriteLine(data.EmployeeID);
                        Console.WriteLine(data.FirstName);
                        Console.WriteLine(data.LastName);
                        Console.WriteLine(data.Title);
                        Console.WriteLine(data.BirthDate);
                    }
                    else
                    {
                        Console.WriteLine("Invalid employee id");
                    }
                    break;
                case 4:
                    List<Employee_BAL> emplist = new List<Employee_BAL>();
                    emplist = helper.EmployeeList();
                    Console.WriteLine("EmployeeID" + "      " + "First Name" + "         " + "LastName" + "       " + "Title" + "    " + "Birth Date");
                    foreach (var item in emplist)
                    {
                        Console.WriteLine(item.EmployeeID + "       " + item.FirstName + "       " + item.LastName + "      " + item.Title + "  " + item.BirthDate);
                        //Console.WriteLine(item.FirstName);
                        //Console.WriteLine(item.LastName);
                        //Console.WriteLine(item.Title);
                        //Console.WriteLine(item.BirthDate);
                        Console.WriteLine();
                    }



                    break;
                case 5:
                    Console.WriteLine("enter  emp id");
                    emp.EmployeeID = Convert.ToInt32(Console.ReadLine());
                    queryStatus = helper.RemoveEmployeeData(emp.EmployeeID);
                    if (queryStatus)
                    {
                        Console.WriteLine("Employee Deleted successfully.....");
                    }
                    else
                    {
                        Console.WriteLine("Some error occured...");
                    }


                    break;
                default:
                    break;
            }
            Console.ReadKey();



        }
    }
    }
