using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevToolKit.Models;
using Sitecore.Data.Items;

namespace DevToolKit.Interfaces
{
    public interface IDataAccess
    {
        Item GetItem(string id);
        bool UpdateItem(SitecoreItem sItem);
    }
}