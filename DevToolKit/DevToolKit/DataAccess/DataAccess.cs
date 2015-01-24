﻿using System;
using System.Linq;
using DevToolKit.Interfaces;
using DevToolKit.Models;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;

namespace DevToolKit.DataAccess
{
    public class DataAccess : IDataAccess
    {
        public Item GetItem(string id)
        {
            Assert.IsNotNullOrEmpty(id, "Id can not be null");

            Item item = null;

            ID sId = ID.Null;
            if (ID.TryParse(id, out sId))
            {
                item = Sitecore.Context.Database.GetItem(sId);
            }
            else
            {
                throw new Exception();
            }

            return item;
        }

        public bool UpdateItem(SitecoreItem sItem)
        {
            Assert.IsNotNull(sItem, "SitecoteItem can not be null");

            Item item = Sitecore.Context.Database.GetItem(sItem.Id);
            Assert.IsNotNull(item, "Item can not be null");

            bool success = false;

            using (new Sitecore.SecurityModel.SecurityDisabler())
            {
                try
                {
                    item.Editing.BeginEdit();

                    var fieldsToRevert = sItem.Fields.Where(x => x.RevertToStandardValue);

                    foreach (var sField in fieldsToRevert)
                    {
                        var field =
                            item.Fields.FirstOrDefault(
                                x => x.ID.ToString().Trim().ToLower() == sField.Id.Trim().ToLower());

                        if (field == null)
                        {
                            Log.Error("Failed to revert field to standard values, field was not found on item", this);
                            continue;
                        }

                        field.Value = field.GetStandardValue();
                    }

                    item.Editing.EndEdit();

                    success = true;
                }
                catch (Exception ex)
                {
                    item.Editing.EndEdit();
                    Log.Error(ex.Message, ex, this);
                    success = false;
                }
            }

            return success;
        }
    }
}