function namedfieldcheck(name) {


    return /^[a-zA-Z ]{3,30}$/.test(name);
}

function emailFieldCheck(em) {

    return /^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$/.test(em);

}

function phoneFieldCheck(pon) {
    return /^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$/.test(pon);
}

function passwordFieldCheck(pass) {
    return /^(?=.*[\d])(?=.*[A-Z])(?=.*[a-z])(?=.*[!@#$%^&*])[\w!@#$%^&*]{8,}$/.test(pass);
}
function checkdate(dat)
{
    return /^\s+$/.test(dat);
}