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
            ID sId = ID.Null;

            if (ID.TryParse(id, out Sid))
            {
                var item = Sitecore.Data.Database.GetDatabase("database").GetItem(sId);
            }
            else
            {
                throw new Exception();
            }

        }
    }
}