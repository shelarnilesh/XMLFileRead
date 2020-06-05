using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XMLReadData.Models
{
    public class XMLData
    {
        [AllowHtml]
        [Required]
        public string XMLDataString { get; set; }

        [Required]
        public Operation operation { get; set; }


    }

    public enum Operation
    {
        Create,
        Update
    }
}