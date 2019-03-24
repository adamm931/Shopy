function Products(endpoints) {
    var self = this;

    self.message = ko.observable('Welcome to product list page.');

    self.init = function () {
        console.log('Hello world');
    }

    self.setFilter = function (filter) {
        self.filter = filter;
    }

    self.search = function () {

        jQuery.ajax({
            url: endpoints.Search,
            data: self.filter,
            type: 'POST',
            success: function (response) {

                console.log(response.items);

            },
            failure: function (data) {
                aler('Error');
            }
        })
    }

    self.filter = {
        PageSize: 10,
        PageIndex: 0,
        Sizes: "S,M"
    }
}

function ProductFilter() {

    var self = this;

}