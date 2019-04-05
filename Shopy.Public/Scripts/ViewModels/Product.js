function Product(item) {

    var self = this;

    self.id = item.Uid;
    self.price = item.Price.toFixed(2) + "$";
    self.caption = item.Caption;
    self.detailsLink = endpoints.Details.replace("id", item.Uid);
    self.image1Url = productImage1UrlTemplate.replace("{{id}}", item.Uid);
    self.sizes = _.map(item.Sizes, s => new Size(s));
    self.brand = new Brand(item.Brand);
    self.categories = _.map(item.Categories, c => new Category(c));

    self.detailsVisible = ko.observable(false);

    self.toogleDetails = function () {
        self.detailsVisible(!self.detailsVisible());
    }
}