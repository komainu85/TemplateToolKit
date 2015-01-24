require.config({
    paths: {
        entityService: "/sitecore/shell/client/Services/Assets/lib/entityservice"
    }
});

define(["sitecore", "jquery", "underscore", "entityService"], function (Sitecore, $, _, entityService) {
    var StandardValuesTool = Sitecore.Definitions.App.extend({

        initialized: function () {
            this.GetFields();
        },

        initialize: function () {

        },

        GetFields: function () {
            var datasource = this.DataSource;

            var fieldService = new entityService({
                url: "/sitecore/api/ssc/DevToolKit-Controllers/SitecoreField"
            });

            var result = fieldService.fetchEntity("123").execute().then(function (fields) {
                datasource.viewModel.items(field);
            });

        }


    });

    return StandardValuesTool;
});