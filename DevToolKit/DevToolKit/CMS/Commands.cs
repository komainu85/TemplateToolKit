using Sitecore;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Globalization;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Text;
using Sitecore.Web.UI.Sheer;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace DevToolKit.CMS
{
    /// <summary>
    /// Represents the New command.
    /// </summary>
    [Serializable]
    public class ResetStandardValues : Command
    {
        /// <summary>
        /// Executes the command in the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Execute(CommandContext context)
        {
            if ((int)context.Items.Length == 1)
            {
                Item items = context.Items[0];
                NameValueCollection nameValueCollection = new NameValueCollection();
                nameValueCollection["id"] = items.ID.ToString();
                nameValueCollection["language"] = items.Language.ToString();
                nameValueCollection["version"] = items.Version.ToString();
                nameValueCollection["database"] = items.Database.Name;
                Context.ClientPage.Start(this, "Run", nameValueCollection);
            }
        }

        /// <summary>
        /// Queries the state of the command.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>The state of the command.</returns>
        public override CommandState QueryState(CommandContext context)
        {
            Error.AssertObject(context, "context");
            if ((int)context.Items.Length != 1)
            {
                return CommandState.Disabled;
            }
            if (!context.Items[0].Access.CanWriteLanguage())
            {
                return CommandState.Disabled;
            }
            return base.QueryState(context);
        }

        /// <summary>
        /// Runs the specified args.
        /// </summary>
        /// <param name="args">The arguments.</param>
        protected void Run(ClientPipelineArgs args)
        {
            string item = args.Parameters["id"];
            string str = args.Parameters["language"];
            string item1 = args.Parameters["version"];
            string str1 = args.Parameters["database"];
            Database database = Factory.GetDatabase(str1);
            Error.Assert(database != null, string.Concat("Database \"", str1, "\" not found."));
            Item item2 = database.GetItem(ID.Parse(item), Language.Parse(str), Sitecore.Data.Version.Parse(item1));
            Error.AssertItemFound(item2);
            Item item3 = item2.Database.GetItem(ItemIDs.TemplateRoot);
            if (item3 != null && !item3.Axes.IsAncestorOf(item2))
            {
                item2 = item3;
            }
            if (!args.IsPostBack)
            {
                UrlString urlString = new UrlString("/sitecore/client/Asserts/StandardValuesTool?itemid=" + item);
                if (item2.TemplateID != TemplateIDs.Template)
                {
                    urlString.Append("fo", item2.ID.ToString());
                }
                else
                {
                    urlString.Append("fo", item2.Parent.ID.ToString());
                }
                Context.ClientPage.ClientResponse.ShowModalDialog(urlString.ToString(), true);
                args.WaitForPostBack();
            }
            else if (args.Result != null && args.Result.Length > 0 && args.Result != "undefined")
            {
                TemplateItem templateItem = Context.ContentDatabase.Templates[args.Result];
                if (templateItem != null)
                {
                    Context.ClientPage.SendMessage(this, string.Concat("template:added(id=", templateItem.ID, ")"));
                    Context.ClientPage.SendMessage(this, string.Concat("item:load(id=", templateItem.ID, ")"));
                    return;
                }
            }
        }
    }
}
