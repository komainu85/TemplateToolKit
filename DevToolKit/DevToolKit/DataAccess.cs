using Sitecore.Data;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevToolKit
{
    public class DataAccess
    {
        public Item GetItem(string id)
        {
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