/// <reference path="../app.js" />
/// <reference path="~/Scripts/libs/jquery-1.7.1.js" />
var SearchController = Feedby.SearchController = function (container, url) {
    this.container = container || {};
    this.url = url || '/Profiles/Search/';
};

jQuery.extend(Feedby.SearchController.prototype, {
    search: function (param) {
        $.ajax({
            url: this.url,
            cache: false,
            data: { argument : param },
            type: "POST",
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

