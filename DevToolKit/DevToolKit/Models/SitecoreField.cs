using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Fields;
using Sitecore.Diagnostics;

namespace DevToolKit.Models
{
    public class SitecoreField : Sitecore.Services.Core.Model.EntityIdentity
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string StandardValue { get; set; }
        public string TemplateName { get; set; }
        public string TemplatePath { get; set; }

        public SitecoreField(Field field)
        {
            Assert.IsNotNull(field, "Field can not be null");

            Name = field.Name;
            Value = field.Value;
            StandardValue = field.GetStandardValue();
            TemplateName = field.GetTemplateField().Template.Name;
            TemplatePath = field.GetTemplateField().Template.FullName;
        }

        public SitecoreField()
        {
            
        }
    }
}