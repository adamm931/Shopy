
var Admin = Admin || {};

(function ($, ko, ns) {

    function ProductCategoriesManager() {

        var self = this;

        self.availableCategories = ko.observableArray([]);
        self.assignedCategories = ko.observableArray([]);

        self.selectedCategoryToAdd = ko.observable();

        self.load = function () {

            $.ajax({
                url: endpoints.loadCategories,
                type: 'GET',
                success: function (data) {
                    self.availableCategories(data.AvailableCategories);
                    self.assignedCategories(data.AssignedCategories);
                    self.loading(false)
                },
                failure: function (data) {
                    alert('Something went wrong!');
                    self.loading(false)
                }
            });
        }

        self.addToCategory = function () {

            var category = self.selectedCategoryToAdd();
            if (category === undefined) {
                return;
            }
            self.manageCategory(endpoints.addToCategory, category.Uid);
        }

        self.removeFromCategory = function (item, event) {
            self.manageCategory(endpoints.removeFromCategory, item.Uid);
        }

        self.manageCategory = function (endpoint, categoryUid) {


            $.ajax({
                url: endpoint,
                data: {
                    categoryUid: categoryUid
                },
                type: 'POST',
                success: function (data) {
                    self.load();
                },
                failure: function (data) {
                    alert('Something went wrong!');
                }
            });

        }
    }

    $.extend(Admin, {
        ProductCategoriesManager: ProductCategoriesManager
    });

})(jQuery, ko, Admin);



