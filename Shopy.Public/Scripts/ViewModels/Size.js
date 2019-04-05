function Size(size) {

    var self = this;

    self.id = size.EId;
    self.caption = size.Caption;
    self.checked = ko.observable(false);
}