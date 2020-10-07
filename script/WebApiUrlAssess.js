function AjaxMethodFunction(Url , receivedata, method, successCallback)
{
    
    $.ajax({
        method: method,
        url: Url,
        traditional:true,
        data:receivedata,
        success: successCallback,
      
    }); 
}
