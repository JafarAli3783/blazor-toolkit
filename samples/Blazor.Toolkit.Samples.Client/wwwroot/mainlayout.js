// MainLayout JS helpers -- centralize inline scripts for Blazor interop
(function(window){
    window.mainLayout = window.mainLayout || {};

    // Ensure a responsive helper is available on window.responsiveBlazor
    window.mainLayout.ensureResponsive = function(){
        if (!window.responsiveBlazor) {
            window.responsiveBlazor = {
                _handler: null,
                _dotNetRef: null,
                register: function(dotNetRef){
                    this._dotNetRef = dotNetRef;
                    var timer = null;
                    var self = this;
                    function handler(){
                        clearTimeout(timer);
                        timer = setTimeout(function(){
                            try { self._dotNetRef.invokeMethodAsync('NotifyResize', window.innerWidth); } catch(e){}
                        }, 120);
                    }
                    window.addEventListener('resize', handler);
                    this._handler = handler;
                    handler();
                },
                dispose: function(){
                    if (this._handler) { window.removeEventListener('resize', this._handler); this._handler = null; }
                    this._dotNetRef = null;
                }
            };
        }
    };

    function applyToolkitTheme(theme) {
        var themeLink = document.getElementById('syncfusion-theme');
        if (themeLink) {
            themeLink.href = theme === 'highcontrast'
                ? '_content/Syncfusion.Blazor.Toolkit/styles/highcontrast.min.css'
                : '_content/Syncfusion.Blazor.Toolkit/styles/fluent.min.css';
        }

        document.documentElement.classList.toggle('dark', theme === 'dark');
        document.documentElement.classList.toggle('highcontrast', theme === 'highcontrast');
        document.body.classList.toggle('e-dark-mode', theme === 'dark');
    }

    // Theme init: returns 'light', 'dark', or 'highcontrast'
    window.mainLayout.initTheme = function(){
        try{
            var t = localStorage.getItem('theme') || 'light';
            if (t !== 'dark' && t !== 'highcontrast') { t = 'light'; }
            applyToolkitTheme(t);
            return t;
        } catch(e){ return 'light'; }
    };

    // Dir init: returns 'rtl' or 'ltr'
    window.mainLayout.initDir = function(){
        try{
            var d = localStorage.getItem('dir') || 'ltr';
            document.documentElement.dir = d;
            if (d === 'rtl'){
                document.documentElement.classList.add('rtl');
                document.documentElement.classList.add('page-rtl');
            } else {
                document.documentElement.classList.remove('rtl');
                document.documentElement.classList.remove('page-rtl');
            }
            return d;
        } catch(e){ return 'ltr'; }
    };

    // Set direction and persist
    window.mainLayout.setDir = function(dir){
        try{
            localStorage.setItem('dir', dir);
            document.documentElement.dir = dir;
            if (dir === 'rtl'){
                document.documentElement.classList.add('rtl');
                document.documentElement.classList.add('page-rtl');
            } else {
                document.documentElement.classList.remove('rtl');
                document.documentElement.classList.remove('page-rtl');
            }
        } catch(e){}
    };

    // Set theme and persist
    window.mainLayout.setTheme = function(theme){
        try{
            if (theme !== 'dark' && theme !== 'highcontrast') { theme = 'light'; }
            localStorage.setItem('theme', theme);
            applyToolkitTheme(theme);

            window.dispatchEvent(new CustomEvent('mainlayout-themechanged', { detail: theme }));
        } catch(e){}
    };

    window.mainLayout.observeTheme = function(dotNetRef){
        try{
            window.mainLayout._themeDotNetRef = dotNetRef;

            if (!window.mainLayout._themeHandler) {
                window.mainLayout._themeHandler = function (e) {
                    try {
                        var theme = (e && e.detail) ? e.detail : (document.documentElement.classList.contains('dark') ? 'dark' : 'light');
                        window.mainLayout._themeDotNetRef.invokeMethodAsync('NotifyThemeChanged', theme);
                    } catch(err){}
                };

                window.addEventListener('mainlayout-themechanged', window.mainLayout._themeHandler);
            }

            var currentTheme = localStorage.getItem('theme') || 'light';
            if (currentTheme !== 'dark' && currentTheme !== 'highcontrast') { currentTheme = 'light'; }
            dotNetRef.invokeMethodAsync('NotifyThemeChanged', currentTheme);
        } catch(e){}
    };

    window.mainLayout.disposeThemeObserver = function(){
        try{
            if (window.mainLayout._themeHandler) {
                window.removeEventListener('mainlayout-themechanged', window.mainLayout._themeHandler);
                window.mainLayout._themeHandler = null;
            }
            window.mainLayout._themeDotNetRef = null;
        } catch(e){}
    };

    // Navigate helpers
    window.mainLayout.assignRoot = function(){ try { location.assign('/'); } catch(e){} };
    window.mainLayout.reload = function(){ try { location.reload(); } catch(e){} };

    // Set culture fallback used by ModeSwitcher: persist to localStorage and cookie
    window.mainLayout.setCulture = function(culture){
        try{
            localStorage.setItem('BlazorCulture', culture);
            var cookieName = '.' + 'AspNetCore.Culture';
            var cookieValue = 'c=' + culture + '|uic=' + culture;
            document.cookie = cookieName + '=' + encodeURIComponent(cookieValue) + '; path=/';
        } catch(e){}
    };

    window.copyCode = (text) => {
        navigator.clipboard.writeText(text);
    };


    window.refreshTab = (code, element) => {
        var highlightCodeInterval = setInterval(highlightSource, 0);
        function highlightSource() {
            var tabs = element;
            if (tabs) {
                tabs.innerHTML = code;
                tabs.classList.add('blazor');
                hljs.highlightBlock(tabs);
                clearInterval(highlightCodeInterval);
            }
        }
    };

})(window);
