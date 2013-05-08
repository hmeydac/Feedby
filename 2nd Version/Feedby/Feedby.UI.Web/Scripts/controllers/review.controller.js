/// <reference path="../app.js" />
/// <reference path="~/Scripts/libs/jquery-1.7.1.js" />
var SearchController = Feedby.ReviewController = function (container) {
    this.container = container || {};
    this.reviewTypes = ["bad", "good", "improve"];
    this.activeTab;
};

jQuery.extend(Feedby.ReviewController.prototype, {
    init: function () {
        this.container.find('input[type=text]')
            .on('keypress', jQuery.proxy(this.keyPressedEvent, this))
            .on('focus', jQuery.proxy(this.focusEvent, this));

        this.container.find('input').first().focus();
    },
    keyPressedEvent: function (event) {
        if (event.which == 13) {
            if (this.validateNewInput(this.activeTab)){
                this.addInput(this.activeTab);
            } else {
                this.container.find('div[data-id=' + this.activeTab + ']').find('input').each(function (pos, val, array) {
                    if (!val.value) val.focus();
                })
            }
        } 
    },
    focusEvent: function (event) {
        this.activeTab = $(event.currentTarget).parents('.review-container').data('id');
    },
    validateNewInput: function (container) {
        var returnValue = true;
        this.container.find('div[data-id='+container+']').find('input').each(function(pos,val,array){
            if (!val.value) returnValue = false;
        })
        return returnValue;
    },
    addInput: function(id){
        var element = document.createElement("input");
        element.type = 'text';
        element.placeholder = 'Feedback';
        element.classList.add('review-input-width');
        element.onkeypress = jQuery.proxy(this.keyPressedEvent, this);
        element.onfocus = jQuery.proxy(this.focusEvent, this);
        this.container.find('div[data-id=' + id + ']')
            .find('.review-text div')
            .append(element);

        element.focus();
    },
    templateLoaded: function (template) {
        this.container.html(template);
    },
    loadIndicator: function () {
        $(".loading-indicator").show();
    },

    stopIndicator: function () {
        $(".loading-indicator").hide();
    }
});

