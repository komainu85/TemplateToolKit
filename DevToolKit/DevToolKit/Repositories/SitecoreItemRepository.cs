using DevToolKit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevToolKit.EntityMapping;
using DevToolKit.Interfaces;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;

namespace DevToolKit.Repositories
{
    public class SitecoreItemRepository : Sitecore.Services.Core.IRepository<SitecoreItem>
    {
        private IDataAccess _dataAccess = new DataAccess.DataAccess();

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

            Item item = _dataAccess.GetItem(id);
            if (item == null) return new SitecoreItem();

            var sitecoreItemMaper = new SitecoreItemMapper();
            var sItem = sitecoreItemMaper.MapToEntity(item);

            return sItem;
        }

        public IQueryable<SitecoreItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(SitecoreItem entity)
        {
            Assert.IsNotNull(entity, "Entity can not be null");
            Assert.IsNotNullOrEmpty(entity.Id, "Id can not be null");

            _dataAccess.UpdateItem(entity);
        }
    }
}