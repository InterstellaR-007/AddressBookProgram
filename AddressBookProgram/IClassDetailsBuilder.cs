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
        public void getPersonDetails();
        public void get_PersonDetails_By_City_or_State();

        public void sort_By_StateCityZip();

        public void WriteToAddressBook_UsingCSV();
        public void ReadFromAddressBook_UsingCSV();
        public void WriteToAddressBook_UsingJSON();
        public void ReadFromAddressBook_UsingJSON();

        public void sort_Aphabetically();
        public void DeleteContact(String input_detail);
        public void EditContactDetails(String input_detail);


    }
}
