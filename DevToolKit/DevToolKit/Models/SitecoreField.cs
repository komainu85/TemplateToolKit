using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Fields;
using Sitecore.Data.Managers;
using Sitecore.Data.Templates;
using Sitecore.Diagnostics;

namespace DevToolKit.Models
{
    public class SitecoreField
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string StandardValue { get; set; }
        public string TemplateName { get; set; }
        public string TemplatePath { get; set; }
        public bool StandardField { get; set; }
        public bool RevertToStandardValue { get; set; }

        public SitecoreField()
        {
            
        }
    }
}