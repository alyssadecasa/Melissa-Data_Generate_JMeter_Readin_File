/*
 * Generate txt file for JMeter load testing of Global Phone web API
 * RootObject.cs
 * 
 * An object class that holds the keys and values of the JSON response
 * from the Global Phone web API
 * 
 * @author Alyssa House
 */

using System.Collections.Generic;

namespace GenerateCSVforGlobalPhoneJMeter
{
    class RootObject
    {
        public string Version { get; set; }
        public string TransmissionReference { get; set; }
        public string TransmissionResults { get; set; }
        public List<Record> Records { get; set; }
    }
}
