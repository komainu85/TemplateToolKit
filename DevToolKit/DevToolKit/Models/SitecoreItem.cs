using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;

namespace DevToolKit.Models
{
    public class SitecoreItem : Sitecore.Services.Core.Model.EntityIdentity
    {
        public string itemId { get; set; }
        public string Name { get; set; }
        public List<SitecoreField> Fields { get; set; }

        public SitecoreItem(Sitecore.Data.Items.Item item)
        {
            Assert.IsNotNull(item, "Item can't be null");

            itemId = item.ID.ToString();
            Name = item.DisplayName;
            Fields = (from f in item.Fields
                where f != null
                select new SitecoreField(f)).ToList();
        }

        public SitecoreItem()
        {
            
        }
    }
}