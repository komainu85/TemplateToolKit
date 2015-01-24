require.config({
    paths: {
        entityService: "/sitecore/shell/client/Services/Assets/lib/entityservice"
    }
});

define(["sitecore", "jquery", "underscore", "entityService", ], function (Sitecore, $, _, entityService) {
    var StandardValuesTool = Sitecore.Definitions.App.extend({

        initialized: function () {
            this.GetFields();
        },

        initialize: function () {

        },

        GetFields: function () {
            var datasource = this.DataSource;
            var querystring = this.GetQueryString();

            var itemid = querystring["itemid"];

            var fieldService = new entityService({
                url: "/sitecore/api/ssc/DevToolKit-Controllers/SitecoreItem"
            });

            var result = fieldService.fetchEntity(itemid).execute().then(function (item) {
                datasource.viewModel.items(item.Fields.underlying);
            });

        },

        GetQueryString: function () {
            var vars = [], hash;
            var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
            for (var i = 0; i < hashes.length; i++) {
                hash = hashes[i].split('=');
                vars.push(hash[0]);
                vars[hash[0]] = hash[1];
            }
            return vars;
        },

        UpdateItem: function () {
            var itemService = new entityService({
                url: "/sitecore/api/ssc/DevToolKit-Controllers/SitecoreItem"
            });

            var querystring = this.GetQueryString();
            var itemid = querystring["itemid"];

            var message = this.messagePanel;
            var fieldsToReset = this.GetItemsToReset();

            var result = itemService.fetchEntity(itemid).execute().then(function (item) {

                for (var i = 0; i < item.Fields.underlying.length; i++) {
                    var field = item.Fields.underlying[i];

                    if ($.inArray(field.Name, fieldsToReset) != -1) {
                        field.RevertToStandardValue = true;
                    }
                }

                item.save().then(function (savedItem) {
                    message.addMessage("notification", { text: "Item updated successfully", actions: [], closable: true, temporary: true });
                }).done(this.GetFields());
            });
        },

        GetItemsToReset: function () {
            var checkedValues = $("input[value='On']").map(function () {
                return this.name;
            }).get();

            return checkedValues;
        },

    });

    return StandardValuesTool;
});