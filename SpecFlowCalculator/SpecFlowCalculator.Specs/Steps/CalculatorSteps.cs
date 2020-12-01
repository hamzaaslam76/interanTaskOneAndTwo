
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using SpecFlowCalculator.Specs.Helper;
using SpecFlowCalculator.Specs.Model;
using System;
using System.Collections.Generic;
using System.Net;
using TechTalk.SpecFlow;
using Method = RestSharp.Method;
namespace SpecFlowCalculator.Specs.Steps
{
 
    [Binding]
   
    public class CalculatorSteps
    {
        private  login _login = new login();
        private StudentDto _student = new StudentDto();
        private respocseModel _response = new respocseModel();
        IRestResponse _restResponse;
        HttpStatusCode statusCode;
        IDictionary<string, string> header = new Dictionary<string, string>();
        IDictionary<string, string> course = new Dictionary<string, string>();

        [Given(@"i input email ""(.*)""")]
        public void GivenIInputEmail(string email)
        {
            _login.username = email;
           // user.Add("username", "Hamza@gmail.com");
        }
        
        [Given(@"i input password ""(.*)""")]
        public void GivenIInputPassword(string password)
        {
            _login.password = password;
            //user.Add("password", "Hamza12@");
        }
        
        [Given(@"i input grant_type ""(.*)""")]
        public void GivenIInputGrant_Type(string granttype)
        {
            _login.grant_type = granttype;
            // user.Add("grant_type", "password");
        }
        
        [When(@"i send api call")]
        
        public void WhenISendApiCall()
        { 
            var request = new HttpRequestWrapper()
                           .SetMethod(Method.POST)
                           .SetResourse("/Login")
                           .AddLoginJsonContent(_login);
            _restResponse = new RestResponse();
            _restResponse = request.Execute();
            statusCode = _restResponse.StatusCode;
            _login = JsonConvert.DeserializeObject<login>(_restResponse.Content);

        }
        [Then(@"validateuser")]
        public void ThenValidateuser()
        {
            Assert.AreEqual(_login.token_type, "bearer");
        }
        [Given(@"i login field email password  ""(.*)"" ,""(.*)""")]
        public void GivenILoginFieldEmailPassword(string  email, string password)
        {
            _login.username = email;
            _login.password = password;
            _login.grant_type = "password";
        }
        [When(@"i send login api call")]
        public void WhenISendLoginApiCall()
        {
            var request = new HttpRequestWrapper()
                           .SetMethod(Method.POST)
                           .SetResourse("/Login")
                           .AddLoginJsonContent(_login);
            _restResponse = new RestResponse();
            _restResponse = request.Execute();
            statusCode = _restResponse.StatusCode;
            _login = JsonConvert.DeserializeObject<login>(_restResponse.Content);
        }
        [Given(@"add student field ""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)""")]
        public void GivenAddStudentField(string Studentname, string StudentEmail, string Password, string DateOfBirth, string PhoneNumber, string ConfirmPawword)
        {
            _student.StudentName = Studentname;
            _student.StudentEmail = StudentEmail;
            _student.Password = Password;
            _student.DateOfBirth = DateOfBirth;
            _student.PhoneNumber = PhoneNumber;
            _student.ConfirmPawword = ConfirmPawword;

        }

        [When(@"i send add student api call")]
        public void WhenISendAddStudentApiCall()
        {
            
            header.Add("Authorization", "Bearer " + _login.access_token );
            var request = new HttpRequestWrapper()
                              .SetMethod(Method.POST)
                              .SetResourse("api/Students/?courseID=3,4,5")
                              .AddHeaders(header)
                              .AddJsonContent(_student);
            _restResponse = new RestResponse();
            _restResponse = request.Execute();
            statusCode = _restResponse.StatusCode;

            _response.status = _restResponse.Content;
        }
        [When(@"i send Delete student api call")]
        public void WhenISendDeleteStudentApiCall()
        {
            var request = new HttpRequestWrapper()
                              .SetMethod(Method.DELETE)
                              .SetResourse("api/Students/?id=" + Int32.Parse(_response.status))
                              .AddHeaders(header);
            _restResponse = new RestResponse();
            _restResponse = request.Execute();
            statusCode = _restResponse.StatusCode;
            _response.deleteStatus = _restResponse.Content;
        }
        [Then(@"studentAddedresponse")]
        public void ThenStudentAddedresponse()
        {
            if(_response.status !=null && _response.deleteStatus == "true")
            {
                Assert.AreEqual(HttpStatusCode.OK, statusCode);
                Console.WriteLine("Student added");
            }
            else
            {
                Console.WriteLine("Student not  added");
            }
        }


    }
}
