using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;


namespace WebClient.Requests
{
    public class WebApiRequest
    {
        static HttpClient client = new HttpClient();

        public static async Task<Customer> GetCustomerAsync(long id)
        {
            Customer customer = null;
            HttpResponseMessage response = await client.GetAsync($"https://localhost:5001/customers/{id}");
            if (response.IsSuccessStatusCode)
            {
                customer = await response.Content.ReadAsAsync<Customer>();
            }
            return customer;
        }
        public static async Task<long> CreateCustomerAsync(Customer customer)
        {
            HttpResponseMessage response = await client.PostAsync("https://localhost:5001/customers", new StringContent(
                JsonConvert.SerializeObject(new Customer
                    {Firstname = customer.Firstname, Lastname = customer.Lastname}),
                Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                var res = JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
                var isNumeric = long.TryParse(res, out long id);
                if (isNumeric)
                {
                    return id;
                }
                else
                {
                    throw new NotImplementedException();
                }

            }
            else
            {
                throw new NotImplementedException();
            }

        }
    }

}
