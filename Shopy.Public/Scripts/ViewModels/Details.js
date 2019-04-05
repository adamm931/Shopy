//import { Product } from 'Product';
var Products = Products || {};

(function ($, ns, ko) {

    function Details() {

        var self = this;

        self.product = ko.observable();
        self.relatedProducts = ko.observableArray();

        self.id = ko.observable();
        self.caption = ko.observable();
        self.price = ko.observable();
        self.description = ko.observable();
        self.sizes = ko.observable();

        self.displayPrice = ko.pureComputed(function () {

            if(self.price() == undefined) {
                return 0;
            }

            return (self.price() * self.quantity()) + "$";
        }, self)

        self.images = ko.observableArray();
        self.mainImage = ko.observable();

        self.setAsMain = function (item, callback) {
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

                    var details = response.Details;
                    var product = details.Product;
                    
                    self.id(product.Uid);
                    self.caption(product.Caption);
                    self.price(product.Price.toFixed(2));
                    self.description(product.Description);
                    self.sizes(product.Sizes);

                    self.relatedProducts(_.map(details.RelatedProducts, rp => new Product(rp)));

                    setImages();

                }
            });
        }

        var setImages = function () {

            var id = self.id();
            var images = [
                productImage1UrlTemplate.replace("{{id}}", id),
                productImage2UrlTemplate.replace("{{id}}", id),
                productImage3UrlTemplate.replace("{{id}}", id)
            ];

            self.mainImage(images[0]);
            self.images(images);
        }
    }

   
    $.extend(ns, {
        Details: Details
    });

})(jQuery, Products, ko);