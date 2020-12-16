using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
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
    /// Contact Details Builder Main
    /// </summary>
    /// <seealso cref="AddressBookProgram.IClassDetailsBuilder" />
    class ContactDetailsBuilder : IClassDetailsBuilder
    {

        //Tabular formating for Contact Fields with fixed spacing
        string Field_Title = String.Format("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}{6,-15}{7,-15}\n", "First Name", "Last Name", "Address", "City", "State", "PinCode", "phn Num", "Email");

        string Field_Title_DB = String.Format("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}{6,-15}{7,-15}{8,-15}\n", "Book Name","First Name", "Last Name", "Address", "City", "State", "PinCode", "phn Num", "Email");



        /// <summary>
        /// Gets the name of the person by city or state.
        /// </summary>
        public void get_PersonDetails_By_City_or_State()
        {
            int count_ByState = 0;
            int count_ByCity = 0;
            
            Console.WriteLine("Enter the city or state:");
            string input_Detail = Console.ReadLine();
            Boolean city_Detail_Found = false;
            Boolean state_Detail_Found = false;

            //Searching for person using city field
            foreach (var person in contact_List)
            {
                if (person.city.Equals(input_Detail))
                {
                    Console.WriteLine("Searched Name is: " + person.first_Name+" "+person.last_Name);
                    count_ByCity++;
                    city_Detail_Found = true;
                }
                
            }

            //Searching for person using State field
            foreach (var person in contact_List)
            {
                if (person.state.Equals(input_Detail))
                {
                    Console.WriteLine("Searched Name is: " + person.first_Name + " " + person.last_Name);
                    count_ByState++;
                    state_Detail_Found = true;
                }

            }
            //Checking for no search result
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



        /// <summary>
        /// Initializes a new instance of the <see cref="ContactDetailsBuilder"/> class.
        /// </summary>
        public ContactDetailsBuilder()
        {
            //initialise dictionary with required field's key value pairs
            Dictionary<int,String> field_map = new Dictionary<int, String>();
            field_map.Add(0, "first_Name");
            field_map.Add(1, "last_Name");
            field_map.Add(2,"address");
            field_map.Add(3, "city");
            field_map.Add(4, "state");
            field_map.Add(5, "pincode");
            field_map.Add(6, "phone_Number");
            field_map.Add(7, "email_Id");
        }


        ///AddressBook unique name variable
        private String unique_Name;

        /// <summary>
        /// Sets the name of the address book.
        /// </summary>
        /// <param name="unique_Name">Name of the unique.</param>
        public void set_AddressBook_Name(String unique_Name)
        {
            this.unique_Name = unique_Name;
        }

        /// <summary>
        /// The contact list for maintianing all contacts during execution
        /// </summary>
        List<ContactDetail> contact_List = new List<ContactDetail>();

        /// <summary>
        /// Checks the duplicate.
        /// </summary>
        /// <param name="first_Name">The first name.</param>
        /// <param name="last_Name">The last name.</param>
        /// <returns></returns>
        public Boolean CheckDuplicate(String first_Name,String last_Name)
        {
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
            //prompt for user to choose sorting parameter
            Console.WriteLine("Enter the field to be sorted : 1- City 2- State 3- Zip");
            int input_field = int.Parse(Console.ReadLine());

            switch (input_field)
            {
                case 1:
                    //Sorting using city field
                    contact_List.Sort((x, y) => x.city.CompareTo(y.city));
                    Console.WriteLine("Sorting is Done using City \n");
                    printContactDetails();
                    break;
                case 2:
                    //Sorting using state field
                    contact_List.Sort((x, y) => x.state.CompareTo(y.state));
                    Console.WriteLine("Sorting is Done using State\n ");
                    printContactDetails();
                    break;
                case 3:
                    //Sorting using zipcode field
                    contact_List.Sort((x, y) => x.pincode.CompareTo(y.pincode));
                    Console.WriteLine("Sorting is Done using Zip Code\n ");
                    printContactDetails();
                    break;

            }
        }



        /// <summary>
        /// Sorts the aphabetically.
        /// </summary>
        public void sort_Aphabetically()
        {
            if (contact_List.Count == 0)
                Console.WriteLine("\n No data Entered to sort \n");
            else
            {
                List<ContactDetailsBuilder> sorted_Contact_List = new List<ContactDetailsBuilder>();
                contact_List.Sort((x, y) => x.first_Name.CompareTo(y.first_Name));
                Console.WriteLine("\n Sorting is Done using First name\n");
            }
        }



        /// <summary>
        /// Adds the contact.
        /// </summary>
        /// <param name="input_string">The input string.</param>
        public void AddContact(String input_string)
            {

            //Spliting input string with respective fields
            String[] input_Field_Value = new String[8];
            input_Field_Value = input_string.Split(",");
            
            //Check Duplicate withing existing records
            if (CheckDuplicate(input_Field_Value[0],input_Field_Value[1]))
            {
                Console.WriteLine("\n Person already exists in Record\n ");
            }
            else
            {
                //Adding new Contact object to List
                ContactDetail person = new ContactDetail();

                person.first_Name = input_Field_Value[0];
                person.last_Name = input_Field_Value[1];
                person.address= input_Field_Value[2];
                person.city = input_Field_Value[3];
                person.state = input_Field_Value[4];
                person.pincode = input_Field_Value[5];
                person.phoneNum = input_Field_Value[6];
                person.email = input_Field_Value[7];

                contact_List.Add(person);
                Console.WriteLine("\n Contact Added \n");
            }

            

            }

        public List<ContactDetail> GetContactDetails()
        {
            return contact_List;
        }



        /// <summary>
        /// Gets the person details.
        /// </summary>
        public List<ContactDetail> printContactDetails()
        {

            if (contact_List.Count == 0)
            {
                Console.WriteLine("No records exist");
                return null;
            }
            else
            {
                //Displays total count
                Console.WriteLine("No of Contacts in Database: " + contact_List.Count);
                Console.WriteLine(Field_Title);

                foreach (ContactDetail person in contact_List)
                {
                    //Prints Contact Details in Tabular format with fixed spacing
                    string tabular_Output = String.Format("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}{6,-15}{7,-15}", person.first_Name, person.last_Name, person.address, person.city, person.state, person.pincode, person.phoneNum, person.email);
                    Console.WriteLine(tabular_Output);

                }

                return contact_List;

            }
        }



        /// <summary>
        /// Writes to address book using CSV Helper Library.
        /// </summary>
        public void WriteToAddressBook_UsingCSV()
        {

            string path = @"C:\Users\Ajay Sharma\source\repos\AddressBookProgram\AddressBookProgram\AddressBook.csv";
            FileStream file = new FileStream(path, FileMode.Create,FileAccess.ReadWrite);

            using (StreamWriter sr = new StreamWriter(file))
            {
                using (var csv = new CsvWriter(sr, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(contact_List);
                    Console.WriteLine("\n Done Writing \n");
                }
            }
        }



        /// <summary>
        /// Reads from address book using CSV Helper Library.
        /// </summary>
        public void ReadFromAddressBook_UsingCSV()
        {
            string path = @"C:\Users\Ajay Sharma\source\repos\AddressBookProgram\AddressBookProgram\AddressBook.csv";

            using (StreamReader sr = new StreamReader(path))
            {
                using (var csv = new CsvReader(sr, CultureInfo.InvariantCulture))
                {

                    {
                        //csv.Configuration.HeaderValidated = null;

                        //Converting retrived IEnumerable Object to List and overriting it to contact_List
                        var records = csv.GetRecords<ContactDetail>().ToList();
                        contact_List = records;
                        
                    }
                    Console.WriteLine("\n Done Reading \n");
                }
            }
        }



        /// <summary>
        /// Writes to address book using NewtonSoft Json Library.
        /// </summary>
        public void WriteToAddressBook_UsingJSON()
        {
        
            string path = @"C:\Users\Ajay Sharma\source\repos\AddressBookProgram\AddressBookProgram\AddressBookJson.json";

            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(path))
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, contact_List);
                    Console.WriteLine("Done Writing to JSON file ! \n");
                }
            }
        }



        /// <summary>
        /// Reads from address book using NewtonSoft Json Library.
        /// </summary>
        public void ReadFromAddressBook_UsingJSON()
        {
            string import_path = @"C:\Users\Ajay Sharma\source\repos\AddressBookProgram\AddressBookProgram\AddressBookJson.json";
            IList<ContactDetail> person_Contacts = JsonConvert.DeserializeObject<IList<ContactDetail>>(File.ReadAllText(import_path));

            contact_List = (List<ContactDetail>)person_Contacts;

            Console.WriteLine("Done Reading from JSON File ! \n");


        }



        /// <summary>
        /// Deletes the contact.
        /// </summary>
        /// <param name="input_detail">The input detail.</param>
        public void DeleteContact(String input_detail)
        {
            int to_Be_Deleted = -1; ;
            int count=-1 ;
            foreach (ContactDetail person in contact_List)
            {
                count++;
                if (input_detail.CompareTo(person.first_Name + "," + person.last_Name) == 0)
                {
                     to_Be_Deleted = count;
                                

                }

            }
            if (to_Be_Deleted != -1)
            {
                contact_List.RemoveAt(to_Be_Deleted);
                Console.WriteLine("Contact Deleted !\n ");
            }
            else
                Console.WriteLine("Contact Not Found !\n");
            

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
                    Console.WriteLine("\nWhich detail field you want to edit of this person: ");
                    Console.WriteLine("0:fn 1:ln 2:add 3:city 4:state 5:pincode 6:phn 7:emailId\n");

                    int field = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter the updated field data");
                    switch (field)
                    {
                        case 0:
                            person.first_Name = Console.ReadLine();
                            
                            break;
                        case 1:
                            person.last_Name = Console.ReadLine();
                            
                            break;
                        case 2:
                            person.address = Console.ReadLine();
                            
                            break;
                        case 3:
                            person.city = Console.ReadLine();
                            
                            break;
                        case 4:
                            person.state = Console.ReadLine();
                           
                            break;
                        case 5:
                            person.pincode = Console.ReadLine();
                            
                            break;
                        case 6:
                            person.phoneNum = Console.ReadLine();
                            
                            break;
                        case 7:
                            person.email = Console.ReadLine();
                            
                            break;
                    }

                    Console.WriteLine("\n Field Updated ! \n ");



                }
     
            }
            if(contact_Found==false)
                Console.WriteLine("Contact not found \n");


        }

        public static string connection = @"Data Source=(localdb)\localdb_2;Initial Catalog=AddressBookService;Integrated Security=True";

        /// <summary>
        /// Inserts the contact into database.
        /// </summary>
        /// <param name="bookName">Name of the book.</param>
        /// <param name="contact">The contact.</param>
        /// <returns></returns>
        public bool InsertContact_into_DB(string bookName, ContactDetail contact)
        {
            // DML statement for inserting Employee object stored as String
            string sql = String.Format("Insert into AddressBook_ADO(book_name,first_Name,last_Name,address,city,state,zip,phone_Number,email)" + "Values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')",
                bookName, contact.first_Name, contact.last_Name, contact.address, contact.city,contact.state,contact.pincode,contact.phoneNum,contact.email);


            try
            {
                using (SqlConnection sqlConnection_add = new SqlConnection(connection))
                {

                    //set command with sql string argument
                    SqlCommand command = new SqlCommand(sql, sqlConnection_add);

                    //Open connection
                    sqlConnection_add.Open();

                    //Executing DML operation, getting affect rows due to operation
                    int rows_Affected = command.ExecuteNonQuery();


                    //If insertion affected the rows in table
                    if (rows_Affected == 1)
                    {
                        //Set Insertion flag returning it True
                        return true;


                    }

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }


            return false;
        }

        /// <summary>
        /// Deletes the contact from database.
        /// </summary>
        /// <param name="bookName">Name of the book.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="LastName">The last name.</param>
        /// <returns></returns>
        public bool DeleteContact_fromDB(string bookName, string firstName, string LastName)
        {
            // DML statement for inserting Contact object stored as String
            string sql = String.Format("Delete from AddressBook_ADO where book_name='{0}' and first_Name ='{1}' and last_Name='{2}'", bookName,firstName,LastName );


            try
            {
                using (SqlConnection sqlConnection_Del = new SqlConnection(connection))
                {

                    //set command with sql string argument
                    SqlCommand command = new SqlCommand(sql, sqlConnection_Del);
                    sqlConnection_Del.Open();

                    //Execute Deletion operation 
                    int rows_Affected = command.ExecuteNonQuery();

                    //If deletion affected the rows
                    if (rows_Affected > 0)
                    {
                        //set Deletion flag to True and return
                        return true;


                    }

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            

            return false;
        }


        /// <summary>
        /// Updates the contact in database.
        /// </summary>
        /// <param name="first_Name">The first name.</param>
        /// <param name="last_Name">The last name.</param>
        /// <param name="bookName">Name of the book.</param>
        /// <param name="contact">The contact.</param>
        /// <returns></returns>
        public bool UpdateContact_inDB(string first_Name,string last_Name,string bookName, ContactDetail contact)
        {
            try
            {
                using (SqlConnection sqlConnection_Upt = new SqlConnection(connection))
                {

                    sqlConnection_Upt.Open();
                    ContactDetail contact1 = new ContactDetail();

                    //setting command type as stored procedure
                    SqlCommand command = new SqlCommand("updateContactDetail", sqlConnection_Upt);
                    command.CommandType = CommandType.StoredProcedure;

                    //Setting parameters for stored procedure, passed as arguments
                    command.Parameters.AddWithValue("@in_book_name", bookName);
                    command.Parameters.AddWithValue("@in_first_Name", first_Name);
                    command.Parameters.AddWithValue("@in_last_Name", last_Name);
                    command.Parameters.AddWithValue("@book_name", bookName);
                    command.Parameters.AddWithValue("@first_Name", contact1.first_Name);
                    command.Parameters.AddWithValue("@last_Name", contact1.last_Name);
                    command.Parameters.AddWithValue("@address", contact1.address);
                    command.Parameters.AddWithValue("@city", contact1.city);
                    command.Parameters.AddWithValue("@state", contact1.state);
                    command.Parameters.AddWithValue("@zip", contact1.pincode);
                    command.Parameters.AddWithValue("@phone_Number", contact1.phoneNum);
                    command.Parameters.AddWithValue("@email", contact1.email);
                    

                    //get affected rows count
                    int affected_Rows = command.ExecuteNonQuery();

                    //if rows affected
                    if (affected_Rows > 0)
                    {
                        return true;


                    }
                    else
                    {
                        //Data with that particular details doesnt exist
                        Console.WriteLine("No data found");
                    }




                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }

        /// <summary>
        /// Reads the contacts from database.
        /// </summary>
        /// <param name="bookName">Name of the book.</param>
        /// <exception cref="Exception"></exception>
        public void ReadContacts_fromDB(string bookName)
        {
            try
            {
                ContactDetail contact = new ContactDetail();
                using (SqlConnection sqlConnection_Read = new SqlConnection(connection))
                {

                    string query = String.Format("Select * from AddressBook_ADO where book_name='{0}'",bookName);

                    SqlCommand cmd = new SqlCommand(query, sqlConnection_Read);

                    sqlConnection_Read.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();


                    if (sqlDataReader.HasRows)
                    {
                        Console.WriteLine(Field_Title_DB);
                        while (sqlDataReader.Read())
                        {
                            

                            string tabular_Output = String.Format("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}{6,-15}{7,-15}{8,-15}",
                                sqlDataReader.GetString(0), sqlDataReader.GetString(1), sqlDataReader.GetString(2), sqlDataReader.GetString(3), sqlDataReader.GetString(4), sqlDataReader.GetString(5), sqlDataReader.GetString(6), sqlDataReader.GetString(7), sqlDataReader.GetString(8));

                            Console.WriteLine(tabular_Output);
                        }

                    }
                    else
                    {
                        Console.WriteLine("no data ");

                    }
                    sqlDataReader.Close();


                }

            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}



