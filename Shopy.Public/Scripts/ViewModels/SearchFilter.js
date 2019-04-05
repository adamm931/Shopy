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

    self.setPriceRange = function (min, max) {
        self.maxPrice = max;
        self.minPrice = min;
    }

    self.setCategory = function (category) {
        self.category = category;
    }
    
    self.data = function () {
        return {
            PageIndex: self.pageIndex,
            PageSize: self.pageSize,
            Brands: self.brands,
            Sizes: self.sizes,
            MinPrice: self.minPrice,
            MaxPrice: self.maxPrice,
            CategoryUid: self.category == null ? null : self.category.id
        }
    }
}