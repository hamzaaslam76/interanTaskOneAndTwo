function AjaxMethodFunction(Url , receivedata, method, successCallback)
{
    debugger;
    $.ajax({
        method: method,
        url: Url,
        traditional:true,
        headers:{'Authorization': ReturnToken()}, 
        data:receivedata,
        success: successCallback,
        error: function (result) {
            alert("Bad Request");
        }     
    }); 
}
function ReturnToken()
{
    return sessionStorage.getItem('accessToken') == null ? null :'Bearer ' + sessionStorage.getItem('accessToken');

}
