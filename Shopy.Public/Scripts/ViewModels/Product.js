function Product(item) {

    var self = this;

    self.id = item.Uid;
    self.price = item.Price.toFixed(2) + "$";
    self.caption = item.Name;
    self.detailsLink = endpoints.Details.replace("id", item.Uid);
    self.mainImageUrl = item.MainImageUrl;
    self.sizes = item.Sizes;

    self.detailsVisible = ko.observable(false);

    self.toogleDetails = function () {
        self.detailsVisible(!self.detailsVisible());
    }
}