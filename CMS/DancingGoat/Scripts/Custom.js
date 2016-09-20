(function ($) {
    var urlSegments = window.location.hash.split('#');
    if (urlSegments.length > 0 && urlSegments.length == 2) {
        var newURL = urlSegments[0] + "?" + urlSegments[1];
        window.location = newURL;
    }
})(jQuery);