using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace WeatherProxy.Controllers
{
    public class AutocompleteController : ApiController
    {
        public HttpResponseMessage Get(string query, string callback = "")
        {
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString("http://autocomplete.wunderground.com/aq?query=" + query);

                if (!string.IsNullOrEmpty(callback))
                {
                    json = callback + "(" + json + ")";
                }

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(json, Encoding.Unicode, "application/json");
                return response;
            }
        }
    }
}
