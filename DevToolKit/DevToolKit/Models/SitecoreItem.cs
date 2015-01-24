using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevToolKit.Models
{
    public class SitecoreItem : Sitecore.Services.Core.Model.EntityIdentity
    {
        public string itemId { get; set; }
        public string Name { get; set; }
        public List<SitecoreField> Fields { get; set; }
    }
}