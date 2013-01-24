/// <reference path="../app.js" />
/// <reference path="~/Scripts/libs/jquery-1.7.1.js" />
var TimelineController = Feedby.TimelineController = function(container) {
    this.container = container || {};
    this.url = '/Home/Timeline/';
};

jQuery.extend(Feedby.TimelineController.prototype, {
    init: function(container) {
        $.ajax({
                url: this.url,
                cache: false,
                beforeSend: jQuery.proxy(this.loadIndicator, this)
        })
            .done(jQuery.proxy(this.templateLoaded,this))
            .fail(jQuery.proxy(this.templateFailed, this))
            .complete(jQuery.proxy(this.stopIndicator, this));
    },

    templateLoaded: function(template) {
       this.container.html(template);
    },

    templateFailed: function(err) {
        throw 'Error while loading Timeline View';
    },
    
    loadIndicator: function() {
        $(".loading-indicator").show();
    },
    
    stopIndicator: function() {
        $(".loading-indicator").hide();
    }
});

