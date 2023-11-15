using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace MVC
{
    public static class GlobalVariables
    {
        //create http client object
        public static HttpClient webapi= new HttpClient();

       static GlobalVariables()
       {
            //set base address
            webapi.BaseAddress = new Uri("https://localhost:44394/api/");

            //set defaultreq address
            webapi.DefaultRequestHeaders.Clear();

            webapi.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
       }
    }
}