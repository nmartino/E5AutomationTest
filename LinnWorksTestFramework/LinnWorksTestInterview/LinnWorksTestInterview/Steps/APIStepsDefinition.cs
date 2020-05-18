using LinnWorksTestInterview.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RestSharp;
using RestSharp.Serialization.Json;
using Dynamitey.DynamicObjects;
using Newtonsoft.Json.Linq;

namespace LinnWorksTestInterview.Steps
{
    [Binding]

    class APIStepsDefinition
    {
        [Given(@"the user tries to log in with wrong input")]
        public void TheUserTriesToLogInWithWrongInput()
        {
            var client = new RestClient("http://localhost:59509/");
            var request = new RestRequest("/api/Auth/Login", Method.POST);
            var response = client.Execute(request);
            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            var result = output[""];
            result.Should().Contain("The input was not valid.");
        }

        [Given(@"the user tries to log in with correct input and wrong token '(.*)'")]
        public void GivenTheUserTriesToLogInWithCorrectInputAndWrongToken(string token)
        {
            var client = new RestClient("http://localhost:59509/");
            var request = new RestRequest("/api/Auth/Login", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new { token = token });
            var response = client.Execute(request);
            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            var result = output["login_failure"];
            result.Should().Contain("Invalid token.");

        }

        [Given(@"the user tries to log in with correct input and correct token '(.*)'")]
        public void GivenTheUserTriesToLogInWithCorrectInputAndCorrectToken(string token)
        {
            var client = new RestClient("http://localhost:59509/");
            var requestPost = new RestRequest("/api/Auth/Login", Method.POST);
            requestPost.RequestFormat = DataFormat.Json;
            requestPost.AddJsonBody(new { token = token });
            var requestGet = new RestRequest("/api/Category/Index", Method.GET);
            requestGet.AddHeader("accept", "application/json");
            var response = client.Execute(requestGet);
            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            var result = output["stock"];
            //result.Should().Contain("Invalid token.");
        }
    }
}
