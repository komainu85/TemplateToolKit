using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevToolKit.Models;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;

namespace DevToolKit.EntityMapping
{
    public class SitecoreItemMapper
    {
        public static SitecoreItem MapToEntity(Item item)
        {
            Assert.IsNotNull(item, "item can not be null");

            var entity = new SitecoreItem
            {
                itemId = item.ID.ToString(),
                Name = item.DisplayName,
                Fields = item.Fields.Select(SitecoreFieldMapper.MapToEntity).ToList(),
            };

            var fieldsToKeep = new List<SitecoreField>();
            foreach (var field in entity.Fields)
            {
                if (!field.StandardField)
                {
                    fieldsToKeep.Add(field);
                }
            }

            entity.Fields = fieldsToKeep;

            return entity;
        }
    }
}