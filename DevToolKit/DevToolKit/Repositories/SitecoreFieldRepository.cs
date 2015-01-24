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
            throw new NotImplementedException();
        }

        public void Update(SitecoreField entity)
        {
            throw new NotImplementedException();
        }
    }
}