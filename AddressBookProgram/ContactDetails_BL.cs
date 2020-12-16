using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookProgram
{
    /// <summary>
    /// Businesss Layer Class for Contact Details Builder Dependency Injection
    /// </summary>
    public class ContactDetails_BL
    {
        public IClassDetailsBuilder classDetailsBuilder;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactDetails_BL"/> class.
        /// </summary>
        /// <param name="classDetailsBuilder">The class details builder.</param>
        public ContactDetails_BL(IClassDetailsBuilder classDetailsBuilder)
        {
            this.classDetailsBuilder = classDetailsBuilder;
        }

        /// <summary>
        /// Sets the name of the address book.
        /// </summary>
        /// <param name="unique_Name">Name of the unique.</param>
        public void set_AddressBook_Name(String unique_Name)
        {
            classDetailsBuilder.set_AddressBook_Name(unique_Name);
        }
        /// <summary>
        /// Adds the contact.
        /// </summary>
        /// <param name="input_string">The input string.</param>
        public void AddContact(String input_string)
        {
            classDetailsBuilder.AddContact(input_string);
        }

        /// <summary>
        /// Gets the person details.
        /// </summary>
        public void getPersonDetails()
        {
            classDetailsBuilder.getPersonDetails();
        }
        /// <summary>
        /// Gets the state of the person details by city or.
        /// </summary>
        public void get_PersonDetails_By_City_or_State()
        {
            classDetailsBuilder.get_PersonDetails_By_City_or_State();
        }

        /// <summary>
        /// Sorts the by state city zip.
        /// </summary>
        public void sort_By_StateCityZip()
        {
            classDetailsBuilder.sort_By_StateCityZip();
        }

        /// <summary>
        /// Writes to address book using CSV.
        /// </summary>
        public void WriteToAddressBook_UsingCSV()
        {
            classDetailsBuilder.WriteToAddressBook_UsingCSV();
        }
        /// <summary>
        /// Reads from address book using CSV.
        /// </summary>
        public void ReadFromAddressBook_UsingCSV()
        {
            classDetailsBuilder.ReadFromAddressBook_UsingCSV();
        }

        /// <summary>
        /// Writes to address book using json.
        /// </summary>
        public void WriteToAddressBook_UsingJSON()
        {
            classDetailsBuilder.WriteToAddressBook_UsingJSON();
        }
        /// <summary>
        /// Reads from address book using json.
        /// </summary>
        public void ReadFromAddressBook_UsingJSON()
        {
            classDetailsBuilder.ReadFromAddressBook_UsingJSON();
        }

        /// <summary>
        /// Sorts the aphabetically.
        /// </summary>
        public void sort_Aphabetically()
        {
            classDetailsBuilder.sort_Aphabetically();
        }
        /// <summary>
        /// Deletes the contact.
        /// </summary>
        /// <param name="input_detail">The input detail.</param>
        public void DeleteContact(String input_detail)
        {
            classDetailsBuilder.DeleteContact(input_detail);
        }

        /// <summary>
        /// Edits the contact details.
        /// </summary>
        /// <param name="input_detail">The input detail.</param>
        public void EditContactDetails(String input_detail)
        {
            classDetailsBuilder.EditContactDetails(input_detail);
        }

    }
}
