﻿ //Get Student Record And save Method
$(document).ready(function () {
    $("#btn").click(function () {

        var name = $("#sname").val();
        var email = $("#email").val();
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
            };
            var Url ="/Student/AddStudentInDtabase";
            var ar = selectco.toString();
            AjaxMethodFunction(Url +"/?courseId="+ar , student, 'post', onSuccess);
            function onSuccess(data) {
                if (data) {
                    location.reload();
                }
            }
        }
        return checkinput;
    });
});

// Update Student Record
$(document).ready(function () {
    $("#ebtn").click(function () {
        var id = $(this).val();
        var name = $("#esname").val();
        var email = $("#eemail").val();
        var phonenumber = $("#ephone").val();
        var Editselect = $("#myselect").val();
        var gdate = $("#edate").val();
        var cdate = gdate.toString();
        var password = $("#epassword").val();
        var confirmpassword = $("#econfirmpassword").val();
        var checkinput = inputfieldvalidate(name, email, phonenumber, password, confirmpassword);
        if (checkinput) {

            var student = {
                StudentId: id,
                Studentname: name,
                StudentEmail: email,
                PhoneNumber: phonenumber,
                DateOfBirth: cdate,
                Password: password,
                ConfirmPawword: confirmpassword,
            };
            var strarray = Editselect.toString();
            var Url = "/Student/UpdateStudent";
            
            AjaxMethodFunction(Url + "?courseId=" + strarray, student, 'put', onSuccess);
            function onSuccess(data) {
                if (data == true) {
                    window.location.href = "/Student/Index";
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
        $("#chname").text(Constants.nameError);
        return false;
    }
    if (emailFieldCheck(em)) {

        $("#chemail").text("");
    } else {
        $("#chemail").text(Constants.nameError);
        return false;
    }
    if (phoneFieldCheck(pon)) {
        $("#chphone").text("");

    } else {
        $("#chphone").text(Constants.phoneError);
        return false;
    }
    if (passwordFieldCheck(pass)) {
        $("#chpassword").text("");

    } else {
    
        $("#chpassword").text(Constants.passwordError);
        return false;
    }
    if (pass === conpass) {
        $("#chconpassword").text("");
    } else {
        $("#chconpassword").text(Constants.confirmPasswordError);
        return false;
    }

    return true;
}