﻿using System;
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
        
        private String[] detail_Field_Value = new String[8];
        ArrayList contact_List = new ArrayList();

        public void AddContact(String input_string)
            {
            String[] input_Field_Value = new String[8];
            input_Field_Value = input_string.Split(",");
            
            
            ContactDetails person = new ContactDetails();
            for(int i =0;i<8;i++)
            {
                person.detail_Field_Value[i] = input_Field_Value[i]; 
            }

            contact_List.Add(person);
            Console.WriteLine("Contact Added");

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


                    foreach (String s in person.detail_Field_Value)
                    {
                        Console.WriteLine("\t" + s);

                    }

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



