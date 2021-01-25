document.getElementById('themeSwitch').addEventListener('change', function(event) {
    (event.target.checked) ? document.body.setAttribute('data-theme', 'dark') : document.body.setAttribute('data-theme', 'light');
});