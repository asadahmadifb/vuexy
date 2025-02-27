(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports) :
      typeof define === 'function' && define.amd ? define(['exports'], factory) :
        (factory((global.fa = {})));
}(this, (function (exports) { 'use strict';

    var fp = typeof window !== "undefined" && window.flatpickr !== undefined
      ? window.flatpickr
      : {
          l10ns: {},
      };
    var Persian = {
        weekdays: {
            shorthand: ['ی', 'د', 'س', 'چ', 'پ', 'ج', 'ش'],
            longhand: [
                "یک‌شنبه",
                "دوشنبه",
                "سه‌شنبه",
                "چهارشنبه",
                "پنچ‌شنبه",
                "جمعه",
                "شنبه",
            ],
        },
        months: {
            shorthand: [
                "ژانویه",
                "فوریه",
                "مارس",
                "آپریل",
                "می",
                "جوئن",
                "جولای",
                "آگست",
                "سپتامبر",
                "اکتبر",
                "نوامبر",
                "دسامبر",
            ],
            longhand: [
                "ژانویه",
                "فوریه",
                "مارس",
                "آپریل",
                "می",
                "جوئن",
                "جولای",
                "آگست",
                "سپتامبر",
                "اکتبر",
                "نوامبر",
                "دسامبر",
            ],
        },
        ordinal: function () {
            return "";
        },
        amPM: ["ق.ظ", "ب.ظ"],
    };
    fp.l10ns.fa = Persian;
    var fa = fp.l10ns;

    exports.Persian = Persian;
    exports.default = fa;

    Object.defineProperty(exports, '__esModule', { value: true });

})));
