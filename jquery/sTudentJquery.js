$('#form').submit(function() {
   
    
    return getrecordaddsave();
        
    
});


//Get Record function 

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
        var getstudent = JSON.parse(localStorage.getItem("recordJquery"));
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
        localStorage.setItem("recordJquery", JSON.stringify(starray));


    }
    return checkinput;


}

//Input  Field validation function 

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



