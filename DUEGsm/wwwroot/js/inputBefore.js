document.addEventListener("DOMContentLoaded", function () {
    var button = document.querySelector('.inputButtonStyle');
    button.addEventListener('mouseenter', function () {
        button.style.backgroundColor = "#62134C";
    });
    button.addEventListener('mouseleave', function () {
        button.style.backgroundColor = "#150036";
    });
});