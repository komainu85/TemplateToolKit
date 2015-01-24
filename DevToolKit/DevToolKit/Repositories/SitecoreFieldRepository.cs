using DevToolKit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Diagnostics;

namespace DevToolKit.Repositories
{
    public class SitecoreFieldRepository : Sitecore.Services.Core.IRepository<SitecoreField>
    {
        public void Add(SitecoreField entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(SitecoreField entity)
        {
            throw new NotImplementedException();
        }

        public bool Exists(SitecoreField entity)
        {
            throw new NotImplementedException();
        }

        public SitecoreField FindById(string id)
        {
            Assert.IsNotNullOrEmpty(id, "id is required");

            // required when getting field by ID

            throw new NotImplementedException();
        }

        public IQueryable<SitecoreField> GetAll()
        {
            var items = new List<SitecoreField>();

            items.Add(new SitecoreField() {Id= "100", itemId="100", Name="Assert", StandardValue="Hello", Value="Disc", TemplateName  = "Page base", TemplatePath = "/sitecore/templates/user defined/asserts/Page base"});;
            items.Add(new SitecoreField() { Id = "200", itemId = "200", Name = "IsNull", StandardValue = "World", Value = "World", TemplateName  = "Standard template", TemplatePath = "/sitecore/templates/user defined/asserts/Standard template" });

            return items.AsQueryable();
        }

        public void Update(SitecoreField entity)
        {
            throw new NotImplementedException();
        }
    }
}