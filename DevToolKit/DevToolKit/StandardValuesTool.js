﻿require.config({
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
        }


    });

    return StandardValuesTool;
});