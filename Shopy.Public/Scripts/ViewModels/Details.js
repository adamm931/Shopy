//import { Product } from 'Product';
var Products = Products || {};

(function ($, ns, ko) {

    function Details() {

        var self = this;

        const image1Url = productImage1UrlTemplate.replace("{{id}}", self.id);
        const image2Url = productImage2UrlTemplate.replace("{{id}}", self.id);
        const image3Url = productImage3UrlTemplate.replace("{{id}}", self.id);

        self.id = ko.observable();
        self.caption = ko.observable();
        self.price = ko.observable();
        self.description = ko.observable();
        self.sizes = ko.observable();
        self.relatedProducts = ko.observableArray();

        self.images = ko.observableArray([image1Url, image2Url, image3Url]);
        self.mainImage = ko.observable(image1Url);

        self.setAsMain = function (item, callback) {
            self.mainImage(item);
        }

        self.quanity = 1;

        self.increaseQty = function () {
            self.quanity(self.quanity() + 1);
        }

        self.decreaseQty = function () {
            var decrease = self.quanity() - 1;
            self.quanity(decrease < 0 ? 0 : decrease);
        }

        self.init = function () {

            $.ajax({
                url: endpoints.LoadDetails,
                type: 'GET',
                success: function (response) {
                    var details = response.Details;

                    self.id(details.Uid);
                    self.caption(details.Caption);
                    self.price(details.Price);
                    self.description(details.Description);
                    self.sizes(details.sizes);
                    self.relatedProducts(_.map(details.RelatedProducts, rp => new Product(rp)));
                }
            });
        }
    }

   
    $.extend(ns, {
        Details: Details
    });

})(jQuery, Products, ko);