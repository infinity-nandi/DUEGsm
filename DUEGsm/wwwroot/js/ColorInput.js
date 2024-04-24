document.addEventListener('DOMContentLoaded', function () {
    var input = document.getElementById('inputColor');
    var originalBackground = window.getComputedStyle(input).background;

    input.addEventListener('input', function () {
        if (input.value) {
            input.style.background = originalBackground;
        } else {
            input.style.background = 'linear-gradient(to right, rgb(98,19,76), rgb(21,0,54))';
        }
    });
});