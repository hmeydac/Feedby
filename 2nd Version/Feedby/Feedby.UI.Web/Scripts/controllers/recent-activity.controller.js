/// <reference path="../app.js" />
/// <reference path="~/Scripts/libs/jquery-1.7.1.js" />
var RecentActivityController = Feedby.RecentActivityController = function (container, url) {
    this.container = container || {};
    this.url = url || '/Profiles/RecentActivity/';
};

jQuery.extend(Feedby.RecentActivityController.prototype, {
    fetch: function () {
        $.ajax({
            url: this.url,
            cache: false,
            type: "GET",
            beforeSend: jQuery.proxy(this.loadIndicator, this)
        })
            .done(jQuery.proxy(this.templateLoaded, this))
            .fail(jQuery.proxy(this.templateFailed, this))
            .complete(jQuery.proxy(this.stopIndicator, this));
    },

    templateLoaded: function (template) {
        this.container.html(template);
    },

    templateFailed: function (err) {
        throw 'Error while loading Search View';
    },

    loadIndicator: function () {
        $(".loading-indicator").show();
    },

    stopIndicator: function () {
        $(".loading-indicator").hide();
    }
});

