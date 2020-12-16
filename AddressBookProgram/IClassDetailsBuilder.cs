using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookProgram
{
    /// <summary>
    /// Interface for Contact Builder Class
    /// </summary>
    public interface IClassDetailsBuilder
    {

        public void set_AddressBook_Name(String unique_Name);
        public void AddContact(String input_string);
        public List<ContactDetail> GetContactDetails();
        public List<ContactDetail> printContactDetails();
        public void get_PersonDetails_By_City_or_State();

        public void sort_By_StateCityZip();

        public void WriteToAddressBook_UsingCSV();
        public void ReadFromAddressBook_UsingCSV();
        public void WriteToAddressBook_UsingJSON();
        public void ReadFromAddressBook_UsingJSON();

        public void sort_Aphabetically();
        public void DeleteContact(String input_detail);
        public void EditContactDetails(String input_detail);

        public bool InsertContact_into_DB(string bookName,ContactDetail contact);
        public bool DeleteContact_fromDB(string bookName, string firstName, string LastName);
        public bool UpdateContact_inDB(string first_Name,string last_Name,string bookName, ContactDetail contact);
        public void ReadContacts_fromDB(string bookName);


    }
}
