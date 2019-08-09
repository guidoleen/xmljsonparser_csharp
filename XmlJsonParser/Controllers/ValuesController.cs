using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XmlClientReader;

namespace XmlJsonParser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // Init the objects for db management
        private XmlDbService.XmlDbService dbService;
        private XmlDbService.MysqlConnectionString msconnectionString = new XmlDbService.MysqlConnectionString(
                "localhost",
                "info",
                "info",
                "xmlservice"
            );
                    
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            String actionResult = "{}";
            String url = "https://nl.cwcloudpartner.com/nl-develop/e/register";
            XmlDocFromUrl xmlDocFromUrl = new XmlDocFromUrl(url);

            try
            {
                // Get Xml from url and convert to Json string
                List<KeyValuePair<String, String>> list = xmlDocFromUrl.GetXmlDocList();
                String xmlToJson = new XmlToJson().XmlToJsonString(list);
                actionResult = xmlToJson;

                // Save to Log database...
                // System.AppDomain.CurrentDomain.BaseDirectory
                dbService = new XmlDbService.XmlDbService("This service is ready", "L", this.msconnectionString);
            }
            catch (MySql.Data.MySqlClient.MySqlException ee)
            {
                actionResult = ee.ToString();
            }
            catch (Exception ee)
            {
                // Save to Log database...
                new XmlDbService.XmlDbService(ee.ToString(), "E", this.msconnectionString);
            }

            return actionResult;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
