﻿var Public = Public || {};

(function ($, ko, ns) {
    
    function Index(spinner) {
        var self = this;

        self.init = function () {
            loadFilters();
            setFilters();
            self.search();
        }
        
        self.loading = ko.observable(false);

        //filters
        self.categories = ko.observableArray();
        self.brands = ko.observableArray();
        self.sizes = ko.observableArray();

        //items
        self.hasMoreRecords = ko.observable(true);
        self.items = ko.observableArray();

        //selected filters
        self.selectedSizes = ko.observableArray();
        self.selectedBrands = ko.observableArray();
        self.selectedCategory = ko.observable();

        //filter object
        self.filters = new SearchFilters();
        
        //public func

        self.search = function () {

            loadingOn();

            $.ajax({
                url: endpoints.Search,
                data: self.filters.data(),
                type: 'POST',
                success: function (response) {

                    if (response.Success) {
                        var responseData= response.Data;
                        var items = _.map(responseData.Result, i => new Product(i));
                        self.items(items);
                        self.hasMoreRecords(self.filters.pageSize < responseData.TotalRecords)
                    }
                    else {
                        console.error(response.Message);
                    }

                    loadingOff();
                },
                failure: function (response) {
                    alert(response);
                    loadingOff();
                }
            });

        }

        self.setSelectedCategory = function (category, callback) {

            _.each(self.categories(), cf => cf.selected(cf.id == category.id));

            var selectedCategory = _.find(self.categories(), cf => cf.selected() == true);

            self.filters.setCategory(selectedCategory.id);

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

        var setFilters = function () {

            self.filters.init();

            self.selectedBrands(self.filters.getBrands());
            self.selectedSizes(self.filters.getSizes());
        }

        var loadFilters = function () {

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

        var loadingOn = function () {
            self.loading(true);
        }

        var loadingOff = function () {
            self.loading(false);
        }
    }

    $.extend(ns, { Index: Index });

}(jQuery, ko, Public));