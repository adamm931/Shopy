var Products = Products || {};

(function ($, ns, ko) {

    function Details() {

        var self = this;

        self.relatedProducts = ko.observableArray();
        self.availableSizes = ko.observableArray();

        self.caption = ko.observable();
        self.price = ko.observable();
        self.description = ko.observable();
        self.caption = ko.observable();
        self.images = ko.observableArray();

        self.init = function () {

            $.ajax({
                url: endpoints.LoadDetails,
                type: 'GET',
                success: function (response) {
                    var details = response.Details;

                    self.relatedProducts(details.RelatedProducts);
                    self.price(details.Price);
                    self.description(details.Description);
                    self.caption(details.Caption);
                    self.availableSizes(details.AvailableSizes);
                }
            });
        }
    }

    $.extend(ns, {
        Details: Details
    });

})(jQuery, Products, ko);