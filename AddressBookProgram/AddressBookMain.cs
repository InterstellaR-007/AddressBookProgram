using System;
using System.Collections.Generic;

namespace AddressBookProgram
{
    class AddressBookMain
    {
        static void Main(string[] args)
        {
            Dictionary<String,ContactDetails> address_book_list = new Dictionary<string,ContactDetails>();
            Dictionary<String, int> field_map = new Dictionary<string, int>();
            field_map.Add("first_Name", 0);
            field_map.Add("last_Name", 1);
            field_map.Add("address", 2);
            field_map.Add("city", 3);
            field_map.Add("state", 4);
            field_map.Add("pincode", 5);
            field_map.Add("phone_Number", 6);
            field_map.Add("email_Id", 7);

            String[] person_Details = new string[8];
            Console.WriteLine("Welcome to Address Book Program");
            Boolean exit_Prgram = false;
            Boolean exit_MainProgram = false;
            int input_Option = 0;
            
            String string_limiter = ",";
            String input_String = "";

            while (exit_MainProgram != true)
            {
                Console.WriteLine("Enter a new Address book? y/n \n");
                
                if (Console.ReadLine() == "y")
                {
                    ContactDetails new_AddressBook = new ContactDetails();
                    Console.WriteLine("\n Enter the Address Book name: ");
                    String unique_Name = Console.ReadLine();
                    new_AddressBook.set_AddressBook_Name(unique_Name);
                    address_book_list.Add(unique_Name, new_AddressBook);

                    while (exit_Prgram != true)
                    {

                        Console.WriteLine("\n Select the option from below to execute: \n");
                        Console.WriteLine("1: Add a Contact ");
                        Console.WriteLine("2: Edit an existing Contact ");
                        Console.WriteLine("3: Delete an exisiting Contact ");
                        Console.WriteLine("4: Display Contact Details entered ");
                        Console.WriteLine("5: Search a Person by City or State \n");

                        input_Option = int.Parse(Console.ReadLine());
                        switch (input_Option)
                        {

                            case 1:
                                Console.WriteLine("\n Enter the Contact details of a person : \n");
                                foreach (var i in field_map)
                                {
                                    Console.WriteLine(i.Key + ":");
                                    input_String = input_String + Console.ReadLine() + string_limiter;

                                }

                                new_AddressBook.AddContact(input_String);
                                input_String = "";
                                break;

                            case 2:
                                Console.WriteLine("\n Enter the first name and last name of that contact you want to edit: \n");
                                input_String = Console.ReadLine();
                                new_AddressBook.EditContactDetails(input_String);
                                break;

                            case 3:
                                Console.WriteLine("\n Enter the first name and last name of contact you want to delete: \n");
                                input_String = Console.ReadLine();
                                new_AddressBook.DeleteContact(input_String);
                                break;

                            case 4:
                                new_AddressBook.getPersonDetails();
                                break;

                            case 5:
                                new_AddressBook.get_PersonDetails_By_City_or_State();
                                break;

                            default:
                                Console.WriteLine("Invalid Input");
                                break;
                        }

                        Console.WriteLine("Do you want to continue ? Y/N : \n ");
                        if (Console.ReadLine() == "n")
                        {
                            exit_Prgram = true;
                        }





                    }

                    exit_Prgram = false;

                }
                else 
                {
                    foreach (var i in address_book_list)
                    {
                        Console.WriteLine("Address Book name is : \n "+ i.Key);
                        i.Value.getPersonDetails();
                    }
                    exit_MainProgram = true;
                }
                
            }
            


        }
    }
}
