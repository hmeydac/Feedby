/// <reference path="../app.js" />
/// <reference path="~/Scripts/libs/jquery-1.7.1.js" />
var SubmitFeedbackController = Feedby.SubmitFeedbackController = function (container, autocompleteControl, calendar) {
    this.container = container || {};
    this.autocompleteControl = autocompleteControl || {};
    this.calendar = calendar || {};
    this.url = '/Home/SubmittedReviews';
    this.autocompleteUrl = '/Home/People/';
};

jQuery.extend(Feedby.SubmitFeedbackController.prototype, {
    init: function () {
        this.initAutocomplete();
        this.initCalendar();
        $(".loading-indicator").hide();
    },

    initAutocomplete: function () {
        var that = this;
        this.autocompleteControl.autocomplete(
            {
                source: function (request, response) {
                    $.ajax({
                        url: that.autocompleteUrl,
                        data: { term: request.term, maxRows: 10 }
                    }).done(
                        function (data) {
                            response($.map(data, function (item) {
                                return {
                                    label: item.FirstName + ' ' + item.LastName,
                                    value: item.Id
                                };
                            }));
                        }).fail(function (err, desc) {
                            throw "Unable to retrieve the list of employee.";
                        });
                },
                minLength: 3,
                select: function (event, ui) {
                    $(that.autocompleteControl).val(ui.item.label);
                    that.employeeId = ui.item.value;
                    that.loadSubmittedReviews();
                    return false;
                }
            });
    },
    
    initCalendar: function () {
        this.calendar.datepicker("option", "dateFormat", "yy-mm-dd");
        this.calendar.datepicker();
        this.calendar.on('change', jQuery.proxy(this.loadSubmittedReviews, this));
    },
    
    loadSubmittedReviews: function() {
        var employeeId = this.employeeId;
        var date = this.calendar.val();
        if (!employeeId) return;
        if (!date) return;

        $.ajax({
            url: this.url,
            data: {employeeId: employeeId, date: date},
            cache: false
        })
            .done(jQuery.proxy(this.templateLoaded, this))
            .fail(jQuery.proxy(this.templateFailed, this));
    },
    
    templateLoaded: function (template) {
        this.container.html(template);
    },

    templateFailed: function (err) {
        throw 'Error while loading Timeline View';
    }
});

