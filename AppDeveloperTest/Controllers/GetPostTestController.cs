using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AppDeveloperTest.Models;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Text.Json;
using System.Runtime.Serialization;
using System.IO;

namespace AppDeveloperTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetPostTestController : ControllerBase
    {

        private readonly ILogger<GetPostTestController> _logger;

        public GetPostTestController(ILogger<GetPostTestController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string GetItemms()
        {
            try
            {
                HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create("https://reqres.in/api/users?page=2");
                httpRequest.ContentType = "application/json; charset=urf-8";

                HttpWebResponse response = (HttpWebResponse)httpRequest.GetResponse();

                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    string list = sr.ReadToEnd();
                    Post();
                    return list;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // POST api/<controller>
        public void Post()
        {
            try
            {
                HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create("https://reqres.in/api/users");
                httpRequest.Method = "POST";
                httpRequest.ContentType = "application/json";

                User newUser = new User()
                {
                    Name = "Cool",
                    Job = "The Best",
                };

                using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
                {
                    string json = "{\"name\":\"" + newUser.Name + "\"," +
                                    "\"job\":\"" + newUser.Job + "\"}";

                    streamWriter.Write(json);



                }
                var response = (HttpWebResponse)httpRequest.GetResponse();

                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
