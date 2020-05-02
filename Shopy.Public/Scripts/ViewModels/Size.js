function Size(size) {

    var self = this;

    self.id = size.Id;
    self.caption = size.Name;
    self.checked = ko.observable(false);
}