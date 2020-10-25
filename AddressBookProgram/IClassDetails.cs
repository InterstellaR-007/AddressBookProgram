using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookProgram
{
    interface IClassDetails
    {

        public void set_AddressBook_Name(String unique_Name);
        public void AddContact(String input_string);
        public void getPersonDetails();
        public void get_PersonDetails_By_City_or_State();

        public void sort_Aphabetically();
        public void DeleteContact(String input_detail);
        public void EditContactDetails(String input_detail);




    }
}
