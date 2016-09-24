using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;
using Newtonsoft.Json;
using log4net;

namespace LemonWayChallenge.Controllers
{
    public class ToJsonController : ApiController
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // POST api/<controller>
        public string Post([FromBody]string value)
        {
            Log.Debug("parsing XML:\r\n" + value);
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.LoadXml(value);
                string result = JsonConvert.SerializeXmlNode(xmlDoc, Newtonsoft.Json.Formatting.Indented);
                Log.Debug("Json returned:\r\n" + result);
                return result;
            }
            catch (XmlException e)
            {
                Log.Debug("An exeption occured while parsing the XML:\r\n" + e.ToString());
                return "Bad xml format";
            }
        }
    }
}
