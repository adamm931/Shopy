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

        //toogle filters
        //self.selectAllBrandFilters = ko.observable(false);
        //self.selectAllSizeFilters = ko.observable(false);

        //filters
        self.categoryFilters = ko.observableArray();
        self.brandFilters = ko.observableArray();
        self.sizeFilters = ko.observableArray();

        //items
        self.sourceItems = ko.observableArray([]);
        self.items = ko.observableArray();

        //selected filters
        self.selectedSizes = ko.observableArray();
        self.selectedBrands = ko.observableArray();
        self.selectedCategory = ko.observable();

        //filter object
        self.filters = new SearchFilters();
        
        //public func

        self.search = function () {

            $.ajax({
                url: endpoints.Search,
                data: self.filters.data(),
                type: 'POST',
                success: function (response) {

                    if (response.Success) {
                        var responseItems = _.map(response.Items, i => new Product(i));
                        _.each(responseItems, ri => self.items.push(ri));
                        _.each(responseItems, ri => self.sourceItems.push(ri));
                    }
                    else {
                        console.error(response.Message);
                    }
                },
                failure: function (response) {
                    alert(response);
                }
            });
        }

        self.setSelectedCategory = function (item, callback) {

            _.each(self.categoryFilters(), cf => cf.selected(cf.id == item.id));

            var selectedCategory = _.find(self.categoryFilters(), cf => cf.selected() == true);

            self.filters.setCategory(selectedCategory);

            filterProductsLocally();
        }

        self.unsetSelectedCategory = function () {

            var selectedCategory = _.find(self.categoryFilters(), cf => cf.selected() == true);

            if(selectedCategory !== undefined) {
                selectedCategory.selected(false);
            }

            self.filters.setCategory(undefined);
            filterProductsLocally();
        }

        self.selectedSizes.subscribe(function (value) {
            var pure = _.map(value, v => v.replace("s", ""));
            self.filters.setSizes(pure);
            filterProductsLocally();
        });

        self.selectedBrands.subscribe(function (value) {
            var pure = _.map(value, v => v.replace("b", ""));
            self.filters.setBrands(pure);
            filterProductsLocally();
        });

        self.unsetSizeFilters = function () {
            self.selectedSizes([]);
        }

        self.unsetBrandFilters = function () {
            self.selectedBrands([]);
        }

        //self.selectAllBrandFilters.subscribe(function (value) {
        //    if (value) {
        //        self.selectedBrands(_.map(self.brandFilters(), b => b.id));
        //    }

        //    else {
        //        self.selectedBrands([]);
        //    }
        //});

        //self.toogleBrandFilters = function () {
        //    self.selectAllBrandFilters(!self.selectAllBrandFilters());
        //}

        //self.selectAllSizeFilters.subscribe(function (value) {
        //    if (value) {
        //        self.selectedSizes(_.map(self.sizeFilters(), s => s.id));
        //    }

        //    else {
        //        self.selectedSizes([]);
        //    }
        //});

        //self.toogleSizeFilters = function () {
        //    self.selectAllSizeFilters(!self.selectAllSizeFilters());
        //}

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

        var filterProductsLocally = function () {
            self.filters.filterItems(self.sourceItems(), self.items);
        }

        //
    }

    function Size(size) {

        var self = this;

        self.id = "s" + size.EId;
        self.caption = size.Caption;
        self.checked = ko.observable(false);
    }

    function Brand(brand) {

        var self = this;

        self.id = "b" + brand.EId;
        self.caption = brand.Caption;
        self.checked = ko.observable(false);
    }

    function SearchFilters() {

        var self = this;

        //make this configurabile
        self.pageIndex = 0;
        self.pageSize = 9;

        self.category = null;
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

        self.setCategory = function (category) {
            self.category = category;
        }

        self.filterItems = function (source, items) {

            var retByBrand = source;
            var retBySizes = source;
            var retByCategory = source;

            //brands
            if (_.some(self.brands)) {
                retByBrand = _.filter(source,
                    i => _.some(self.brands, b => b == i.brand));
            }

            //sizes
            if (_.some(self.sizes)) {
                retBySizes = _.filter(source,
                    r => _.some(r.sizes,
                        rs => _.some(self.sizes, s => s == rs)));
            }

            //category
            if (self.category != null) {
                retByCategory = _.filter(source,
                   i => _.some(i.categories, ic => ic.id == self.category.id));
            }

            //prices
            var ret = _.intersection(
                source,
                retByBrand,
                retBySizes,
                retByCategory);

            items(ret);
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