function AjaxMethodFunction(Url , receivedata, method, successCallback)
{
    debugger;
    alert(method);

    $.ajax({
        method: method,
        url: Url,
        data:receivedata,
        success: successCallback,
      
    }); 
}

