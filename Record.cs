/*
 * Generate txt file for JMeter load testing of Global Phone web API
 * Record.cs
 * 
 * An object class that holds the keys and values of the JSON Record array 
 * from the JSON response from the Global Phone web API
 * 
 * @author Alyssa House
 */

namespace GenerateCSVforGlobalPhoneJMeter
{
    class Record
    {
        public string RecordID { get; set; }
        public string Results { get; set; }
        public string PhoneNumber { get; set; }
        public string AdministrativeArea { get; set; }
        public string CountryAbbreviation { get; set; }
        public string CountryName { get; set; }
        public string Carrier { get; set; }
        public string CallerID { get; set; }
        public string DST { get; set; }
        public string InternationalPhoneNumber { get; set; }
        public string Language { get; set; }
        public string Latitude { get; set; }
        public string Locality { get; set; }
        public string Longitude { get; set; }
        public string PhoneInternationalPrefix { get; set; }
        public string PhoneCountryDialingCode { get; set; }
        public string PhoneNationPrefix { get; set; }
        public string PhoneNationalDestinationCode { get; set; }
        public string PhoneSubscriberNumber { get; set; }
        public string UTC { get; set; }
        public string TimeZoneCode { get; set; }
        public string TimeZoneName { get; set; }
        public string PostalCode { get; set; }
        public object Suggestions { get; set; }

        public override string ToString()
        {
            return "RecordID: " + RecordID + "\nResults: " + Results + "\nPhoneNumber: " + PhoneNumber + "\n";
        }
    }


}
