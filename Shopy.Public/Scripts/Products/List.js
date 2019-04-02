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

        self.categoryFilters = ko.observableArray();
        self.brandFilters = ko.observableArray();
        self.sizeFilters = ko.observableArray();

        self.selectedSizes = ko.observableArray();
        self.selectedBrands = ko.observableArray();

        self.items = ko.observableArray();
        self.filters = new SearchFilters();

        self.search = function () {

            $.ajax({
                url: endpoints.Search,
                data: self.filters.data(),
                type: 'POST',
                success: function (response) {
                    //_.each(response.Items, i => self.items.push(new Product(i)));
                    self.items(_.map(response.Items, i => new Product(i)));
                },
                failure: function (response) {
                    aler('Error');
                }
            });
        }

        self.selectedSizes.subscribe(function (value) {
            var pure = _.map(value, v => v.replace("s", ""));
            self.filters.setSizes(pure);
            self.search();
        });

        self.selectedBrands.subscribe(function (value) {
            var pure = _.map(value, v => v.replace("b", ""));
            self.filters.setBrands(pure);
            self.search();
        });

        self.loadMoreProducts = function () {
            self.filters.nextPage();
            self.search();
        }

        var loadFilters = function () {
            $.ajax({
                url: endpoints.Filters,
                type: 'GET',
                success: function (response) {

                    //load brands
                    self.brandFilters(_.map(response.Brands, b => new BrandFilter(b)));

                    //load sizes
                    self.sizeFilters(_.map(response.Sizes, s => new SizeFilter(s)));

                    //load categories
                    self.categoryFilters(_.map(response.Categories, c => new CategoryFilter(c)));
                },
                failure: function (data) {
                    aler('Error');
                }
            });
        }
    }

    function Product(item) {

        var self = this;

        self.price = item.Price;
        self.caption = item.Caption;
        self.detailsLink = endpoints.Details.replace("id", item.Uid);
        self.image1Url = productImage1UrlTemplate.replace("{{id}}", item.Uid);
        self.size = item.Size;
        self.brand = item.Brand;
    }

    function SizeFilter(size) {

        var self = this;

        self.id = "s" + size.EId;
        self.caption = size.Caption;
        self.checked = ko.observable(false);
    }

    function BrandFilter(brand) {

        var self = this;

        self.id = "b" + brand.EId;
        self.caption = brand.Caption;
        self.checked = ko.observable(false);
    }

    function CategoryFilter(category) {

        var self = this;

        self.id = category.Uid;
        self.caption = category.Caption;
    }

    function SearchFilters() {

        var self = this;

        //make this configurabile
        self.pageIndex = 0;
        self.pageSize = 9;

        self.categories = [];
        self.brands = [];
        self.sizes = [];
        self.minPrice = 0;
        self.maxPrice = Number.MAX_SAFE_INTEGER;

        self.nextPage = function () {
            self.pageIndex += 1;
            self.pageSize += self.pageSize;
        }

        self.setBrands = function (brands) {
            self.brands = brands;
        }

        self.setSizes = function (sizes) {
            self.sizes = sizes;
        }

        self.setPrices = function (max, min) {
            self.maxPrice = max;
            self.minPrice = minPrice;
        }

        self.data = function () {
            return  {
                PageIndex: self.pageIndex,
                PageSize: self.pageSize,
                Brands: self.brands,
                Sizes: self.sizes,
                MinPrice: self.minPrice,
                MaxPrice: self.maxPrice
            }
        }
    }

    $.extend(ns, {List: List});

}(jQuery, ko, Products));