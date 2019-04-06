// ## IDEA ## 
// when brands and size filter is changed filter the local products
// on button click load more product from api with setted filters localy

var Products = Products || {};

(function ($, ko, ns) {
    
    function List() {
        var self = this;

        self.init = function () {
            loadFilters();
            search();
        }

        self.requestInProgress = ko.observable(false);

        //filters
        self.categories = ko.observableArray();
        self.brands = ko.observableArray();
        self.sizes = ko.observableArray();

        //items
        //self.sourceItems = ko.observableArray([]);
        self.items = ko.observableArray();

        //selected filters
        self.selectedSizes = ko.observableArray();
        self.selectedBrands = ko.observableArray();
        self.selectedCategory = ko.observable();
        self.iniMinPrice = ko.observable(10);
        self.iniMaxPrice = ko.observable(500);

        //filter object
        self.filters = new SearchFilters();
        
        //public func

        self.search = function (callback) {

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

                        //self.items(responseItems);

                        callback(responseItems);
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

            _.each(self.categories(), cf => cf.selected(cf.id == item.id));

            var selectedCategory = _.find(self.categories(), cf => cf.selected() == true);

            self.filters.setCategory(selectedCategory);

            self.search();
        }

        self.unsetSelectedCategory = function () {

            var selectedCategory = _.find(self.categories(), cf => cf.selected() == true);

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


            self.filters.setPriceRange(
                self.iniMinPrice(), self.iniMaxPrice());

            $.ajax({
                url: endpoints.Filters,
                type: 'GET',
                success: function (response) {

                    //load brands
                    self.brands(_.map(response.Brands, b => new Brand(b)));

                    //load sizes
                    self.sizes(_.map(response.Sizes, s => new Size(s)));

                    //load categories
                    self.categories(_.map(response.Categories, c => new Category(c)));
                },
                failure: function (data) {
                    alert(data);
                }
            });
        }
    }

    $.extend(ns, {List: List});

}(jQuery, ko, Products));