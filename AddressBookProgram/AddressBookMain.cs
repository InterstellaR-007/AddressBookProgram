using System;

namespace AddressBookProgram
{
    class AddressBookMain
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome to Address Book Program");
            Console.WriteLine("Enter the Contact details of a person : (fn,ln,addr,city,state,zip,phn,id");
            string contact_Input = Console.ReadLine();
            
            ContactPerson Details = new ContactPerson();
            Details.AddContact(contact_Input);
            Details.getPersonDetails();
            
        }
    }
}
