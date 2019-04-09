function Slider() {

    var self = this;

    self.create = function (products) {

        var slider = document.getElementById('sliderDouble');
        var sliderStart = products.filters.minPrice;
        var sliderEnd = products.filters.maxPrice;

        noUiSlider.create(slider, {
            start: [sliderStart, sliderEnd],
            margin: 100,
            step: 10,
            connect: true,
            range: {
                min: sliderOptions.minEnd,
                max: sliderOptions.maxEnd
            }
        });

        var minInput = document.getElementById('minInput');
        var maxInput = document.getElementById('maxInput');

        minInput.value = sliderStart;
        maxInput.value = sliderEnd;
          
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
        products.filters.setMinPrice(minInput.value);
        products.filters.setMaxPrice(maxInput.value);
        products.search();
    }
}


