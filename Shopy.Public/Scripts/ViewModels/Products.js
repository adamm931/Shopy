// ## NOTES ## 
// when brands and size filter is changed filter the local products
// on button click load more product from api with setted filters localy

function Products(endpoints) {
    var self = this;

    self.message = ko.observable('Welcome to product list page.');

    self.init = function () {
        console.log('Hello world');

        loadFilters();
    }

    self.setFilter = function (filter) {
        self.filter = filter;
    }

    self.categoryFilters = ko.observableArray([]);
    self.brandFilters = ko.observableArray([]);
    self.sizeFilters = ko.observableArray([]);

    self.selectedSizes = ko.observableArray([]);
    self.selectedBrands = ko.observableArray([]);

    self.items = ko.observableArray([]);

    self.search = function () {

        jQuery.ajax({
            url: endpoints.Search,
            data: self.filter,
            type: 'POST',
            success: function (response) {
                var projection = _.map(response.items, i => new Product(i));
                self.items(projection);

                console.log(self.items());
            },
            failure: function (data) {
                aler('Error');
            }
        });
    }

    var loadFilters = function () {
        jQuery.ajax({
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