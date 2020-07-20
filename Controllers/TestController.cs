
namespace backend.Controllers
{
    using System;
    using System.Threading.Tasks;
    using backend.Commands;
    using backend.Dtos;
    using backend.Test;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [Route("test")]
    public class TestController : Controller
    {
        public TestController(IMediator mediator, ITest test)
        {
            this.Mediator = mediator;
            this.Test = test;
        }

        private IMediator Mediator { get; }

        private ITest Test { get; }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var result = await this.Mediator.Send(new TestCommand());
            return this.Ok(result);
        }

        [HttpGet("testDto/")]
        public IActionResult TestDtoGet()
        {
            Console.WriteLine("Hello");
            var x = new TestDto(){
                Val1 = 13,
                Val2 = "This is a test dto"
            };

            return this.Ok(x);
        }

        [HttpGet("testStruct/")]
        public IActionResult TestStructGet()
        {
            return this.Ok(Test.s);
        }
    }
}
