using DevToolKit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevToolKit.EntityMapping;
using DevToolKit.Interfaces;
using Sitecore.Data.Items;
using Sitecore.Data.Managers;
using Sitecore.Diagnostics;

namespace DevToolKit.Repositories
{
    public class SitecoreItemRepository : Sitecore.Services.Core.IRepository<ItemModel>
    {
        private IDataAccess _dataAccess = new DataAccess.DataAccess();
        private ISitecoreItemMapper _sitecoreItemMapper = new SitecoreItemMapper();

        public void Add(ItemModel entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(ItemModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Exists(ItemModel entity)
        {
            Assert.IsNotNull(entity, "entity is required");

            return (_dataAccess.GetItem(entity.Id) != null);
        }

        public ItemModel FindById(string id)
        {
            Assert.IsNotNullOrEmpty(id, "id is required");

            Item item = _dataAccess.GetItem(id);
            if (item == null) return new ItemModel();

            var sItem = _sitecoreItemMapper.MapToEntity(item);

            return sItem;
        }

        public IQueryable<ItemModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(ItemModel entity)
        {
            Assert.IsNotNull(entity, "Entity can not be null");
            Assert.IsNotNullOrEmpty(entity.Id, "Id can not be null");

            _dataAccess.UpdateItem(entity);
        }
    }
}