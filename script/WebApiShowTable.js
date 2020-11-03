var BaseUrl="http://localhost:54401//api/";
function GetRecordFromWebApi()
{
    $("#myTable").DataTable({

        "processing": true,
        "serverSide": true,
        "filter": false,
        "orderMulti": false,
         
        "ajax": {
        "url": "http://localhost:54401/api/Students",
        "type": "post",
        "datatype": "json",
        "headers":{
             'Authorization': 'Bearer ' + sessionStorage.getItem('accessToken')
          }, 
        },
         "columns": [
    {
        "autoWidth": true, "render": function (Id, type, full, meta) {

            return `${full.StudentId}`
        }
    },
    {
         "autoWidth": true, "render": function (Id, type, full, meta) {
            return `${full.Studentname}`
        }
    },

    {
        "autoWidth": true, "render": function (Id, type, full, meta) {
            return `${full.StudentEmail}`
        }
    },
    {
        "autoWith": true, "render": function (Id, type, full, meta) {
            return `${full.PhoneNumber}`

        }
    },
    {
        "autoWith": true, "render": function (Id, type, full, meta) {
            return `${full.DateOfBirth}`

        }
    },
    {
        "autoWith": true, "render": function (Id, type, full, meta) {
            return `${full.Password}`

        }
    },
    {
        "autoWith": true, "render": function (Id, type, full, meta) {
            return `${full.StudentCourseCount}`

        }
    },
    {

        "autoWith": true, "render": function (Id, type, full, meta) {
            return `<button  class="editBtn btn btn-primary glyphicon glyphicon-edit" onclick=editstudent(${full.StudentId})> Edit</button>`

        }
    },
    {

        "autoWith": true, "render": function (Id, type, full, meta) {
            return `<button class="deleteBtn glyphicon btn btn-danger glyphicon-remove"  onclick=deleterecord(${full.StudentId})>Delete</button>`

        }
    },
]
    });
}

// without datatable show record 
//Student List Show Method
// function GetRecordFromWebApi()
// {
//     debugger;
//   var Url = BaseUrl + "Students/"
// AjaxMethodFunction(Url,null,'GET',onSuccess);

// function onSuccess(data) {
    
    
//     if (data != null) {
//         debugger;
//         data.forEach((value, index, array) => {

//             var row = `<tr>
//                 <td>${value.studentDto.StudentId}</td>
//                 <td>${value.studentDto.Studentname}</td>
//                 <td>${value.studentDto.StudentEmail}</td>
//                 <td>${value.studentDto.PhoneNumber}</td>
//                 <td>${value.studentDto.DateOfBirth}</td>
//                 <td>${value.studentDto.Password}</td>
//                 <td>${value.StudentCourseCount}</td>
              
//                 <td><button onclick=editstudent(${value.studentDto.StudentId})> Edit</button></td>
                
//                 <td><button onclick=deleterecord(${value.studentDto.StudentId})>    Delete</button></td>
//                  </tr>`

//            $("#myTable").append(row);

//         });
//     }   
// }
// }

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
    debugger;
    var Url =BaseUrl + "Students/" + EditId;   
    AjaxMethodFunction(Url ,null,'GET',onSuccess);
    function onSuccess(data) {
        $('#esname').val(data.Studentname);
        $('#eemail').val(data.StudentEmail);
        $('#ephone').val(data.PhoneNumber);
        $('#edate').val(data.DateOfBirth);
        $('#epassword').val(data.Password);
        $('#econfirmpassword').val(data.ConfirmPawword);
        //$("#image").attr("src",data.ImageUrl);
        $("#image").attr("src",data.ThumbnailUrl);
        data.StudentCourses.forEach(function(value,index,array)
        {
            $('.select2').each(function(){
                if(value.CourseId == $(this).val())
                {
                $(this).prop("selected",value.CourseId == $(this).val());
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
               UserId:null,
               ImageUrl:$('#getUrl').val(),
               ThumbnailUrl:$('#ThumbnailUrl').val()
        
            };
            var strarray = Editselect.toString();
            var Url = BaseUrl + "Students/";
             debugger;
             AjaxMethodFunction(Url + "?courseID=" + strarray, student , 'PUT', onSuccess);
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
                UserId:null,
                ImageUrl:$('#getUrl').val(),
                ThumbnailUrl:$('#getThumbnailUrl').val()
            };
            debugger;
            var Url = BaseUrl + "Students/"; 
            var ar = selectco.toString();
            AjaxMethodFunction(Url+"?courseID="+ ar , student , 'POST', onSuccess);
            function onSuccess(data)
            {
               debugger;
               if(data)
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
    if(data !=null)
    {
      data.forEach((value,index,array)=>
      {
        var option =`<option class="select2" value = "${value.CourseId}">${value.CourseName}</option>`
        $("#myselect").append(option);
    });
}
}  
}
function readURL(input) {
    if (input.files && input.files[0]) {
       var data=new FormData();
       var imageuploard=$("#chose").get(0).files;
       if(imageuploard.length>0)
       {
        data.append("Imagepathsave",imageuploard[0]);
       }
      $.ajax({
        type:"post",
        url:"http://localhost:54401/api/ImagePathSave/",
        contentType:false,
        processData:false,
        data:data,
        success:function(data)
        {
            debugger;
            $('#getUrl').val(data.Path);
            $('#getThumbnailUrl').val(data.thumbnailPath);
            $("#image").attr("src",data.thumbnailPath);
            
        },
        error: function() {
            alert("Ajax Fail");
          }
      });
     
    }
}



  