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
function AjaxMethodFunctionn(Url , data,data1, method, successCallback)
{
    
    $.ajax({
        method: method,
        url: Url,
        traditional:true,
        datatype:'json',
        data:{
            studentes:data,
            courseID:data1,
        },
        success: successCallback,
      
    }); 
}

