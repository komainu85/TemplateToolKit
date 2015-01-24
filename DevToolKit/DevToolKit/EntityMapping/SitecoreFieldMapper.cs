using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevToolKit.Interfaces;
using DevToolKit.Models;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Data.Managers;
using Sitecore.Data.Templates;
using Sitecore.Diagnostics;

namespace DevToolKit.EntityMapping
{
    public class SitecoreFieldMapper : ISitecoreFieldMapper
    {
        public SitecoreField MapToEntity(Field field)
        {
            Assert.IsNotNull(field, "field can not be null");

            Template template = TemplateManager.GetTemplate(
                    Sitecore.Configuration.Settings.DefaultBaseTemplate,
                    field.Database);

            Assert.IsNotNull(template, "template");

            var entity = new SitecoreField
            {
                Id = field.ID.ToString(),
                Name = field.Name,
                Value = field.Value,
                StandardValue = field.GetStandardValue(),
                TemplateName = field.GetTemplateField().Template.Name,
                TemplateId = field.GetTemplateField().Template.ID.ToString(),
                StandardField = template.ContainsField(field.ID),
                SortOrder = field.Sortorder,
                SectionSortOrder = field.SectionSortorder
            };

            return entity;
        }
    }
}