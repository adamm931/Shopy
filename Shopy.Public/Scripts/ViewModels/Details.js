var Public = Public || {};

(function ($, ns, ko) {

    function Details() {

        var self = this;

        self.relatedProducts = ko.observableArray();

        self.id = ko.observable();
        self.caption = ko.observable();
        self.price = ko.observable();
        self.description = ko.observable();
        self.sizes = ko.observable();
        self.hasRelatedProducts = ko.pureComputed(function () {
            return _.some(self.relatedProducts());
        }, self);

        self.displayPrice = ko.pureComputed(function () {

            if(self.price() == undefined) {
                return 0;
            }

            return (self.price() * self.quantity()) + "$";
        }, self)

        self.images = ko.observableArray();
        self.mainImage = ko.observable();

        self.setAsMain = function (item) {
            self.mainImage(item);
        }

        self.quantity = ko.observable(1);

        self.increaseQty = function () {
            self.quantity(self.quantity() + 1);
        }

        self.decreaseQty = function () {
            var decrease = self.quantity() - 1;
            self.quantity(decrease < 0 ? 0 : decrease);
        }

        self.init = function () {

            $.ajax({
                url: endpoints.LoadDetails,
                type: 'GET',
                success: function (response) {
                    
                    self.id(response.Uid);
                    self.caption(response.Name);
                    self.price(response.Price.toFixed(2));
                    self.description(response.Description);
                    self.sizes(response.Sizes);

                    self.relatedProducts(_.map(response.RelatedProducts, rp => new Product(rp)));

                    setImages(response);
                }
            });
        }

        var setImages = function (product) {

            var images = [
                product.Image1Url,
                product.Image2Url,
                product.Image3Url
            ];

            self.mainImage(images[0]);
            self.images(images);
        }
    }

   
    $.extend(ns, {
        Details: Details
    });

})(jQuery, Public, ko);