using DevToolKit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            throw new NotImplementedException();
        }

        public IQueryable<SitecoreField> GetAll()
        {
            var items = new List<SitecoreField>();

            items.Add(new SitecoreField() {Id= "dgsds",itemId="fdfgfdg", Name="sdfdsfsdf", StandardValue="dsfdf", Value="dsfdsf"  });
            items.Add(new SitecoreField() { Id = "dgsfffds", itemId = "fsdfdsdfgfdg", Name = "sdfdssdfsdf", StandardValue = "dsdfdfdf", Value = "dsfdsddf" });

            return items.AsQueryable();
        }

        public void Update(SitecoreField entity)
        {
            throw new NotImplementedException();
        }
    }
}