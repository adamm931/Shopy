(function ($, ko) {
    
    ko.bindingHandlers.imagePreview = {
        init: function (element, valueAccessor, allBindings) {

            readUrl(element);

            ko.utils.registerEventHandler(element, "change", function () {
                readUrl(element);
            });
        }
    };

    function readUrl(input) {

        if (input.files && input.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $(input).parent().find('img').attr('src', e.target.result);
            }

            reader.readAsDataURL(input.files[0]);
        }
    }

}(jQuery, ko));