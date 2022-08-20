using API_Async_streaming.Models;

namespace API_Async_streaming.Services
{
    public class SomeServices
    {
        private static int counter = 0;

        public async Task<SomeModel> DoSomeThing()
        {
            Console.WriteLine("SomeServices.DoSomeThing method being executed...");

            SomeModel someModel = new();
            someModel.Counter++;
            someModel.StaticCounter = ++counter;

            await Task.Delay(1000);
            return someModel;
        }
    }
}
