using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace pokemon_challenge.PokeHelper
{
    public class PokeApiClient
    {

        private HttpClient client;

        public PokeApiClient()
        {
            client = new HttpClient();
            //TODO - configure o endereço do CRM
            client.BaseAddress = new Uri("http://pokeapi.co/api/v2/");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

        }

        /* public Customer GetCustomerByEmail(string email)
         {
             // Get a customer by ID
             HttpResponseMessage response = client.GetAsync("customers/byemail?email=" + email).Result;
             if (response.IsSuccessStatusCode)
             {
                 // Parse the response body. Blocking!
                 Customer customer = (Customer)response.Content.ReadAsAsync<Customer>().Result;
                 return customer;
             }
             return null;
         }*/
    }
}