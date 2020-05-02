function Category(category) {

    var self = this;

    self.id = category.Uid;
    self.caption = category.Name;
    self.selected = ko.observable(false);
}