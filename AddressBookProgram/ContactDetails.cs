using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace AddressBookProgram
{
    class ContactDetails: IClassDetails
    {
        Dictionary<String, String> PersonDetailsByCity = new Dictionary<string, string>();
        Dictionary<String, String> PersonDetailsByState = new Dictionary<string, string>();

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
        public ContactDetails()
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
        
        public String[] detail_Field_Value = new String[8];
        ArrayList contact_List = new ArrayList();

        public Boolean CheckDuplicate(String first_Name,String last_Name)
        {
            foreach (ContactDetails person in contact_List)
            {
                if (person.detail_Field_Value[0].Equals(first_Name) && person.detail_Field_Value[1].Equals(last_Name))
                    return true;
              
            }
            return false;
        }

        public void AddContact(String input_string)
            {

            String[] input_Field_Value = new String[8];
            input_Field_Value = input_string.Split(",");
            

            if (CheckDuplicate(input_Field_Value[0],input_Field_Value[1]))
            {
                Console.WriteLine("Person already exists in Record");
            }
            else
            {
                ContactDetails person = new ContactDetails();
                for (int i = 0; i < 8; i++)
                {
                    person.detail_Field_Value[i] = input_Field_Value[i];
                }

                PersonDetailsByCity.Add(person.detail_Field_Value[0] + " " + person.detail_Field_Value[1], person.detail_Field_Value[3]);

                PersonDetailsByState.Add(person.detail_Field_Value[0] + " " + person.detail_Field_Value[1], person.detail_Field_Value[4]);
                contact_List.Add(person);
                Console.WriteLine("Contact Added");
            }

            

            }

        public void getPersonDetails()
        {
            
            if (contact_List.Count == 0)
                Console.WriteLine("No records exist");
            else
            {
                Console.WriteLine("No of Contacts in Database: " + contact_List.Count);
                foreach (ContactDetails person in contact_List)
                {
                    Console.WriteLine("\n" + " Person Details are : " + "\n");

                    Console.WriteLine("\n" + "First Name\t"+"Last Name\t"+ "Address\t"+"City\t" + "State\t" + "Pincode\t" + "Email\t");
                    Console.WriteLine("\n" + person.detail_Field_Value[0] +"\t" + person.detail_Field_Value[1] + "\t"+ person.detail_Field_Value[2] + "\t" + person.detail_Field_Value[3] + "\t"+person.detail_Field_Value[4] + "\t"+ person.detail_Field_Value[5] + "\t" + person.detail_Field_Value[6] + "\t" + person.detail_Field_Value[7] + "\t");
                    

                }

            }
        }

        public void DeleteContact(String input_detail)
        {
            int to_Be_Deleted = 4; ;
            int count=-1 ;
            foreach (ContactDetails person in contact_List)
            {
                count++;
                if (input_detail.CompareTo(person.detail_Field_Value[0] + "," + person.detail_Field_Value[1]) == 0)
                {
                     to_Be_Deleted = count;
                                

                }

            }
            
            contact_List.RemoveAt(to_Be_Deleted);
            Console.WriteLine("Contact Deleted");

        }
        public void EditContactDetails(String input_detail)
        {
            Boolean contact_Found = false;
            foreach(ContactDetails person in contact_List)
            {
                if (input_detail.CompareTo(person.detail_Field_Value[0] + "," + person.detail_Field_Value[1]) == 0)
                {
                    contact_Found = true;
                    Console.WriteLine("\n"+"Which detail field you want to edit of this person: ");
                    Console.WriteLine("0:fn 1:ln 2:add 3:city 4:state 5:pincode 6:phn 7:emailId" +"\n");

                    int field = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter the updated field data");
                    person.detail_Field_Value[field] = Console.ReadLine();
                    Console.WriteLine("Contact Editied");

                }
     
            }
            if(contact_Found==false)
                Console.WriteLine("Contact not found");


        }
    }
}



