using AstonEcole.DTO;
using AstonEcole.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Web.UI;


namespace AstonEcole.ApiClient
{
    public class AstonApiClient
    {
        protected HttpClient astonSvc { get; private set; }

        public AstonApiClient()
        {
            astonSvc = new HttpClient();
            astonSvc.BaseAddress = new Uri("http://localhost:56089/");
            astonSvc.DefaultRequestHeaders.Clear();
            astonSvc.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        private TResult GetAsync<TResult>(string api)
       where TResult : class, new()
        {
            Task<HttpResponseMessage> response = astonSvc.GetAsync(api);

            var x = response.Result.Content.ReadAsStringAsync().Result;

            JavaScriptSerializer sera = new JavaScriptSerializer();
            TResult result = sera.Deserialize<TResult>(x);
            return result;
        }



    }

}
        