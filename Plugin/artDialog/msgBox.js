function Alert(message) {
    art.dialog({
        content: message,
        icon: 'warning',
        title: '警告',
        ok: true
    });
}

function Alert(message, ctlNameOrpageUrl) {
    art.dialog({
        content: message,
        icon: 'warning',
        title: '警告',
        ok: function () {
            if (ctlNameOrpageUrl.IndexOf(".") >= 0) {
                self.location = str_CtlNameOrPageUrl;
            }
            else {
                $(ctlNameOrpageUrl).focus();
                $(ctlNameOrpageUrl).select();
            }
        }
    });
}

function Confirm(message, button) {
    art.dialog({
        content: message,
        icon: 'warning',
        title: '警告',
        ok: function () {
            $(button).click();
        },
        cancle: true
    });
}