using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;



namespace UserList
{
  
  public class Program 
    {
        public static void Main()
        {
            
            using (var dbContext = new CustomerDbContext())
            {
                Program program = new Program();
                CustomerService customerService = new CustomerService();

                bool check = false;

               while(check==false)
               {
                
                Console.Write("PRESS 1 - ADD NEW CUSTOMER");
                Console.Write(" \t PRESS 2 - ALL CUSTOMER");
                Console.WriteLine(" \t PRESS 0 : EXIT");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("option : ");
    

                int choice = int.Parse(Console.ReadLine());

                 if(typeof(choice)==string){
                    Console.WriteLine("Invalid option ")
                 }

                switch (choice)
                {

                    case 0:
                        Console.WriteLine("Exit");
                        animation();
                        Environment.Exit(1);
                        break;
                    
                    case 1:
                        Console.WriteLine("Create New Customer List");
                        Console.WriteLine("Enter name:");
                        string _name = Console.ReadLine();
                        Console.WriteLine("Enter phoneNumber :");
                        string _phoneNumber = Console.ReadLine();
                        animation();
                        bool customerCreated = customerService.CreateCustomer(dbContext, _name, _phoneNumber);

                        if (customerCreated)
                        {
                            Console.WriteLine("Customer saved successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Error saving customer.");
                        }
                        check = true;
                        break;


                    case 2:
                        Console.WriteLine();
                        animation();
                        Console.WriteLine("All Customers");
                        List<Customer> customers = customerService.ListAllCustomers(dbContext);
                        
                        Console.WriteLine();
                        if (customers.Count == 0)
                        {
                            Console.WriteLine("No customers found");
                        }
                        else
                        {
                            Console.WriteLine("customer id : \t  \t Customer name:\t  Phone number:\t");
                              foreach (var newcustomer in customers)
                            {
                                Console.WriteLine($" | {newcustomer.Id} \t \t  \t  {newcustomer.Name}    \t  {newcustomer.PhoneNumber}  \t ");
                            }

                        }
                        check = true;
                        break;

                    default:
                        Console.WriteLine("Wrong choice");
                        break;
                }
                
               }
            }
               
        }

        public static void animation()
        {
            Console.Write("Fetching all customers... ");

            for (int i = 0; i < 20; i++)
            {
                Console.Write(".");
                System.Threading.Thread.Sleep(200); // Add a delay between dots
            }

            Console.WriteLine(" Done.");
        }

    }





















    // public class Program
    // {
    //     public string FilePath = @"/home/vigneshwaran/Learning/UserList/ex.txt";

    //     public static void Main()
    //     {
    //         Program program = new Program();

    //         Console.WriteLine("Press 1 : .................Add new Customer....................");
    //         Console.WriteLine("Press 2 :...................All Customer....................");

    //         int choice = int.Parse(Console.ReadLine() ?? "0");

    //         switch (choice)
    //         {
    //             case 1:
    //                 Console.WriteLine("Create New Customer List");
    //                  program.CreateCustomer();
    //                 break;

    //             case 2:
    //                 Console.WriteLine("All Customer");
    //                 program.ListAllCustomer();
    //                 break;

    //             default:
    //                 Console.WriteLine("Wrong choice");
    //                 break;
    //         }
    //     }

    //     public void CreateCustomer()
    //     {
    //         Console.WriteLine("Enter name:");
    //         string name = Console.ReadLine();
    //         Console.WriteLine("Enter ph :");
    //         long pno = Convert.ToInt64(Console.ReadLine());

    //         Customer customer = new Customer
    //         {
    //             Name = name,
    //             Pno = pno
    //         };

    //         List<Customer> customers = LoadCustomer();
    //         customers.Add(customer);
    //         SaveCustomers(customers);
    //         Console.WriteLine("Customer saved..");
    //     }

    //     public void ListAllCustomer()
    //     {
    //         List<Customer> customers = LoadCustomer();

    //         if (customers.Count == 0)
    //         {
    //             Console.WriteLine("No customers found");
    //         }
    //         else
    //         {
    //             foreach (var customer in customers)
    //             {
    //                 Console.WriteLine($"Customer name: {customer.Name}, Phone number: {customer.Pno}");
    //             }
    //         }
    //     }

    //     public List<Customer> LoadCustomer()
    //     {
    //         if (File.Exists(FilePath))
    //         {
    //             string json = File.ReadAllText(FilePath);
    //             return JsonConvert.DeserializeObject<List<Customer>>(json) ?? new List<Customer>();
    //         }
    //         else
    //         {
    //             return new List<Customer>();
    //         }
    //     }

    //     public void SaveCustomers(List<Customer> customers) 
    //     {

    //         string json = JsonConvert.SerializeObject(customers,Formatting.Indented);
    //         File.WriteAllText(FilePath, json);
    //     }
    // }

    
}
