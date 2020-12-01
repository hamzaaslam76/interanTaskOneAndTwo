using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using SpecFlowCalculator.Specs.Helper;
using SpecFlowCalculator.Specs.Model;
using System;
using System.Collections.Generic;
using System.Net;
using TechTalk.SpecFlow;

namespace SpecFlowCalculator.Specs.Steps
{
    [Binding]
    public class UpdateStudentSteps
    {
        private login _login = new login();
        private StudentDto _student = new StudentDto();
        IRestResponse _restResponse;
        HttpStatusCode statusCode;
        private respocseModel _response = new respocseModel();
        IDictionary<string, string> header = new Dictionary<string, string>();
        [Given(@"i Enter Email and Password ""(.*)"",""(.*)""")]
        public void GivenIEnterEmailAndPassword(string email, string password)
        {
            _login.username = email;
            _login.password = password;
            _login.grant_type = "password";
        }
        
        [Given(@"i Enter Update student id (.*)")]
        public void GivenIEnterUpdateStudentId(int id)
        {
            _login.id = id;



        }
        
        [When(@"i send login Api call")]
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
        [When(@"i send get update student Api call")]
        public void WhenISendGetUpdateStudentApiCall()
        {
            header.Add("Authorization", "Bearer " + _login.access_token);
            var request = new HttpRequestWrapper()
                           .SetMethod(Method.GET)
                           .SetResourse("api/Students/?id=1129")
                           .AddHeaders(header);
            _restResponse = new RestResponse();
            _restResponse = request.Execute();
            statusCode = _restResponse.StatusCode;
            _student = JsonConvert.DeserializeObject<StudentDto>(_restResponse.Content);
        }

        [When(@"i send update Api call")]
        public void WhenISendUpdateApiCall()
        {
            _student.StudentName = "Arslan";
            _student.StudentEmail = "Arslan@gmail.com";
            _student.Password = "Arslan12@";
            _student.ConfirmPawword = "Arslan12@";
            _student.PhoneNumber = "211212";
            _student.DateOfBirth = "12/1/2020";


            var request = new HttpRequestWrapper()
                              .SetMethod(Method.PUT)
                              .SetResourse("api/Students/?courseID=1,2")
                              .AddHeaders(header)
                              .AddJsonContent(_student);
            _restResponse = new RestResponse();
            _restResponse = request.Execute();
            statusCode = _restResponse.StatusCode;

            _response.status = _restResponse.Content;
        }
        
        [Then(@"check record update response")]
        public void ThenCheckRecordUpdateResponse()
        {
            Assert.AreEqual(HttpStatusCode.OK, statusCode);
        }
    }
}
