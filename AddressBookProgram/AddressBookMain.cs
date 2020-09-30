using System;

namespace AddressBookProgram
{
    class AddressBookMain
    {
        static void Main(string[] args)
        {
            String[] person_Details = new string[8];
            Console.WriteLine("Welcome to Address Book Program");
            Console.WriteLine("Enter the Contact details of a person : (fn,ln,addr,city,state,zip,phn,id");
            string contact_Input = Console.ReadLine();
            person_Details = contact_Input.Split(',');
            /*foreach(var i in person_Details)
            {
                Console.WriteLine(i);
            }*/


            
        }
    }
}
