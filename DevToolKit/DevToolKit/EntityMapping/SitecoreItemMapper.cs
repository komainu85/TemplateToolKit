using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevToolKit.Interfaces;
using DevToolKit.Models;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;

namespace DevToolKit.EntityMapping
{
    public class SitecoreItemMapper : ISitecoreItemMapper
    {
        private ISitecoreFieldMapper _sitecoreFieldMapper = new SitecoreFieldMapper();

        public SitecoreItem MapToEntity(Item item, bool includeStandardFields = false)
        {
            Assert.IsNotNull(item, "item can not be null");

            item.Fields.ReadAll();

            var entity = new SitecoreItem
            {
                Id = item.ID.ToString(),
                itemId = item.ID.ToString(),
                Name = item.DisplayName,
                Fields = item.Fields.Select(_sitecoreFieldMapper.MapToEntity).ToList(),
            };

            if (!includeStandardFields)
            {
                entity.Fields.RemoveAll(x => x.StandardField);
            }

            entity.Fields = entity.Fields.OrderBy(f => f.SectionSortOrder).ThenBy(f => f.SortOrder).ToList();

            return entity;
        }
    }
}