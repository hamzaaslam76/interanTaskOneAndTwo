var Url="https://localhost:44319/api/Students/";
function GetRecordFromWebApi()
{


$.get(Url, function(data, status){
    
 
    if (data != null) {
        debugger;
        data.forEach((value, index, array) => {

            var row = `<tr>
                <td>${value.StudentId}</td>
                <td>${value.Studentname}</td>
                <td>${value.StudentEmail}</td>
                <td>${value.PhoneNumber}</td>
                <td>${value.DateOfBirth}</td>
                <td>${value.Password}</td>
              
                <td><button onclick=editstudent(${value.StudentId})> Edit</button></td>
                
                <td><button onclick=deleterecord(${value.StudentId})>    Delete</button></td>
                 </tr>`

           $("#myTable").append(row);

        });
    }

});
}
function deleterecord(id)
{
    debugger;
    jQuery.ajax({
       
     url:Url + id,
     method:"DELETE",
     success:function(responce)
     {
        if(responce==true)
        {
        location.reload();
        }
     }

     
   });
   

}



$('#form').submit(function() {
   debugger;
    
   return getrecordaddsave();
        
    
});
function getrecordaddsave() {

    debugger;
        var name = $("#sname").val();
        var email =$("#email").val();
        var phonenumber = $("#phone").val();
    
        var gdate = $("#dob").val();
        var cdate = gdate.toString();
        var password = $("#password").val();
        var confirmpassword = $("#confirmpassword").val();
    
        var checkinput = inputfieldvalidate(name, email, phonenumber, password, confirmpassword);
    
    
        
        if (checkinput) {
            
            
            
            var student = {
                Studentname: name,
                StudentEmail: email,
                PhoneNumber: phonenumber,
                DateOfBirth: cdate,
               Password: password,
               ConfirmPawword: confirmpassword,
        
            };
                 debugger;
            $.post(Url,student,
        function(data,status){
            debugger;
     
    });
    
    
        }
        return checkinput;
    
    
    }
    function inputfieldvalidate(nam, em, pon, pass, conpass) {
        if (namedfieldcheck(nam)) {
            $("#chname").text("");
    
        } else {
            $("#chname").text("Please inter correct name") ;
            return false;
    
        }
    
        if (emailFieldCheck(em)) {
    
            $("#chemail").text("");
        } else {
            $("#chemail").text("Incorrect Email");
            return false;
        }
        if (phoneFieldCheck(pon)) {
            $("#chphone").text("");
    
        } else {
            $("#chphone").text("Invalid Number");
            return false;
        }
        if (passwordFieldCheck(pass)) {
            $("#chpassword").text("");
    
        } else {
            var str = "Enter At least 8 characters,Include at least 1 lowercase letter 1 capital letter, 1 number,1 special character";
            $("#chpassword").text(str);
            return false;
        }
        if (pass === conpass) {
            $("#chconpassword").text("");
        } else {
            $("#chconpassword").text("Password Not Match");
            return false;
        }
    
        return true;
    }

    