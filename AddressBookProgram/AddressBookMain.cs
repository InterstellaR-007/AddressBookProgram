﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AddressBookProgram
{

    /// <summary>
    /// Validation class for checking contact input fields
    /// </summary>
    public class InputValidation
    {
        // Dictionary storing the Regex string (Value) for each contact field (key) 
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


        /// <summary>
        /// Determines whether entered input is valid acc to Regex constraint
        /// </summary>
        /// <param name="field_Name">Name of the field.</param>
        /// <param name="input_Value">The input value.</param>
        /// <returns>
        ///   <c>true</c> if input field matches the regex ; otherwise, <c>false</c>.
        /// </returns>
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
    /// Main Address Book Program UI
    /// </summary>
    class AddressBookMain
    {
        static void Main(string[] args)
        {
            //Dictionary to store each AddressBook object with unique Name key
            Dictionary<String,ContactDetails_BL> address_book_list = new Dictionary<string,ContactDetails_BL>();

            //List of Contact fields 
            List<string> field_List = new List<string>() { "First Name", "Last Name", "Address", "City", "State","Pin Code", "Phone Number", "Email Id" };


            Console.WriteLine("Welcome to Address Book Program");

            Boolean exit_Prgram = false;
            Boolean exit_MainProgram = false;
            
            
            String string_limiter = ",";
            
            //loop for each AddressBook initialisation
            while (exit_MainProgram != true)
            {
                // User prompt
                Console.WriteLine(" \nEnter a new Address book? (y/n) ");
                
                if (Console.ReadLine() == "y")
                {
                    //Create a new Address Book BL object using Dependency Injection
                   
                    ContactDetails_BL contactDetails_BL = new ContactDetails_BL(new ContactDetailsBuilder());
                    Console.WriteLine("\nEnter the Address Book name: ");
                    String unique_Name = Console.ReadLine();
                    string field_Input;

                    //set the Address Book name
                    
                    contactDetails_BL.set_AddressBook_Name(unique_Name);
                    
                    //Adding current Address book to global List
                    address_book_list.Add(unique_Name, contactDetails_BL);

                    //Loop for Contact based operation for each Address Book
                    while (exit_Prgram != true)
                    {
                        // UI for Operations List

                        int input_Option; 
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
                        Console.WriteLine("10: Read from Address Book CSV file");
                        Console.WriteLine("11: Write to Address Book CSV file");
                        Console.WriteLine("\n Database Operations \n");
                        Console.WriteLine("12: Insert Current Contacts to Database");
                        Console.WriteLine("13: Delete a Contact from Database");
                        Console.WriteLine("14: Read Contact List from Database");
                        Console.WriteLine("15: Exit Program\n");


                        input_Option = int.Parse(Console.ReadLine());
                        switch (input_Option)
                        {

                            case 1: //Add Contact
                                Console.WriteLine("Enter the Contact details of a person : \n");

                                //Making instance of inputValidation Class
                                InputValidation inputValidation = new InputValidation();
                                string input_String = "";
                                foreach (var i in field_List)
                                {

                                    Console.WriteLine(i + ":");

                                    while (true)
                                    {

                                        field_Input = Console.ReadLine();
                                        
                                        //if Input doesnt match the regex pattern
                                        if(inputValidation.isInputValid(i, field_Input) == false)
                                        {
                                            Console.WriteLine("input detail is Invalid, Try Again");
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                        
                                    //appending each input field value to single string 
                                    input_String = input_String + field_Input + string_limiter;

                                }

                                //Pasing appended string to AddContact Method
                                contactDetails_BL.AddContact(input_String);
                                
                                
                                break;

                            case 2: // Editing Contact
                                Console.WriteLine("\n Enter the first name and last name <firstName>,<lastName> of that contact you want to edit: \n");
                                input_String = Console.ReadLine();
                                
                                contactDetails_BL.EditContactDetails(input_String);
                                break;

                            case 3: // Deleting Contact
                                Console.WriteLine("\n Enter the first name and last name <firstName>,<lastName> of contact you want to delete: \n");
                                input_String = Console.ReadLine();
                                
                                contactDetails_BL.DeleteContact(input_String);
                                break;

                            case 4: // Print Contacts
                                
                                contactDetails_BL.getPersonDetails();
                                break;

                            case 5: // Print Contacts from particular city/state
                                
                                contactDetails_BL.get_PersonDetails_By_City_or_State();
                                break;

                            case 6: // Sort the list wrt first name in alphabetical order
                                
                                contactDetails_BL.sort_Aphabetically();
                                break;

                            case 7: // Sort the list wrt State/City/Zip
                                
                                contactDetails_BL.sort_By_StateCityZip();
                                break;

                            case 8: // Write Contacts to JSON File
                                
                                contactDetails_BL.WriteToAddressBook_UsingJSON();
                                break;

                            case 9: // Read Contacts from JSON File
                                
                                contactDetails_BL.ReadFromAddressBook_UsingJSON();
                                break;

                            case 10: // Read Contacts from CSV File
                                
                                contactDetails_BL.ReadFromAddressBook_UsingCSV();
                                break;

                            case 11: // Write Contacts to CSV File
                                
                                contactDetails_BL.WriteToAddressBook_UsingCSV();
                                break;

                            case 12: //List of current Local Contacts added to Database using TPL Library(Threads)

                                List<ContactDetail> current_Contacts = contactDetails_BL.GetContactDetails();

                                contactDetails_BL.InsertContact_into_DB(unique_Name,current_Contacts);

                                break;

                            case 13: // Delete Contact based on Contact Name

                                Console.WriteLine("\n Enter the Person First Name:");
                                string first_Name = Console.ReadLine();

                                Console.WriteLine("Enter the person Last Name:");
                                string last_Name = Console.ReadLine();


                                if (contactDetails_BL.DeleteContact_fromDB(unique_Name, first_Name, last_Name))
                                {
                                    Console.WriteLine("Contact Deleted");
                                }
                                else
                                    Console.WriteLine("Deletion Failed");

                                break;

                            case 14: //Read Contact Details of person from AddressBook Table in DB

                                contactDetails_BL.ReadContacts_fromDB(unique_Name);
                                break;

                            case 15: // Exit current Operations loop
                                exit_Prgram = true;
                                break;

                            default: // for invalid switch input
                                Console.WriteLine("Invalid Input");
                                break;
                        }


                    }

                    exit_Prgram = false;

                }
                else 
                {
                    // Checking if any address book exists
                    if (address_book_list.Count > 0)
                    {
                        // Printing all address book with its current saved contacts
                        foreach (var i in address_book_list)
                        {
                            Console.WriteLine("Address Book name is : \n " + i.Key);
                            i.Value.getPersonDetails();
                        }
                        
                    }
                    //flags exit program ture
                    exit_MainProgram = true;
                }
                
            }
            


        }
    }
}
