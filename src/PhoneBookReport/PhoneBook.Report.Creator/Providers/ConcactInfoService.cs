using Newtonsoft.Json;
using PhoneBook.Report.Creator.ServiceModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PhoneBook.Report.Creator.Providers
{
    public  class ConcactInfoService
    {
        private HttpClient GetHttpClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.ConnectionClose = true;
            return client;
        }
        public async Task<List<ContactInfo>> GetAllPersons()
        {
            List<ContactInfo> retVal;
            try
            {
                HttpClient client = GetHttpClient();
                HttpResponseMessage responseMessage = await client.GetAsync(ServiceEndPoints.PhoneBookService.GetAllContactsWithPerson);

                if ((int)responseMessage.StatusCode < 200 && (int)responseMessage.StatusCode > 300) return null;

                string serviceResponse = await responseMessage.Content.ReadAsStringAsync();
                retVal = JsonConvert.DeserializeObject<List<ContactInfo>>(serviceResponse);
            }
            catch
            {
                retVal = null;
            }
            return retVal;
        }
        }
    }
}
