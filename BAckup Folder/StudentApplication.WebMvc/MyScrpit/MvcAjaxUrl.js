function AjaxMethodFunction(Url, studentes, types, successCallback) {

    $.ajax({
        type: types,
        url: Url,
        traditional: true,
        data: studentes,
        success: successCallback,

    });
}
