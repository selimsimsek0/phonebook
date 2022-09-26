using Newtonsoft.Json;
using PhoneBook.Report.Creator.ServiceModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PhoneBook.Report.Creator.Providers
{
    public class PersonService
    {
        private HttpClient GetHttpClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.ConnectionClose = true;
            return client;
        }
        public async Task<List<Person>> GetAllPersons()
        {
            //todo unit test
            List<Person> retVal;
            try
            {
                HttpClient client = GetHttpClient();
                HttpResponseMessage responseMessage = await client.GetAsync(ServiceEndPoints.PhoneBookService.GetAllPerson);

                if ((int)responseMessage.StatusCode < 200 && (int)responseMessage.StatusCode > 300) return null;

                string serviceResponse = await responseMessage.Content.ReadAsStringAsync();
                retVal = JsonConvert.DeserializeObject<List<Person>>(serviceResponse);
            }
            catch
            {
                retVal = null;
            }
            return retVal;
        }
        public async Task<List<Person>> GetAllPersonsWithContacts()
        {
            //todo unit test
            List<Person> retVal;
            try
            {
                HttpClient client = GetHttpClient();
                HttpResponseMessage responseMessage = await client.GetAsync(ServiceEndPoints.PhoneBookService.GetAllPersonWithContacts);

                if ((int)responseMessage.StatusCode < 200 && (int)responseMessage.StatusCode > 300) return null;

                string serviceResponse = await responseMessage.Content.ReadAsStringAsync();
                retVal = JsonConvert.DeserializeObject<List<Person>>(serviceResponse);
            }
            catch
            {
                retVal = null;
            }
            return retVal;
        }



    }
}
