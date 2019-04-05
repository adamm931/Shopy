function Slider() {

    var self = this;

    self.create = function (products) {

        var slider = document.getElementById('sliderDouble');

        noUiSlider.create(slider, {
            start: [10, 800],
            margin: 100,
            step: 10,
            connect: true,
            range: {
                min: 0,
                max: 1000
            }
        });

        var minInput = document.getElementById('minInput');
        var maxInput = document.getElementById('maxInput');

        minInput.value = 10;
        maxInput.value = 800;
          
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


