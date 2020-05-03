function SearchFilters() {

    var self = this;

    self.pageIndex = 0;
    self.pageSize = 9;

    self.categoryId;
    self.brands;
    self.sizes;
    self.minPrice = sliderOptions.minInitial;
    self.maxPrice = sliderOptions.maxInitial;

    self.nextPage = function () {
        self.pageSize += self.pageSize;
        setToCache('pageSize', self.pageSize);
    }

    self.setBrands = function (brands) {
        self.brands = setToCache('brands', brands);
    }

    self.getBrands = function () {
        return self.brands === null ? [] : self.brands.split(',');
    }

    self.setSizes = function (sizes) {
        self.sizes = setToCache('sizes', sizes);
    }

    self.getSizes = function () {
        return self.sizes === null ? [] : self.sizes.split(',');
    }

    self.setMinPrice = function (min) {
        self.minPrice = setToCache('minPrice', min);
    }

    self.setMaxPrice = function (max) {
        self.maxPrice = setToCache('maxPrice', max);
    }

    self.setCategory = function (categoryId) {
        self.categoryId = categoryId;
    }
    
    self.data = function () {
        return {
            PageIndex: self.pageIndex,
            PageSize: self.pageSize,
            Brands: self.brands,
            Sizes: self.sizes,
            MinPrice: self.minPrice,
            MaxPrice: self.maxPrice,
            CategoryUid: self.categoryId
        }
    }

    self.init = function () {

        self.pageSize = self.getFromCache('pageSize', publicOptions.pageSize)
        self.brands = self.getFromCache('brands', null)
        self.sizes = self.getFromCache('sizes', null)
        self.minPrice = self.getFromCache('minPrice', sliderOptions.minInitial)
        self.maxPrice = self.getFromCache('maxPrice', sliderOptions.maxInitial)
    }

    self.getFromCache = function(key, defaultValue) {
        return sessionStorage.getItem(key) || defaultValue
    }

    var setToCache = function (key, value) {
        sessionStorage.setItem(key, value);
        return value;
    }
}