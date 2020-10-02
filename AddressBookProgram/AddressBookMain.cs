using System;

namespace AddressBookProgram
{
    class AddressBookMain
    {
        static void Main(string[] args)
        {
            String[] person_Details = new string[8];
            Console.WriteLine("Welcome to Address Book Program");
            Boolean exit_Prgram = false;
            int input_Option = 0;
            String input_String="";
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
                        Console.WriteLine("\n Enter the Contact details of a person : (fn,ln,addr,city,state,zip,phn,id");
                        input_String = Console.ReadLine();
                        person_Details = input_String.Split(',');
                        foreach (var i in person_Details)
                        {
                            Console.WriteLine(i);
                        }
                        //details.AddContact(input_Option_string);
                        break;
                    case 2:
                        Console.WriteLine("\n Enter the first name and last name of that contact you want to edit: ");
                        input_String = Console.ReadLine();
                        //details.EditContact(input_String);
                        break;
                    case 3:
                        Console.WriteLine("\n Enter the first name and last name of contact you want to delete: ");
                        input_String = Console.ReadLine();
                        //details.DeleteContact(input_String);
                        break;
                    case 4:
                        //details.DisplayContacts();
                        break;
                }

                Console.WriteLine("Do yu want to continue ? Y/N : ");
                if (Console.ReadLine() == "n")
                {
                    exit_Prgram = true;
                }
                //string contact_Input = Console.ReadLine();
                
            }


            
        }
    }
}
