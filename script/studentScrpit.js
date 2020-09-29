// Get Field Record And Store In Local storage 

function getrecordaddsave() {


    var name = document.getElementById("sname").value;
    var email = document.getElementById("email").value;
    var phonenumber = document.getElementById("phone").value;

    var gdate = document.getElementById("dob").value;
    var cdate = gdate.toString();
    var password = document.getElementById("password").value;
    var confirmpassword = document.getElementById("confirmpassword").value;

    var checkinput = inputfieldvalidate(name, email, phonenumber, password, confirmpassword);


    
    if (checkinput) {
        var starray = [];
        var getstudent = JSON.parse(localStorage.getItem("record"));
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
        localStorage.setItem("record", JSON.stringify(starray));


    }
    return checkinput;


}

// Data Filed Validation
function inputfieldvalidate(nam, em, pon, pass, conpass) {
    if (namedfieldcheck(nam)) {
        document.getElementById("chname").innerHTML = "";

    } else {
        document.getElementById("chname").innerHTML = "Please inter correct name";
        return false;

    }

    if (emailFieldCheck(em)) {

        document.getElementById("chemail").innerHTML = "";
    } else {
        document.getElementById("chemail").innerHTML = "Incorrect Email";
        return false;
    }
    if (phoneFieldCheck(pon)) {
        document.getElementById("chphone").innerHTML = "";

    } else {
        document.getElementById("chphone").innerHTML = "Invalid Number";
        return false;
    }
    if (passwordFieldCheck(pass)) {
        document.getElementById("chpassword").innerHTML = "";

    } else {
        var str = "Enter At least 8 characters,Include at least 1 lowercase letter 1 capital letter, 1 number,1 special character";
        document.getElementById("chpassword").innerHTML = str;
        return false;
    }
    if (pass === conpass) {
        document.getElementById("chconpassword").innerHTML = "";
    } else {
        document.getElementById("chconpassword").innerHTML = "Password Not Match";
        return false;
    }

    return true;
}

