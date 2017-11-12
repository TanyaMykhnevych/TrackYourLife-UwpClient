namespace UwpClientApp.Data.Api
{
    public class ApiRouting
    {
        private const string ApiServiceAddress = "http://localhost:5000/";

        /* raw operations */
        public string ApiUrl => ApiServiceAddress + "api/";
    }
}
