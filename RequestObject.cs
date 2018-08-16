/*
 * Generate txt file for JMeter load testing of Global Phone web API
 * RequestObject.cs
 * 
 * An object class that holds the keys and values to be put into the 
 * txt file
 * 
 * @author Alyssa House
 */

using System.Text;

namespace GenerateCSVforGlobalPhoneJMeter
{
    class RequestObject
    {
        public RequestObject()
        {

        }

        public RequestObject(string Phone)
        {
            this.phone = Phone;
        }

        public RequestObject(string TransmissionRef, string Phone)
        {
            this.transmissionRef = TransmissionRef;
            this.phone = Phone;
        }

        // fields
        public string transmissionRef{ get; set; }
        public string phone{ get; set; }
        public string expectedResults{ get; set; }
        public string expectedPhoneNumber{ get; set; }
        public string expectedAdministrativeArea{ get; set; }
        public string expectedCountryAbbreviation{ get; set; }
        public string expectedCountryName{ get; set; }
        public string expectedCarrier{ get; set; }
        public string expectedCallerID{ get; set; }
        public string expectedDST{ get; set; }
        public string expectedInternationalPhoneNumber{ get; set; }
        public string expectedLanguage{ get; set; }
        public string expectedLatitude{ get; set; }
        public string expectedLocality { get; set; }
        public string expectedLongitude{ get; set; }
        public string expectedPhoneInternationalPrefix{ get; set; }
        public string expectedPhoneCountryDialingCode{ get; set; }
        public string expectedPhoneNationPrefix{ get; set; }
        public string expectedPhoneNationalDestinationCode{ get; set; }
        public string expectedPhoneSubscriberNumber{ get; set; }
        public string expectedUTC{ get; set; }
        public string expectedTimeZoneCode{ get; set; }
        public string expectedTimeZoneName{ get; set; }
        public string expectedPostalCode{ get; set; }
        public object expectedSuggestions{ get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("transmissionRef:" + transmissionRef + "\n");
            sb.Append("phone:" + phone + "\n");
            sb.Append("expectedResults:" + expectedResults + "\n");
            sb.Append("expectedPhoneNumber:" + expectedPhoneNumber + "\n");
            sb.Append("expectedAdministrativeArea:" + expectedAdministrativeArea + "\n");
            sb.Append("expectedCountryAbbreviation:" + expectedCountryAbbreviation + "\n");
            sb.Append("expectedCountryName:" + expectedCountryName + "\n");
            sb.Append("expectedCarrier:" + expectedCarrier + "\n");
            sb.Append("expectedCallerID:" + expectedCallerID + "\n");
            sb.Append("expectedDST:" + expectedDST + "\n");
            sb.Append("expectedInternationalPhoneNumber:" + expectedInternationalPhoneNumber + "\n");
            sb.Append("expectedLanguage:" + expectedLanguage + "\n");
            sb.Append("expectedLatitude:" + expectedLatitude + "\n");
            sb.Append("expectedLongitude:" + expectedLongitude + "\n");
            sb.Append("expectedPhoneInternationalPrefix:" + expectedPhoneInternationalPrefix + "\n");
            sb.Append("expectedPhoneCountryDialingCode:" + expectedPhoneCountryDialingCode + "\n");
            sb.Append("expectedPhoneNationPrefix:" + expectedPhoneNationPrefix + "\n");
            sb.Append("expectedPhoneNationalDestinationCode:" + expectedPhoneNationalDestinationCode + "\n");
            sb.Append("expectedPhoneSubscriberNumber:" + expectedPhoneSubscriberNumber + "\n");
            sb.Append("expectedUTC:" + expectedUTC + "\n");
            sb.Append("expectedTimeZoneCode:" + expectedTimeZoneCode + "\n");
            sb.Append("expectedTimeZoneName:" + expectedTimeZoneName + "\n");
            sb.Append("expectedPostalCode:" + expectedPostalCode + "\n");
            sb.Append("expectedSuggestions:" + expectedSuggestions + "\n");
            return sb.ToString();
        }
    }
}
