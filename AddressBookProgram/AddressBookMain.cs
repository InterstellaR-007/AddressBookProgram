using System;

namespace AddressBookProgram
{
    class AddressBookMain
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome to Address Book Program");
            String contact_Input1 = "anuj,sharma,88/A,lucknow,up,229406,8319293516,sample@gmail.com";
            String contact_Input2 = "rohit,verma,44/A,mumbai,Maha,229401,8319293512,sample2@gmail.com";
            String contact_Input3 = "umm,sharma,88/A,lucknow,up,229406,8319293513,sample3@gmail.com";

                        
            ContactPerson Details = new ContactPerson();
            Details.AddContact(contact_Input1);
            Details.AddContact(contact_Input2);
            //Details.AddContact(contact_Input3);
            Details.getPersonDetails();

            Console.WriteLine("Select the contact first and last name you want to delete : ");
            String delete_Contact_Input = Console.ReadLine();
            Details.DeleteContact(delete_Contact_Input);
            Details.getPersonDetails();


        }
    }
}
