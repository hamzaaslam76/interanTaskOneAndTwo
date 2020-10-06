
var BaseUrl="https://localhost:44319/api/";

//Student List Show Method
function GetRecordFromWebApi()
{
    debugger;
  var Url = BaseUrl + "Students/"
AjaxMethodFunction(Url,null,'GET',onSuccess);

function onSuccess(data) {
    
    
    if (data != null) {
        debugger;
        data.forEach((value, index, array) => {

            var row = `<tr>
                <td>${value.studentDto.StudentId}</td>
                <td>${value.studentDto.Studentname}</td>
                <td>${value.studentDto.StudentEmail}</td>
                <td>${value.studentDto.PhoneNumber}</td>
                <td>${value.studentDto.DateOfBirth}</td>
                <td>${value.studentDto.Password}</td>
                <td>${value.StudentCourseCount}</td>
              
                <td><button onclick=editstudent(${value.studentDto.StudentId})> Edit</button></td>
                
                <td><button onclick=deleterecord(${value.studentDto.StudentId})>    Delete</button></td>
                 </tr>`

           $("#myTable").append(row);

        });
    }   
}
}

// Sent Edit Student Id
function editstudent(id)
{
   window.document.location ='WebApiUpdateStd.html' +'?' + id;

}
var getid=document.location.search.split('?');
var EditId =getid[1];
// Edit Student Record Set IN Field
function ValueSetInField()
{   
    var Url =BaseUrl + "Students/" + EditId;   
    AjaxMethodFunction(Url ,null,'GET',onSuccess);
    function onSuccess(data) {
        console.log(data);
    
        $('#esname').val(data.studentDto.Studentname);
        $('#eemail').val(data.studentDto.StudentEmail);
        $('#ephone').val(data.studentDto.PhoneNumber);
        $('#edate').val(data.studentDto.DateOfBirth);
        $('#epassword').val(data.studentDto.Password);
        $('#econfirmpassword').val(data.studentDto.ConfirmPawword);
        data.StudentCourses.forEach(function(value,index,array)
        {
            $('.select2').each(function(){
                
                var option=$(this);
                  var id=option.val();
                  if(value.CourseId == id)
                  {
                    
                     $(this).prop('selected', true);
                  }
            });
        });
    }
}

// Update Student Method

    $("#ebtn").click(function(){
        var name = $("#esname").val();
        var email = $("#eemail").val();
        var phonenumber = $("#ephone").val();
        var Editselect = $("#myselect").val();
        var gdate = $("#edate").val();
        var cdate = gdate.toString();
        var password = $("#epassword").val();
        var confirmpassword = $("#econfirmpassword").val();
        var checkinput = inputfieldvalidate(name, email, phonenumber, password, confirmpassword);
        if(checkinput)
        {
              
            var student = {
                StudentId:EditId ,
                Studentname: name,
                StudentEmail: email,
                PhoneNumber: phonenumber,
                DateOfBirth: cdate,
               Password: password,
               ConfirmPawword: confirmpassword,
        
            };
            var strarray = Editselect.toString();
            var Url = BaseUrl + "Students/";
             debugger;
             AjaxMethodFunction(Url + "?array=" + strarray, student , 'PUT', onSuccess);
             function onSuccess(data)
             {
                if(data == true)
                {
                    window.location.href="WebApiStudentList.html";
                }
               
             }
    
        }
        return checkinput;
       
    });
  
  // Delete Student Function

function deleterecord(id)
{
    
    var Url =BaseUrl + "Students/" + id;
    
    AjaxMethodFunction(Url, null , 'DELETE', onSuccess);
    function onSuccess(data)
             {
                if(data==true)
                {
                    location.reload();
                }
             }

}

// Get Student Record And save Method
$(document).ready(function(){
    $("#btn").click(function(){
    
        var name = $("#sname").val();
        var email =$("#email").val();
        var phonenumber = $("#phone").val();
        debugger;
        var selectco = $("#myselect").val();

        var gdate = $("#date").val();
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
            var Url = BaseUrl + "Students/"; 
            var ar = selectco.toString();
            AjaxMethodFunction(Url+"?courseID="+ ar , student , 'POST', onSuccess);
            function onSuccess(data)
            {
               
               if(data == true)
               {
               location.reload();
               }
                  
            }   
             
        }
        return checkinput;

    });
  });

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

// Course set in Select Field
function GetCourseInTable()
{

    var Url = BaseUrl + "Course/"
AjaxMethodFunction(Url , null ,'GET',onSuccess);
function onSuccess(data)
{
    debugger;
    
    console.log(data);
    if(data !=null)
    {
      data.forEach((value,index,array)=>
      {
        var option =`<option class="select2" value = "${value.CourseId}">${value.CourseName}</option>`
        $("#myselect").append(option);
       ;
      
    });
}
}  
}


  