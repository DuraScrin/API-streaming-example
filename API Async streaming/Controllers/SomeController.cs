using API_Async_streaming.Models;
using API_Async_streaming.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Async_streaming.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomeController : ControllerBase
    {
        private readonly SomeServices someServices;
        public SomeController(SomeServices someServices)
        {
            this.someServices = someServices;
        }

        [HttpGet]
        public async IAsyncEnumerable<SomeModel> GetAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine(" - Incomming request:");
            while (!cancellationToken.IsCancellationRequested)
            {
                var result = someServices.DoSomeThing();

                Console.WriteLine(" - Returning response:");
                await Task.Delay(500);
                yield return await result;
            }
        }
    }
}
