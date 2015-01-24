using DevToolKit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Diagnostics;

namespace DevToolKit.Repositories
{
    public class SitecoreItemRepository : Sitecore.Services.Core.IRepository<SitecoreItem>
    {
        public void Add(SitecoreItem entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(SitecoreItem entity)
        {
            throw new NotImplementedException();
        }

        public bool Exists(SitecoreItem entity)
        {
            return true;
        }

        public SitecoreItem FindById(string id)
        {
            Assert.IsNotNullOrEmpty(id, "id is required");


            var fields = new List<SitecoreField>();

            fields.Add(new SitecoreField() { Name = "Assert", StandardValue = "Hello", Value = "Disc", TemplateName = "Page base", TemplatePath = "/sitecore/templates/user defined/asserts/Page base" }); ;
            fields.Add(new SitecoreField() { Name = "IsNull", StandardValue = "World", Value = "World", TemplateName = "Standard template", TemplatePath = "/sitecore/templates/user defined/asserts/Standard template" });


            var sItem = new SitecoreItem()
            {
                itemId = "233",
                Id = "233",
                Fields = fields
            };

           sItem = new SitecoreItem(Sitecore.Context.Database.GetItem(id));

            return sItem;
        }

        public IQueryable<SitecoreItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(SitecoreItem entity)
        {
            throw new NotImplementedException();
        }
    }
}