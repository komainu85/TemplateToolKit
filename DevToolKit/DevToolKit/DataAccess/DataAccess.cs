using System;
using System.Collections.Generic;
using System.Linq;
using DevToolKit.Interfaces;
using DevToolKit.Models;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Data.Managers;
using Sitecore.Diagnostics;
using Sitecore.Links;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.ContentSearch.Linq;

namespace DevToolKit.DataAccess
{
    public class DataAccess : IDataAccess
    {
        private Database _masterDatabase;
        private Database MasterDatabase
        {
            get
            {
                if (_masterDatabase == null)
                {
                    _masterDatabase = Sitecore.Data.Database.GetDatabase("master");
                }

                return _masterDatabase;
            }
        }

        public Item GetItem(string id)
        {
            Assert.IsNotNullOrEmpty(id, "Id can not be null");

            Item item = null;

            ID sId = ID.Null;
            if (ID.TryParse(id, out sId))
            {
                item = MasterDatabase.GetItem(sId);
            }
            else
            {
                throw new Exception();
            }

            return item;
        }

        public bool UpdateItem(ItemModel itemModel)
        {
            Assert.IsNotNull(itemModel, "SitecoteItem can not be null");

            Item item = GetItem(itemModel.Id);
            Assert.IsNotNull(item, "Item can not be null");

            bool success = false;

            bool isStandardValue = item.Name == "__Standard Values";

            if (isStandardValue)
            {
                success = UpdateReferers(item, itemModel);
            }
            else
            {
                success = ComputeUpdate(item, itemModel);
            }

            return success;
        }

        private bool UpdateReferers(Item standardValue, ItemModel itemModel)
        {
            bool success = false;

            var template = standardValue.Parent;

            var refererItems = GetItemsFromTemplate(template);

            foreach (var item in refererItems)
            {
                success = ComputeUpdate(item, itemModel);
            }

            return success;
        }

        private bool ComputeUpdate(Item item, ItemModel itemModel)
        {
            bool success = false;

            var fieldsToRevert = itemModel.Fields.Where(x => x.RevertToStandardValue);

            using (new Sitecore.SecurityModel.SecurityDisabler())
            {
                try
                {
                    item.Editing.BeginEdit();

                    foreach (var sField in fieldsToRevert)
                    {
                        var field = item.Fields.FirstOrDefault(x => x.ID.ToString().Trim().ToLower() == sField.Id.Trim().ToLower());

                        if (field == null)
                        {
                            Log.Error("Failed to revert field to standard values, field was not found on item", this);
                            continue;
                        }

                        field.Value = field.GetStandardValue();

                        if (field.Value.Contains("$"))
                        {
                            Sitecore.Data.MasterVariablesReplacer replacer = Sitecore.Configuration.Factory.GetMasterVariablesReplacer();
                            Sitecore.Diagnostics.Assert.IsNotNull(replacer, "replacer");
                            replacer.ReplaceItem(item);
                        }
                    }

                    success = true;
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message, ex, this);
                    throw ex;
                }
                finally
                {
                    item.Editing.EndEdit();
                }
            }

            return success;
        }

        private List<Item> GetItemsFromTemplate(Item template)
        {
            var items = new List<Item>();

            var index = ContentSearchManager.GetIndex("sitecore_master_index");

            using (var context = index.CreateSearchContext())
            {
                var searchItems = context.GetQueryable<SearchResultItem>();
                var results = searchItems.Where(item => item.TemplateId == template.ID && item.Name != "__Standard Values").ToList();

                if (results.Any())
                {
                    items = results.Select(x => x.GetItem()).ToList();
                }
            }

            return items;
        }
    }
}