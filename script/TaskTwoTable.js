// Student Record Table

var sTtudentarrar = [];

    var sTtudentarrar = JSON.parse(localStorage.getItem("recordTwo"));
function leiststudent() {
    
    if (sTtudentarrar != null) {
        debugger;
        sTtudentarrar.forEach((value, index, array) => {

            var row = `<tr>
                
                <td><label id="chname">${value.names}</label><br><input id="getsname-${index}" type="text" name="name"></td>
                <td><label id="chemail">${value.emails}</label><br><input id="getemail-${index}" type="email" name="email"></td>
                <td><label id="chphone">${value.phonenumberes}</label><br> <input id="getphone-${index}" type="text" name="phone"></td>
                <td><label>${value.datee}</label><br><input type="date" id="getdob-${index}" name="dateofbirth"></td>
                <td><label id="chpassword">${value.passwordes}</label><br><input id="getpassword-${index}" type="password" name="password"></td>
                <td><label id="chconpassword">${value.confirmpasswordes}</label><br><input id="getconfirmpassword-${index}" type="password" name="confirmpassword"></td>
                <td><button id="edit-${index}" onclick=EditRecord(${index})>Edit</button></td>
                <td><button id="delete-${index}" onclick=deleterecord(${index})>Delete</button></td>
                <td><button class='hideBtn' id="hsave-${index}" onclick=saveRecord(${index})>Save</button></td>
               
                 </tr>`
               
            $("#myTable").append(row);
           
           
        });
       $(document).find("input").hide();
      for(i =0; i<sTtudentarrar.length;i++){
          $(`#hsave-${i}`).parent().hide();
      }
    }
    $(document).find("button #hsave").hide();
}

function EditRecord(index)
{
    debugger;
  
   $(`#edit-${index}`).parent().parent().find('input').show(); 
   $(`#edit-${index}`).parent().parent().find('label').hide(); 
   $(`#edit-${index}`).parent().hide();
   $(`#hsave-${index}`).parent().show();
   $(`#delete-${index}`).parent().hide();
   
   
   $(document).find(`#getsname-${index}`).val(sTtudentarrar[index].names);
   $(document).find(`#getemail-${index}`).val(sTtudentarrar[index].emails);
   $(document).find(`#getphone-${index}`).val(sTtudentarrar[index].phonenumberes);
   $(document).find(`#getdob-${index}`).val(sTtudentarrar[index].datee);

   $(document).find(`#getpassword-${index}`).val(sTtudentarrar[index].passwordes);
   $(document).find(`#getconfirmpassword-${index}`).val(sTtudentarrar[index].confirmpasswordes);

   
  

    
  
}
function saveRecord(index)
 {
     debugger;
    var name =   $(document).find(`#getsname-${index}`).val();
    var email =  $(document).find(`#getemail-${index}`).val();
    var phonenumber = $(document).find(`#getphone-${index}`).val();

    var gdate = $(document).find(`#getdob-${index}`).val();
    var cdate = gdate.toString();
    var password =  $(document).find(`#getpassword-${index}`).val();
    var confirmpassword = $(document).find(`#getconfirmpassword-${index}`).val();
    var checkinput = inputfieldvalidate(name, email, phonenumber, password, confirmpassword);
    $(`#hsave-${index}`).parent().parent().find('label').show(); 
    if(checkinput)
    {
        sTtudentarrar[index].names=name;

        sTtudentarrar[index].emails=email;

        sTtudentarrar[index].phonenumberes=phonenumber;

        sTtudentarrar[index].datee=cdate;

        sTtudentarrar[index].passwordes=password;

        sTtudentarrar[index].confirmpasswordes=confirmpassword;
        localStorage.setItem("recordTwo", JSON.stringify(sTtudentarrar));
    
       location.reload();



    }

    
    
    
    
 }  

function deleterecord(td) {
    
    sTtudentarrar.splice(td, 1);

    localStorage.setItem('recordTwo', JSON.stringify(sTtudentarrar));
    location.reload();
    //alert(td);
}




$(document).ready(function(){
    $("#add").click(function(){
        debugger;
        var row = `<tr>
                
        <td><input id="sname" type="text" name="name"><br><label id="chname"></label></td>
        
        <td><input id="email" type="email" name="email"><br><label id="chemail"></label></td>
       
        <td> <input id="phone" type="text" name="phone"><br><label id="chphone"></label></td>
       
        <td><input type="date" id="dob" name="dateofbirth"><br><label id="chdate"></label></td>
       
        <td><input id="password" type="password" name="password"><br><label id="chpassword"></label></td>
       
        <td><input id="confirmpassword" type="password" name="confirmpassword"><br><label id="chconpassword"></label></td>
        
    
        <td><button id="save"> Save</button></td>
        
        <td><button id="cal">Cancel</button></td>
         </tr>`;
        
         $("#myTable").append(row);

       
       $("#save").click(function(){
    
       var bool= getrecordaddsave(); 
       if(bool)
       {
        location.reload();
       }
        
             });
             $("#cal").click(function(){
                
                $(this).closest('tr').remove(); 
                return false;
                     });
    });

       
   
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
        var starray = [];
        var getstudent = JSON.parse(localStorage.getItem("recordTwo"));
        if (getstudent !== null) {
            starray = getstudent;
        }
        var student = {
            names: name,
            emails: email,
            phonenumberes: phonenumber,
            datee: cdate,
            passwordes: password,
            confirmpasswordes: confirmpassword
    
        };
        starray.push(student);
        localStorage.setItem("recordTwo", JSON.stringify(starray));


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

  

  

  

  