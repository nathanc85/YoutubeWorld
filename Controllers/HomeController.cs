using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using YoutubeWorld.Models;

namespace YoutubeWorld.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var apiKey = System.Web.Configuration.WebConfigurationManager.AppSettings["youtubeAPIKey"];
            var query = "pokemon";

            // Create the request to the API
            WebRequest request = WebRequest.Create($"https://www.googleapis.com/youtube/v3/search?part=snippet&q={query}&key={apiKey}");
            // Send the request.
            WebResponse response = request.GetResponse();
            // Get back the response stream.
            Stream stream = response.GetResponseStream();
            // Make the stream reacheable/accessible.
            StreamReader reader = new StreamReader(stream);
            // Human readable response.
            string responseString = reader.ReadToEnd();
            // Parses the response string.
            JObject parsedString = JObject.Parse(responseString);

            YoutubeResultModel youtubeResult = parsedString.ToObject<YoutubeResultModel>();

            return View(youtubeResult);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}