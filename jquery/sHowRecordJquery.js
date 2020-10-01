
 var sTtudentarrar = [];

 var sTtudentarrar = JSON.parse(localStorage.getItem("recordJquery"));

// Student record show in table 

function leiststudent() {
   
   

    
    if (sTtudentarrar != null) {
        debugger;
        sTtudentarrar.forEach((value, index, array) => {

            var row = `<tr>
                <td>${index}</td>
                <td>${value.names}</td>
                <td>${value.emails}</td>
                <td>${value.phonenumberes}</td>
                <td>${value.datee}</td>
                <td>${value.passwordes}</td>
                <td><button onclick=editstudent(${index})> Edit</button></td>
                
                <td><button onclick=deleterecord(${index})>    Delete</button></td>
                 </tr>`

           $("#myTable").append(row);

        });
    }

}

//Delete student record in localstorage 

function deleterecord(td) {
    
    sTtudentarrar.splice(td, 1);

    localStorage.setItem('recordJquery', JSON.stringify(sTtudentarrar));
    location.reload();
    //alert(td);
}



// Edit Student Index Store in Local Storage
function editstudent(val) {
    
debugger;
    localStorage.setItem('editrecord', JSON.stringify(val));
    window.location.href="EditRecord.html"

}
var getindex = JSON.parse(localStorage.getItem('editrecord'));

//Edit record  set in input filed 

function setRecordonFiled()
{
    

 $('#esname').val(sTtudentarrar[getindex].names);
 $('#eemail').val(sTtudentarrar[getindex].emails);
 $('#ephone').val(sTtudentarrar[getindex].phonenumberes);
 $('#edob').val(sTtudentarrar[getindex].datee);
 $('#epassword').val(sTtudentarrar[getindex].passwordes);
 $('#econfirmpassword').val(sTtudentarrar[getindex].confirmpasswordes);
}

// Edit record store in database and Show in table form 
$(document).ready(function(){
    $("#btn").click(function(){
        debugger;
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
            sTtudentarrar[getindex].names=name;
    
            sTtudentarrar[getindex].emails=email;
    
            sTtudentarrar[getindex].phonenumberes=phonenumber;
    
            sTtudentarrar[getindex].datee=cdate;
    
            sTtudentarrar[getindex].passwordes=password;
    
            sTtudentarrar[getindex].confirmpasswordes=confirmpassword;
            localStorage.setItem("recordJquery", JSON.stringify(sTtudentarrar));
            localStorage.removeItem("editrecord");
            window.location.href="showRecord.html"
    
    
    
        }
    });
  });



