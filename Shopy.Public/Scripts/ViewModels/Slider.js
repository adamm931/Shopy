function Slider() {

    var self = this;

    self.create = function (products) {

        var slider = document.getElementById('sliderDouble');
        var sliderStart = products.iniMinPrice();
        var sliderEnd = products.iniMaxPrice();

        //TODO: slider range make configurabile

        noUiSlider.create(slider, {
            start: [sliderStart, sliderEnd],
            margin: 100,
            step: 10,
            connect: true,
            range: {
                min: 10,
                max: 800
            }
        });

        var minInput = document.getElementById('minInput');
        var maxInput = document.getElementById('maxInput');

        minInput.value = products.iniMinPrice();
        maxInput.value = products.iniMaxPrice();
          
        slider.noUiSlider.on('end', function (values, handle) {
            if (handle == 0) {
                minInput.value = values[handle];
            } else {
                maxInput.value = values[handle];
            }

            callSearch();
        });

        minInput.addEventListener('change', function () {
            slider.noUiSlider.set([this.value, null]);
            callSearch();
        });
        maxInput.addEventListener('change', function () {
            slider.noUiSlider.set([null, this.value]);
            callSearch();
        });
    }

    var callSearch = function () {
        products.filters.setPriceRange(minInput.value, maxInput.value);
        products.search();
    }
}


