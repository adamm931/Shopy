function Category(category) {

    var self = this;

    self.id = category.Uid;
    self.caption = category.Caption;
    self.selected = ko.observable(false);
}