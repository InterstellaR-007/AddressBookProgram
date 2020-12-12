using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AddressBookProgram
{

    public class InputValidation
    {
        public Dictionary<string, string> regex_Dictionary = new Dictionary<string, string>
        {
            {"First Name",@"^[a-zA-Z]{3,}" },
            {"Last Name",@"^[a-zA-Z]{3,}" },
            {"Address",@"^[a-zA-Z0-9]{3,}" },
            {"City",@"^[a-zA-Z]{3,}" },
            {"State",@"^[a-zA-Z]{3,}" },
            {"Pin Code",@"^[1-9]{1}[0-9]{2}\s{0,1}[0-9]{3}$" },
            {"Phone Number",@"^[+]*[0-9]{2}\s{0,1}[0-9]{10}" },
            {"Email Id",@"^[^\.][a-zA-Z_\-0-9]*[\.]*[a-zA-Z_\-0-9]+@[a-z0-9]+[\.][a-z]{2,4}([\.][a-z]{2,3})?$" }
        };
        
        public bool isInputValid(string field_Name,string input_Value)
        {
            string regex_String;
            regex_Dictionary.TryGetValue(field_Name, out regex_String);

            Regex regex = new Regex(regex_String);
            Match match = regex.Match(input_Value);
            return match.Success;
        }
    }
    /// <summary>
    /// Main Address Book Program Structure
    /// </summary>
    class AddressBookMain
    {
        static void Main(string[] args)
        {
            Dictionary<String,ContactDetailsBuilder> address_book_list = new Dictionary<string,ContactDetailsBuilder>();

            List<string> field_List = new List<string>() { "First Name", "Last Name", "Address", "City", "State","Pin Code", "Phone Number", "Email Id" };

            String[] person_Details = new string[8];
            Console.WriteLine("Welcome to Address Book Program");
            Boolean exit_Prgram = false;
            Boolean exit_MainProgram = false;
            int input_Option = 0;
            
            String string_limiter = ",";
            String input_String = "";

            while (exit_MainProgram != true)
            {
                Console.WriteLine(" \nEnter a new Address book? (y/n) ");
                
                if (Console.ReadLine() == "y")
                {
                    ContactDetailsBuilder new_AddressBook = new ContactDetailsBuilder();
                    Console.WriteLine("\nEnter the Address Book name: ");
                    String unique_Name = Console.ReadLine();
                    string field_Input;
                    new_AddressBook.set_AddressBook_Name(unique_Name);
                    
                    address_book_list.Add(unique_Name, new_AddressBook);

                    while (exit_Prgram != true)
                    {

                        Console.WriteLine("\nSelect the option from below to execute: \n");
                        Console.WriteLine("1: Add a Contact ");
                        Console.WriteLine("2: Edit an existing Contact ");
                        Console.WriteLine("3: Delete an exisiting Contact ");
                        Console.WriteLine("4: Display Contact Details entered ");
                        Console.WriteLine("5: Search a Person by City or State ");
                        Console.WriteLine("6: Sort by Name ");
                        Console.WriteLine("7: Sort by City/State/PinCode ");
                        Console.WriteLine("8: Write to Address Book JSON file");
                        Console.WriteLine("9: Read from Address Book JSON file");
                        Console.WriteLine("10: Exit Program\n");

                        input_Option = int.Parse(Console.ReadLine());
                        switch (input_Option)
                        {

                            case 1:
                                Console.WriteLine("Enter the Contact details of a person : \n");
                                InputValidation inputValidation = new InputValidation();
                                foreach (var i in field_List)
                                {

                                    Console.WriteLine(i + ":");

                                    while (true)
                                    {
                                        field_Input = Console.ReadLine();
                                        
                                        if(inputValidation.isInputValid(i, field_Input) == false)
                                        {
                                            Console.WriteLine("input detail is Invalid, Try Again");
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                        
                                    
                                    input_String = input_String + field_Input + string_limiter;

                                }

                                new_AddressBook.AddContact(input_String);
                                input_String = "";
                                break;

                            case 2:
                                Console.WriteLine("\n Enter the first name and last name <firstName>,<lastName> of that contact you want to edit: \n");
                                input_String = Console.ReadLine();
                                new_AddressBook.EditContactDetails(input_String);
                                break;

                            case 3:
                                Console.WriteLine("\n Enter the first name and last name <firstName>,<lastName> of contact you want to delete: \n");
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
                                new_AddressBook.WriteToAddressBook_UsingJSON();
                                break;
                            case 9:
                                new_AddressBook.ReadFromAddressBook_UsingJSON();
                                break;
                            case 10:
                                exit_Prgram = true;
                                break;

                            default:
                                Console.WriteLine("Invalid Input");
                                break;
                        }

                        //Console.WriteLine("Do you want to continue ? y/n : \n ");
                        //string input_Read = Console.ReadLine();
                        //if (Console.ReadLine() == "n")
                        //{
                        //    exit_Prgram = true;
                        //}
                        //else if()

                    }

                    exit_Prgram = false;

                }
                else 
                {
                    if (address_book_list.Count > 0)
                    {
                        foreach (var i in address_book_list)
                        {
                            Console.WriteLine("Address Book name is : \n " + i.Key);
                            i.Value.getPersonDetails();
                        }
                        
                    }
                    exit_MainProgram = true;
                }
                
            }
            


        }
    }
}
