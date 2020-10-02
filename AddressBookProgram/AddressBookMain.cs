using System;
using System.Collections.Generic;

namespace AddressBookProgram
{
    class AddressBookMain
    {
        static void Main(string[] args)
        {
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
            int input_Option = 0;
            
            String string_limiter = ",";
            String input_String = "";
            ContactDetails details = new ContactDetails();
            while (exit_Prgram != true)
            {
                Console.WriteLine("Select the option from below to execute: \n");
                Console.WriteLine("1: Add a Contact ");
                Console.WriteLine("2: Edit an existing Contact ");
                Console.WriteLine("3: Delete an exisiting Contact ");
                Console.WriteLine("4: Display Contact Details entered ");

                input_Option = int.Parse(Console.ReadLine());
                switch (input_Option)
                {

                    case 1:
                        Console.WriteLine("\n Enter the Contact details of a person : ");
                        foreach(var i in field_map)
                        {
                            Console.WriteLine(i.Key + ":");
                            input_String = input_String+ Console.ReadLine()+string_limiter;

                        }

                        details.AddContact(input_String);
                        break;

                    case 2:
                        Console.WriteLine("\n Enter the first name and last name of that contact you want to edit: ");
                        input_String = Console.ReadLine();
                        details.EditContactDetails(input_String);
                        break;

                    case 3:
                        Console.WriteLine("\n Enter the first name and last name of contact you want to delete: ");
                        input_String = Console.ReadLine();
                        details.DeleteContact(input_String);
                        break;

                    case 4:
                        details.getPersonDetails();
                        break;

                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }

                Console.WriteLine("Do you want to continue ? Y/N : ");
                if (Console.ReadLine() == "n")
                {
                    exit_Prgram = true;
                }




                
            }


        }
    }
}
