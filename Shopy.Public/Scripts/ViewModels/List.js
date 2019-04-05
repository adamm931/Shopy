// ## IDEA ## 
// when brands and size filter is changed filter the local products
// on button click load more product from api with setted filters localy

var Products = Products || {};

(function ($, ko, ns) {
    
    function List() {
        var self = this;

        self.init = function () {
            loadFilters();
        }

        self.requestInProgress = ko.observable(false);

        //filters
        self.categoryFilters = ko.observableArray();
        self.brandFilters = ko.observableArray();
        self.sizeFilters = ko.observableArray();

        //items
        //self.sourceItems = ko.observableArray([]);
        self.items = ko.observableArray();

        //selected filters
        self.selectedSizes = ko.observableArray();
        self.selectedBrands = ko.observableArray();
        self.selectedCategory = ko.observable();

        //filter object
        self.filters = new SearchFilters();
        
        //public func

        self.search = function () {

            if (self.requestInProgress()) {
                return;
            }

            self.requestInProgress(true);

            $.ajax({
                url: endpoints.Search,
                data: self.filters.data(),
                type: 'POST',
                success: function (response) {

                    if (response.Success) {
                        var responseItems = _.map(response.Items, i => new Product(i));
                        //_.each(responseItems, ri => self.items.push(ri));
                        //_.each(responseItems, ri => self.sourceItems.push(ri));

                        self.items(responseItems);
                    }
                    else {
                        console.error(response.Message);
                    }

                    self.requestInProgress(false);
                },
                failure: function (response) {
                    alert(response);
                    self.requestInProgress(false);
                }
            });
        }

        self.setSelectedCategory = function (item, callback) {

            _.each(self.categoryFilters(), cf => cf.selected(cf.id == item.id));

            var selectedCategory = _.find(self.categoryFilters(), cf => cf.selected() == true);

            self.filters.setCategory(selectedCategory);

            self.search();
        }

        self.unsetSelectedCategory = function () {

            var selectedCategory = _.find(self.categoryFilters(), cf => cf.selected() == true);

            if(selectedCategory !== undefined) {
                selectedCategory.selected(false);
            }

            self.filters.setCategory(undefined);
            self.search();
        }

        self.selectedSizes.subscribe(function (value) {
            self.filters.setSizes(value);
            self.search();
        });

        self.selectedBrands.subscribe(function (value) {
            self.filters.setBrands(value);
            self.search();
        });

        self.selectedBrands.subscribe(function (value) {
            self.filters.setBrands(value);
            self.search();
        });

        self.unsetSizeFilters = function () {
            self.selectedSizes([]);
        }

        self.unsetBrandFilters = function () {
            self.selectedBrands([]);
        }

        self.loadMoreProducts = function () {
            self.filters.nextPage();
            self.search();
        }

        //

        //private func 

        var loadFilters = function () {
            $.ajax({
                url: endpoints.Filters,
                type: 'GET',
                success: function (response) {

                    //load brands
                    self.brandFilters(_.map(response.Brands, b => new Brand(b)));

                    //load sizes
                    self.sizeFilters(_.map(response.Sizes, s => new Size(s)));

                    //load categories
                    self.categoryFilters(_.map(response.Categories, c => new Category(c)));
                },
                failure: function (data) {
                    alert(data);
                }
            });
        }
    }

    $.extend(ns, {List: List});

}(jQuery, ko, Products));