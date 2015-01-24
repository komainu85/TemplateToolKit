using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevToolKit.Models;
using Sitecore.Data.Items;

namespace DevToolKit.Interfaces
{
    public interface ISitecoreItemMapper
    {
        ItemModel MapToEntity(Item item, bool includeStandardFields = false);
    }
}
