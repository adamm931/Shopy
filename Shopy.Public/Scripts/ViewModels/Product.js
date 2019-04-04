function Product(item) {

    var self = this;

    self.price = item.Price + "$";
    self.caption = item.Caption;
    self.detailsLink = endpoints.Details.replace("id", item.Uid);
    self.image1Url = productImage1UrlTemplate.replace("{{id}}", item.Uid);
    self.sizes = item.Sizes;
    self.brand = item.Brand;
    self.categories = _.map(item.Categories, c => new Category(c));

    self.detailsVisible = ko.observable(true);

    self.toogleDetails = function () {
        //self.detailsVisible(!self.detailsVisible());
    }

    self.prettySizes = ko.pureComputed(function () {
        var pretty = _.map(_.sortBy(self.sizes), s => getSizeLetter(s));
        return pretty.join(' - ');
    }, self);

    var getSizeLetter = function (s) {
        switch (s) {
            case 0:
                return 'S';
            case 1:
                return 'M';
            case 2:
                return 'L';
            case 3:
                return 'XL';
            default:
                return '';
        }
    }
}