using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;

namespace SdetBootcampDay3.Exercises
{
    [TestFixture]
    public class Exercises02
    {
        private const string BASE_URL = "http://jsonplaceholder.typicode.com";

        private RestClient client;

        [OneTimeSetUp]
        public void SetupRestSharpClient()
        {
            client = new RestClient(BASE_URL);
        }

        /**
         * TODO: rewrite these three tests into a single parameterized test
         * If you're stuck, have a look at the exercises for Day 1, as we
         * did the exact same thing there (just for a unit test instead of an API test).
         * Do this either using the [TestCase] attribute, or using [TestDataSource] combined
         * with the appropriate method to create and yield the TestCaseData objects.
         */

        [Test, TestCaseSource("testNamesList")]
        public async Task GetDataForUser1_CheckName(int userNum, string userName)
        {
            RestRequest request = new RestRequest($"/users/{userNum}", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseData = JObject.Parse(response.Content!);

            Assert.That(responseData.SelectToken("name")!.ToString(), Is.EqualTo(userName));
        }

        private static IEnumerable<TestCaseData> testNamesList()
        {
            yield return new TestCaseData(1,"Leanne Graham").
                SetName("User is Leanne Graham");
            yield return new TestCaseData(2, "Ervin Howell").
                SetName("User is Ervin Howell");
            yield return new TestCaseData(3, "Clementine Bauch").
                SetName("User is Clementine Bauch");
        }
        /*
        [Test]
        public async Task GetDataForUser1_CheckName_ShouldEqualLeanneGraham()
        {
            RestRequest request = new RestRequest("/users/1", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseData = JObject.Parse(response.Content!);

            Assert.That(responseData.SelectToken("name")!.ToString(), Is.EqualTo("Leanne Graham"));
        }

        [Test]
        public async Task GetDataForUser2_CheckName_ShouldEqualErvinHowell()
        {
            RestRequest request = new RestRequest("/users/2", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseData = JObject.Parse(response.Content!);

            Assert.That(responseData.SelectToken("name")!.ToString(), Is.EqualTo("Ervin Howell"));
        }

        [Test]
        public async Task GetDataForUser3_CheckName_ShouldEqualClementineBauch()
        {
            RestRequest request = new RestRequest("/users/3", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseData = JObject.Parse(response.Content!);

            Assert.That(responseData.SelectToken("name")!.ToString(), Is.EqualTo("Clementine Bauch"));
        }
        */
    }
}
