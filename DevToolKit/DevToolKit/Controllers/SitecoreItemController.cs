using DevToolKit.Models;
using DevToolKit.Repositories;
using Sitecore.Services.Core;
using Sitecore.Services.Infrastructure.Sitecore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevToolKit.Controllers
{
    [ValidateAntiForgeryToken]
    [ServicesController]
    public class SitecoreItemController : EntityService<SitecoreField>
    {
        public SitecoreItemController(IRepository<SitecoreItem> repository)
            : base(repository)
        {
        }

        public SitecoreItemController()
            : this(new SitecoreItemRepository())
        {
        }
    }
}