/*! jquery.extensions.js */
(function ($) {
    /*
    // # Trava campo aceitando somente número
    */
    $.fn.somenteNumeros = function () {
        $(this).keypress(function (e) {
            if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57))
                return false;
            else
                return true;
        });
    }
})(jQuery);