$(document).ready(function () {

    $("#login").click(function () {
       debugger;
         var login ={
            grant_type : "password",
            username: $("#email").val(),
            password : $("#password").val()
            
          
         };
         AjaxMethodFunction("http://localhost:54401/Login",login,'POST', onSuccess)     
    
        
              function onSuccess (result)
              {
                 console.log(result);
                 sessionStorage.setItem('accessToken', result.access_token);
                 sessionStorage.setItem('fullresult',JSON.stringify( result));
                 //sessionStorage.setItem('username', result.Email);
                  debugger;
                 window.location.href = "WebApiStudent.html";
             }
    });
});