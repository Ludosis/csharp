using NUnit.Framework;
using RestSharp;
using SdetBootcampDay3.Models;
using System.Net;

namespace SdetBootcampDay3.Exercises
{
    [TestFixture]
    public class Exercises03
    {
        private const string BASE_URL = "http://jsonplaceholder.typicode.com";

        private RestClient client;

        [OneTimeSetUp]
        public void SetupRestSharpClient()
        {
            client = new RestClient(BASE_URL);
        }

        [Test]
        public async Task GetDataForUser1_CheckName_ShouldEqualLeanneGraham()
        {
            /**
             * TODO: Create and execute a new GET request to '/users/1'
             * Deserialize the response body into a new object of type UserDto
             * Verify that the Name property of the user is equal to Leanne Graham
             */
            RestRequest request = new RestRequest("/users/1", Method.Get);
            RestResponse<UserDto> response = await client.ExecuteAsync<UserDto>(request);

            UserDto user = response.Data;
            Assert.That(user.Name, Is.EqualTo("Leanne Graham"));
        }


        [Test]
        public async Task PostNewPost_CheckStatusCode_ShouldBeHttpCreated()
        {
            /** 
             * TODO: Create a new Post object with UserId = 1 and a custom Title and Body
             * Create a new POST request to '/posts', add a JSON representation of the
             * PostDto object and execute the request
             * Verify that the response status code is equal to HttpStatusCode.Created (HTTP 201).
             */

            PostDto post = new PostDto
            {
                UserId = 1,
                Title = "API Testers HATE this one weird trick!",
                Body = "Lorem ipsum..."
            };

            RestRequest request = new RestRequest("/posts", Method.Post);
            request.AddJsonBody(post);

            RestResponse response = await client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));

            // TO DO: Verify the result - partial implementation but not quite working
            RestRequest request2 = new RestRequest("/posts", Method.Get);
            RestResponse response2 = await client.ExecuteAsync(request2);
            //RestResponse<PostDto> response2 = await client.ExecuteAsync<PostDto>(request2);
            Assert.That(response2.GetContentHeaderValue("title")!.ToString(), Is.EqualTo("API Testers HATE this one weird trick!"));

        }
    }
}
