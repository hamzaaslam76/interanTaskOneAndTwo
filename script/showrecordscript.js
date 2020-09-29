var sTtudentarrar = [];

var sTtudentarrar = JSON.parse(localStorage.getItem("record"));

// Student Record Table
function leiststudent() {
   
   


    var y = document.getElementById("myTable");
    if (sTtudentarrar != null) {
        debugger;
        sTtudentarrar.forEach((value, index, array) => {

            var row = `<tr>
                
                <td>${value.names}</td>
                <td>${value.emails}</td>
                <td>${value.phonenumberes}</td>
                <td>${value.datee}</td>
                <td>${value.passwordes}</td>
                <td><button onclick=editstudent(${index})> Edit</button></td>
                
                <td><button onclick=deleterecord(${index})>    Delete</button></td>
                 </tr>`

            y.innerHTML += row;

        });
    }

}




// Delete Record
function deleterecord(td) {
    
    sTtudentarrar.splice(td, 1);

    localStorage.setItem('record', JSON.stringify(sTtudentarrar));
    location.reload();
    //alert(td);
}

// Edit Student Index Store in Local Storage
function editstudent(val) {
    

    localStorage.setItem('editrecord', JSON.stringify(val));
    window.location.href="EditRecord.html"

}
var getindex = JSON.parse(localStorage.getItem('editrecord'));

// Set Edit Record In Field
function setRecordonFiled()
{

 document.getElementById('esname').value=sTtudentarrar[getindex].names;
 document.getElementById('eemail').value=sTtudentarrar[getindex].emails;
 document.getElementById('ephone').value=sTtudentarrar[getindex].phonenumberes;
 document.getElementById('edob').value=sTtudentarrar[getindex].datee;
 document.getElementById('epassword').value=sTtudentarrar[getindex].passwordes;
 document.getElementById('econfirmpassword').value=sTtudentarrar[getindex].confirmpasswordes;
}

// Get New Record And Stroe In Local Storage

function EditRecordStore()
{
    debugger;
    var name = document.getElementById("esname").value;
    var email = document.getElementById("eemail").value;
    var phonenumber = document.getElementById("ephone").value;

    var gdate = document.getElementById("edob").value;
    var cdate = gdate.toString();
    var password = document.getElementById("epassword").value;
    var confirmpassword = document.getElementById("econfirmpassword").value;
    var checkinput = inputfieldvalidate(name, email, phonenumber, password, confirmpassword);
    if(checkinput)
    {
        sTtudentarrar[getindex].names=name;

        sTtudentarrar[getindex].emails=email;

        sTtudentarrar[getindex].phonenumberes=phonenumber;

        sTtudentarrar[getindex].datee=cdate;

        sTtudentarrar[getindex].passwordes=password;

        sTtudentarrar[getindex].confirmpasswordes=confirmpassword;
        localStorage.setItem("record", JSON.stringify(sTtudentarrar));
        localStorage.removeItem("editrecord");
        window.location.href="showRecord.html"



    }
   


}









