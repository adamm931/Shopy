(function ($) {

    //validation method
    $.validator.addMethod("imagefilevalidation", function (value, element, params) {
        var files = element.files;
        if (files && files[0]) {
            if (files[0].size > params.size) {
                return false;
            }
            else {
                return true;
            }
        }
        return true;
    });

    //adapter
    $.validator.unobtrusive.adapters.add("imagefilevalidation", ["size"], function (options) {
        options.rules['imagefilevalidation'] = {
            size: options.params.size
        };
        options.messages['imagefilevalidation'] = options.message;
    });

}(jQuery));