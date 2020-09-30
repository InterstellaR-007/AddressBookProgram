using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AddressBookProgram
{
    class ContactPerson
    {
        private String first_Name;
        private String last_Name;
        private String address;
        private String city;
        private String state;
        private String pincode;
        private String phone_Number;
        private String email;
        private String details_InOne;
        ArrayList contact_List = new ArrayList();

        public void AddContact(String input_string)
            {
            details_InOne = input_string;
            String[] detail_Field = new String[8];
            detail_Field = input_string.Split(',');
            ContactPerson person = new ContactPerson();
            person.first_Name = detail_Field[0];
            person.last_Name = detail_Field[1];
            person.address = detail_Field[2];
            person.city = detail_Field[3];
            person.state = detail_Field[4];
            person.pincode = detail_Field[5];
            person.phone_Number = detail_Field[6];
            person.email = detail_Field[7];
            contact_List.Add(person);
            }

        public void getPersonDetails()
        {
            foreach(var person in contact_List)
            {
                Console.WriteLine("Entered Details is : " + details_InOne );
            }
        }
    }
}



