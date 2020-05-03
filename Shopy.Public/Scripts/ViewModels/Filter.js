function Filter(filter) {

    var self = this;

    self.name = filter.Name;
    self.value = filter.Value;
    self.selected = ko.observable(false);
}