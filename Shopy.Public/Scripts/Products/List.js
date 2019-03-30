// ## NOTES ## 
// when brands and size filter is changed filter the local products
// on button click load more product from api with setted filters localy

var Products = Products || {};

(function ($, ko, ns) {
    
    function List() {
        var self = this;

        self.init = function () {
            loadFilters();
        }

        self.setFilter = function (filter) {
            self.filter = filter;
        }

        self.categoryFilters = ko.observableArray();
        self.brandFilters = ko.observableArray();
        self.sizeFilters = ko.observableArray();

        self.selectedSizes = ko.observableArray();
        self.selectedBrands = ko.observableArray();

        self.items = ko.observableArray();

        self.search = function () {

            $.ajax({
                url: endpoints.Search,
                data: self.filter,
                type: 'POST',
                success: function (response) {
                    var items = _.map(response.Items, i => new Product(i));
                    self.items(items);
                },
                failure: function (response) {
                    aler('Error');
                }
            });
        }

        var loadFilters = function () {
            $.ajax({
                url: endpoints.Filters,
                type: 'GET',
                success: function (response) {

                    //load brands
                    self.brandFilters(_.map(response.Brands, b => new BrandFilter(b)));
                    self.selectedBrands.push(response.Brands[0].Caption);

                    //load sizes
                    self.sizeFilters(_.map(response.Sizes, s => new SizeFilter(s)));
                    self.selectedSizes.push(response.Sizes[0].Caption);

                    //load categories
                    self.categoryFilters(_.map(response.Categories, c => new CategoryFilter(c)));
                },
                failure: function (data) {
                    aler('Error');
                }
            });
        }

        self.selectedSizes.subscribe(function (value) { console.log('selectedSizes.subscribe' + value); });
        self.selectedBrands.subscribe(function (value) { console.log('selectedBrands.subscribe' + value); });
    }

    function Product(item) {
        
        var self = this;

        self.price = item.Price;
        self.caption = item.Caption;
        self.detailsLink = endpoints.Details.replace("id", item.Uid);

        //here size, brands, categories
    }

    function SizeFilter(size) {

        var self = this;

        self.id = size.Uid;
        self.caption = size.Caption;
        self.checked = ko.observable(false);
    }

    function BrandFilter(brand) {

        var self = this;

        self.id = brand.Uid;
        self.caption = brand.Caption;
        self.checked = ko.observable(false);
    }

    function CategoryFilter(category) {

        var self = this;

        self.id = category.Uid;
        self.caption = category.Caption;
    }

    $.extend(ns, {List: List});

}(jQuery, ko, Products));