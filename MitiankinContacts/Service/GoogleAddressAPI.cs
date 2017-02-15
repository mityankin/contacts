using MitiankinContacts.Models.GoogleJson;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MitiankinContacts.Service
{
    public class GoogleAddressAPI
    {

        public static RootObject GetGeo(string addressFromContact)
        {
            using (var client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(5);
                string url = $"http://maps.google.com/maps/api/geocode/json?address={addressFromContact}";
                var response = client.GetAsync(url).Result;


                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return new RootObject();
                }
                try
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    RootObject geoAddress = JsonConvert.DeserializeObject<RootObject>(responseContent);
                    return geoAddress;
                }
                catch
                {
                    return new RootObject();
                }
            }
        }



    }
}