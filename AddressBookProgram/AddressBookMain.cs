using System;
using System.Collections.Generic;

namespace AddressBookProgram
{
    /// <summary>
    /// Main Address Book Program Structure
    /// </summary>
    class AddressBookMain
    {
        static void Main(string[] args)
        {
            Dictionary<String,ContactDetailsBuilder> address_book_list = new Dictionary<string,ContactDetailsBuilder>();

            List<string> field_List = new List<string>() { "first_Name", "first_Name", "address", "city", "state", "phone_Number", "email_Id" };

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
                    ContactDetailsBuilder new_AddressBook = new ContactDetailsBuilder();
                    Console.WriteLine("\nEnter the Address Book name: ");
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
                        Console.WriteLine("5: Search a Person by City or State ");
                        Console.WriteLine("6: Sort by Name ");
                        Console.WriteLine("7: Sort by City/State/PinCode ");
                        Console.WriteLine("8: Write to Address Book csv file");
                        Console.WriteLine("9: Read from Address Book csv file\n");

                        input_Option = int.Parse(Console.ReadLine());
                        switch (input_Option)
                        {

                            case 1:
                                Console.WriteLine("Enter the Contact details of a person : \n");
                                foreach (var i in field_List)
                                {
                                    Console.WriteLine(i + ":");
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

                            case 6:
                                new_AddressBook.sort_Aphabetically();
                                break;

                            case 7:
                                new_AddressBook.sort_By_StateCityZip();
                                break;
                            case 8:
                                new_AddressBook.WriteToAddressBook_UsingIO();
                                break;
                            case 9:
                                new_AddressBook.ReadFromAddressBook_UsingIO();
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
