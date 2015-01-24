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
        public FieldModel MapToEntity(Field field)
        {
            Assert.IsNotNull(field, "field can not be null");

            var baseTemplate = TemplateManager.GetTemplate(
                    Sitecore.Configuration.Settings.DefaultBaseTemplate,
                    field.Database);
            Assert.IsNotNull(baseTemplate, "template");

            var template = field.GetTemplateField().Template;

            var entity = new FieldModel
            {
                Id = field.ID.ToString(),
                Name = field.Name,
                Value = field.Value,
                StandardValue = field.GetStandardValue(),
                TemplateName = template.Name,
                TemplateId = template.ID.ToString(),
                StandardField = baseTemplate.ContainsField(field.ID),
                SortOrder = field.Sortorder,
                SectionSortOrder = field.SectionSortorder,
            };

            return entity;
        }
    }
}