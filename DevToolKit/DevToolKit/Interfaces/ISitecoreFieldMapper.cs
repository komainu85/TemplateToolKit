using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevToolKit.Models;
using Sitecore.Data.Fields;

namespace DevToolKit.Interfaces
{
    public interface ISitecoreFieldMapper
    {
        FieldModel MapToEntity(Field field);
    }
}
