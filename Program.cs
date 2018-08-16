/*
 * Generate txt file for JMeter load testing of Global Phone web API
 * Program.cs
 * 
 * Reads in a list of phones from a SQL table. For each phone number, ths program
 * runs it through the Global Phone web API and stores the request and response 
 * fields in a txt file named by the user
 * 
 * @author Alyssa House
 */

using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GenerateCSVforGlobalPhoneJMeter
{
    class Program
    {
        // fields
        private static int count = 1;

        static void Main(string[] args)
        {
            // clear file
            System.IO.File.WriteAllText(@"", "");   //path to .txt or .csv file to be written

            List<RequestObject> reqObjs = BuildRequestObjectsList();
            //Console.WriteLine(reqObjs.Count);
            foreach (RequestObject reqObj in reqObjs)
            {
                Record record = RunGlobalPhoneGETRequestAsync(reqObj.transmissionRef, reqObj.phone).GetAwaiter().GetResult();

                // Set all the returned fields from the GET Response to the expected fields in the request object
                reqObj.expectedResults = record.Results;
                reqObj.expectedPhoneNumber = record.PhoneNumber;
                reqObj.expectedCountryAbbreviation = record.CountryAbbreviation;
                reqObj.expectedLatitude = record.Latitude;
                reqObj.expectedLocality = record.Locality;
                reqObj.expectedLongitude = record.Longitude;
                reqObj.expectedPhoneSubscriberNumber = record.PhoneSubscriberNumber;
                reqObj.expectedPostalCode = record.PostalCode;

                WriteToFile(reqObj);
            }


            // keep console open
            Console.WriteLine("Program finished executing successfully.");
            Console.Read();
        }

        static async Task<Record> RunGlobalPhoneGETRequestAsync(string TransmissionReference, string Phone)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("");   // uri for Global Phone web API
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // send get request
                Record record = await sendGlobalPhoneGETRequestAsync(TransmissionReference, Phone);

                return record;
            }
        }

        public static SqlDataReader ReadInPhonesFromSQL(string ReadTableName)
        {
            // create connection string
            SqlConnectionStringBuilder connString = new SqlConnectionStringBuilder();
            BuildConnectionString(connString);

            // create connection
            SqlConnection connection = new SqlConnection(connString.ToString());

            // Set query to be used 
            string query = "SELECT distinct top (15000) Phone FROM " + ReadTableName + " where Phone <> null or phone <> ''";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Connection.Open();
                // parameterize query?

                return command.ExecuteReader();
            }
        }

        public static List<RequestObject> BuildRequestObjectsList()
        {
            List<RequestObject> reqObjs = new List<RequestObject>();
            using (SqlDataReader reader = ReadInPhonesFromSQL(""))  // table name
            {


                while (reader.Read()) // for each row
                {
                    RequestObject reqObj = new RequestObject(reader["Phone"].ToString().Trim());
                    reqObjs.Add(reqObj);
                }
            }
            return reqObjs;
        }

        public static SqlConnectionStringBuilder BuildConnectionString(SqlConnectionStringBuilder connString)
        {
            connString.DataSource = "";                     // Server
            connString.InitialCatalog = "";                 // Database
            connString.IntegratedSecurity = true;           // Connection type: Integrated Security

            return connString;
        }

        public static async Task<Record> sendGlobalPhoneGETRequestAsync(string TransmissionReference, string Phone)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("");   // uri for web API Global Phone

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // build get request string
                string requestParameters = "id=" + "&t=" + TransmissionReference + "&phone=" + Phone;   // insert customer ID

                HttpResponseMessage response = await client.GetAsync("v4/WEB/globalphone/doglobalphone?" + requestParameters);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    RootObject deserializedRootObj = JsonConvert.DeserializeObject<RootObject>(json);
                    Record recordObj = deserializedRootObj.Records[0];
                    return recordObj;
                }

            }
            return null;
        }

        public static void WriteToFile(RequestObject reqObj)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"", true)) // path to .csv or .txt file
            {
                if (String.IsNullOrEmpty(reqObj.expectedPhoneNumber) || reqObj.expectedResults.Contains("PE04"))
                {
                    //skip
                    return;
                }
                reqObj.transmissionRef = "entryNum_" + count++;
                Console.WriteLine(reqObj.transmissionRef);

                StringBuilder sb = new StringBuilder();
                sb.Append(reqObj.transmissionRef + "|");
                sb.Append(reqObj.expectedResults + "|");
                sb.Append(reqObj.expectedPhoneNumber + "|");
                sb.Append(reqObj.expectedCountryAbbreviation + "|");
                sb.Append(reqObj.expectedLatitude + "|");
                sb.Append(reqObj.expectedLocality + "|");
                sb.Append(reqObj.expectedLongitude + "|");
                sb.Append(reqObj.expectedPhoneSubscriberNumber + "|");
                sb.Append(reqObj.expectedPostalCode + "|");
                file.WriteLine(sb.ToString());
            }
        }
    }
}
