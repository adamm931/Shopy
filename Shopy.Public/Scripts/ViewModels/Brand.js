function Brand(brand) {

    var self = this;

    self.id = brand.EId;
    self.caption = brand.Caption;
    self.checked = ko.observable(false);
}