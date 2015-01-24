using System;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;

namespace DevToolKit.DataAccess
{
    public class DataAccess
    {
        public Item GetItem(string id)
        {
            Assert.IsNotNullOrEmpty(id, "Id can not be null");

            Item item = null;

            ID sId = ID.Null;
            if (ID.TryParse(id, out sId))
            {
                item = Sitecore.Data.Database.GetDatabase("database").GetItem(sId);
            }
            else
            {
                throw new Exception();
            }

            return item;
        }
    }
}