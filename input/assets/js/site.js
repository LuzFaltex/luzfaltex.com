document.getElementById('themeSwitch').addEventListener('change', function (event) {
    changeTheme(event.target.checked);
});

document.addEventListener('DOMContentLoaded', function () {
    // Get the current theme variable
    var theme = getCookie('theme');

    if (theme === 'dark') {
        changeTheme(true);
    }
    else if (theme === 'light') {
        changeTheme(false);
    }
    else {
        // No cookie found. Get their preference.
        if (window.matchMedia) {
            changeTheme(window.matchMedia('(prefers-color-scheme: dark)').matches);
        }
        else {
            // No preference. Use dark.
            changeTheme(true);
        }
    }

    // Initialize Prism Grammars
    Prism.plugins.autoloader.languages_path = 'assets/js/grammars/';

    // Initialize Kube
    $K.init({
        observer: true
    });
});

function changeTheme(isDark) {
    var themeSwitch = document.getElementById('themeSwitch');

    if (isDark === true) {
        setCookie('theme', 'dark');
        document.body.setAttribute('data-theme', 'dark');
        themeSwitch.checked = true;
    }
    else {
        setCookie('theme', 'light');
        document.body.setAttribute('data-theme', 'light');
        themeSwitch.checked = false;
    }
}

function setCookie(name, value, expiresInDays = 0) {
    var d = new Date();
    var expires = "";
    if (expiresInDays > 0) {
        d.setTime(d.getTime() + (expiresInDays * 24 * 60 * 60 * 1000));
        expires = ";expires=" + d.toUTCString();
    }
    document.cookie = name + "=" + value + expires + ";path=/" + ";SameSite=Strict";
}

function getCookie(name) {
    var cname = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(cname) == 0) {
            return c.substring(cname.length, c.length);
        }
    }
    return "";
}