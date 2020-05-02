function Brand(brand) {

    var self = this;

    self.id = brand.Id;
    self.caption = brand.Name;
    self.checked = ko.observable(false);
}