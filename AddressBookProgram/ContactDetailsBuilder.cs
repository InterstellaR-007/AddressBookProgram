using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace AddressBookProgram
{
    /// <summary>
    /// COntact Details Builder Main
    /// </summary>
    /// <seealso cref="AddressBookProgram.IClassDetailsBuilder" />
    class ContactDetailsBuilder : IClassDetailsBuilder
    {
        

        Dictionary<String, String> PersonDetailsByCity = new Dictionary<string, string>();
        Dictionary<String, String> PersonDetailsByState = new Dictionary<string, string>();
        string Field_Title = String.Format("{0,-12}{1,-12}{2,-12}{3,-12}{4,-12}{5,-12}{6,-12}{7,-12}\n", "First Name", "Last Name", "Address", "City", "State", "PinCode", "phn Num", "Email");

        public void get_PersonDetails_By_City_or_State()
        {
            int count_ByState = 0;
            int count_ByCity = 0;
            
            Console.WriteLine("Enter the city or state:");
            string input_Detail = Console.ReadLine();
            Boolean city_Detail_Found = false;
            Boolean state_Detail_Found = false;
            foreach (var person in PersonDetailsByCity)
            {
                if (person.Value.Equals(input_Detail))
                {
                    Console.WriteLine("Searched Name is: " + person.Key);
                    count_ByCity++;
                    city_Detail_Found = true;
                }
                
            }
            
            foreach (var person in PersonDetailsByState)
            {
                if (person.Value.Equals(input_Detail))
                {
                    Console.WriteLine("Searched Name is: " + person.Key);
                    count_ByState++;
                    state_Detail_Found = true;
                }

            }
            if (!city_Detail_Found && !state_Detail_Found)
                Console.WriteLine("No details Found");
            else if(city_Detail_Found)
            {
                Console.WriteLine("Total number of persons living in " + input_Detail + " are:" + count_ByCity);
            }
            else
            {
                Console.WriteLine("Total number of persons living in " + input_Detail + " are:" + count_ByState);
            }
        }
        public ContactDetailsBuilder()
        {
            
            Dictionary<int,String> field_map = new Dictionary<int, String>();
            field_map.Add( 0, "first_Name");
            field_map.Add(1, "last_Name");
            field_map.Add(2,"address");
            field_map.Add(3, "city");
            field_map.Add(4, "state");
            field_map.Add( 5, "pincode");
            field_map.Add( 6, "phone_Number");
            field_map.Add( 7, "email_Id");
        }
        public void set_AddressBook_Name(String unique_Name)
        {
            this.unique_Name = unique_Name;
        }
       

        private String unique_Name;

        //public String[] detail_Field_Value = new String[8];
        ContactDetail person = new ContactDetail();
        List<ContactDetail> contact_List = new List<ContactDetail>();

        /// <summary>
        /// Checks the duplicate.
        /// </summary>
        /// <param name="first_Name">The first name.</param>
        /// <param name="last_Name">The last name.</param>
        /// <returns></returns>
        public Boolean CheckDuplicate(String first_Name,String last_Name)
        {
            //var find_Duplicate = contact_List.Contains();

            foreach (ContactDetail person in contact_List)
            {
                if (person.first_Name.Equals(first_Name) && person.last_Name.Equals(last_Name))
                    return true;
              
            }
            return false;
        }
        /// <summary>
        /// Sorts the by state city zip.
        /// </summary>
        public void sort_By_StateCityZip()
        {
            Console.WriteLine("Enter the field to be sorted : 1- City 2- State 3- Zip");
            int input_field = int.Parse(Console.ReadLine());

            switch (input_field)
            {
                case 1:
                    contact_List.Sort((x, y) => x.city.CompareTo(y.city));
                    Console.WriteLine("Sorting is Done using City");
                    getPersonDetails();
                    break;
                case 2:
                    contact_List.Sort((x, y) => x.state.CompareTo(y.state));
                    Console.WriteLine("Sorting is Done using State");
                    getPersonDetails();
                    break;
                case 3:
                    contact_List.Sort((x, y) => x.pincode.CompareTo(y.pincode));
                    Console.WriteLine("Sorting is Done using Zip Code");
                    getPersonDetails();
                    break;

            }
        }
        /// <summary>
        /// Sorts the aphabetically.
        /// </summary>
        public void sort_Aphabetically()
        {
            if (contact_List.Count == 0)
                Console.WriteLine("No data Entered to sort");
            else
            {
                List<ContactDetailsBuilder> sorted_Contact_List = new List<ContactDetailsBuilder>();
                contact_List.Sort((x, y) => x.first_Name.CompareTo(y.first_Name));
                Console.WriteLine("Sorting is Done using First name");
            }
        }

        /// <summary>
        /// Adds the contact.
        /// </summary>
        /// <param name="input_string">The input string.</param>
        public void AddContact(String input_string)
            {
            ValidationContext context = new ValidationContext(person, null, null);
            List<ValidationResult> result = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(person, context, result, true);

            String[] input_Field_Value = new String[8];
            input_Field_Value = input_string.Split(",");
            

            if (CheckDuplicate(input_Field_Value[0],input_Field_Value[1]))
            {
                Console.WriteLine("Person already exists in Record");
            }
            else
            {
                
                
                person.first_Name = input_Field_Value[0];
                person.last_Name = input_Field_Value[1];
                person.address= input_Field_Value[2];
                person.city = input_Field_Value[3];
                person.state = input_Field_Value[4];
                person.pincode = input_Field_Value[5];
                person.phoneNum = input_Field_Value[6];
                person.email = input_Field_Value[7];

                PersonDetailsByCity.Add(person.first_Name + " " + person.last_Name, person.city); ;

                PersonDetailsByState.Add(person.first_Name + " " + person.last_Name, person.state);

                contact_List.Add(person);
                Console.WriteLine("Contact Added");
            }

            

            }

        /// <summary>
        /// Gets the person details.
        /// </summary>
        public void getPersonDetails()
        {
            
            if (contact_List.Count == 0)
                Console.WriteLine("No records exist");
            else
            {
                Console.WriteLine("No of Contacts in Database: " + contact_List.Count);
                Console.WriteLine(Field_Title);
                foreach (ContactDetail person in contact_List)
                {

                    string tabular_Output = String.Format("{0,-12}{1,-12}{2,-12}{3,-12}{4,-12}{5,-12}{6,-12}{7,-12}", person.first_Name, person.last_Name, person.address, person.city, person.state, person.pincode, person.phoneNum, person.email);
                    Console.WriteLine(tabular_Output);

                }

            }
        }
        /// <summary>
        /// Writes to address book using io.
        /// </summary>
        public void WriteToAddressBook_UsingIO()
        {
            string path = @"C:\Users\anujs\source\repos\AddressBookProgram\AddressBookProgram\AddressBookJson.json";

            JsonSerializer serializer = new JsonSerializer();
            using(StreamWriter sw = new StreamWriter(path))
            using(JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, contact_List);
            }
        }
        /// <summary>
        /// Reads from address book using io.
        /// </summary>
        public void ReadFromAddressBook_UsingIO()
        {
            string import_path = @"C:\Users\anujs\source\repos\AddressBookProgram\AddressBookProgram\AddressBookJson.json";
            IList<ContactDetail> person_Contacts = JsonConvert.DeserializeObject<IList<ContactDetail>>(File.ReadAllText(import_path));
            Console.WriteLine("Done Reading");

        }

        /// <summary>
        /// Deletes the contact.
        /// </summary>
        /// <param name="input_detail">The input detail.</param>
        public void DeleteContact(String input_detail)
        {
            int to_Be_Deleted = 4; ;
            int count=-1 ;
            foreach (ContactDetail person in contact_List)
            {
                count++;
                if (input_detail.CompareTo(person.first_Name + "," + person.last_Name) == 0)
                {
                     to_Be_Deleted = count;
                                

                }

            }
            
            contact_List.RemoveAt(to_Be_Deleted);
            Console.WriteLine("Contact Deleted");

        }
        /// <summary>
        /// Edits the contact details.
        /// </summary>
        /// <param name="input_detail">The input detail.</param>
        public void EditContactDetails(String input_detail)
        {
            Boolean contact_Found = false;
            foreach(ContactDetail person in contact_List)
            {
                if (input_detail.CompareTo(person.first_Name + "," + person.last_Name) == 0)
                {
                    contact_Found = true;
                    Console.WriteLine("\n"+"Which detail field you want to edit of this person: ");
                    Console.WriteLine("0:fn 1:ln 2:add 3:city 4:state 5:pincode 6:phn 7:emailId" +"\n");

                    int field = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter the updated field data");
                    switch (field)
                    {
                        case 0:
                            person.first_Name = Console.ReadLine();
                            Console.WriteLine("Field Updated");
                            break;
                        case 1:
                            person.last_Name = Console.ReadLine();
                            Console.WriteLine("Field Updated");
                            break;
                        case 2:
                            person.address = Console.ReadLine();
                            Console.WriteLine("Field Updated");
                            break;
                        case 3:
                            person.city = Console.ReadLine();
                            Console.WriteLine("Field Updated");
                            break;
                        case 4:
                            person.state = Console.ReadLine();
                            Console.WriteLine("Field Updated");
                            break;
                        case 5:
                            person.pincode = Console.ReadLine();
                            Console.WriteLine("Field Updated");
                            break;
                        case 6:
                            person.phoneNum = Console.ReadLine();
                            Console.WriteLine("Field Updated");
                            break;
                        case 7:
                            person.email = Console.ReadLine();
                            Console.WriteLine("Field Updated");
                            break;
                    }

                     

                }
     
            }
            if(contact_Found==false)
                Console.WriteLine("Contact not found");


        }
    }
}



