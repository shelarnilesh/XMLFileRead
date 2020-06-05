using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using XMLReadData.Models;

namespace XMLReadData.Controllers
{
    public class XMLDataReadController : Controller
    {
        // GET: XMLDataRead
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        [ValidateInput(false)]
        public ActionResult XMLDataProcess(XMLData  data)
        {
            StringBuilder fileContent = new StringBuilder();

            if (data!=null)
            {
                string myXML = data.XMLDataString;

                XDocument xdoc = new XDocument();
                xdoc = XDocument.Parse(myXML);
                string node="";
                if (data.operation.ToString()=="Create")
                {
                    node="input";
                }
                else
                {
                    node = "fields";
                }
               var result = xdoc.Element(node).Descendants();
                List<String> headers = new List<string>();
                string fileContentRow="Source,Target";
                fileContent.AppendLine(fileContentRow);
                foreach (XElement item in result)
                {
                    if (data.operation.ToString() == "Create") {
                        fileContentRow = item.Attribute("source").Value + "," + item.Attribute("target").Value+","+ item.Attribute("isFix").Value;
                    }
                    else
                    {
                        fileContentRow = item.Attribute("value").Value + "," + item.Attribute("name").Value + "," + item.Attribute("isFix").Value;
                    }
                    fileContent.AppendLine(fileContentRow);
                }
                return File(new System.Text.UTF8Encoding().GetBytes(fileContent.ToString()), "text/csv", "XMLDATA.csv");
            }
            return View();
        }

        
    }
}