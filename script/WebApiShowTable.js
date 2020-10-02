var Url="https://localhost:44319/api/Students/";

//Student List Show Method
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

// Sent Edit Student Id
function editstudent(id)
{
    // First send ajax call fro getById
    // success
    // data
    // href(/Pahge/+ data)
    
   window.document.location ='WebApiUpdateStd.html' +'?' + id;
   

}
var getid=document.location.search.split('?');
var h =getid[1];
// Edit Student Record Set IN Field
function ValueSetInField()
{
    debugger;
    
    $.get(Url +  h ,function(data , status){
        $('#esname').val(data.Studentname);
        $('#eemail').val(data.StudentEmail);
        $('#ephone').val(data.PhoneNumber);
        $('#edob').val(data.DateOfBirth);
        $('#epassword').val(data.Password);
        $('#econfirmpassword').val(data.ConfirmPawword);

    });
  // alert(h);
    
  
}

// Update Student Methid
$(document).ready(function(){
    $("#btn").click(function(){
        var name = $("#esname").val();
        var email = $("#eemail").val();
        var phonenumber = $("#ephone").val();
    
        var gdate = $("#edob").val();
        var cdate = gdate.toString();
        var password = $("#epassword").val();
        var confirmpassword = $("#econfirmpassword").val();
        var checkinput = inputfieldvalidate(name, email, phonenumber, password, confirmpassword);
        if(checkinput)
        {
              
            var student = {
                Studentname: name,
                StudentEmail: email,
                PhoneNumber: phonenumber,
                DateOfBirth: cdate,
               Password: password,
               ConfirmPawword: confirmpassword,
        
            };
            
            $.ajax({
                
                url:Url + h ,
                method:"PUT",
                data:student,
                success:function(data){
                    if(data==true)
                    {
                        window.location.href="WebApiStudentList.html";
                    }
                }
                
            });
           
            
    
    
    
        }
       
    });
  });
  // Delete Student Function

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




//Form Submit Function Call
$('#form').submit(function() {
   debugger;
    
   return getrecordaddsave();
        
    
});

// Get Student Record And save Method
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

    //Input Field Validation
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

    