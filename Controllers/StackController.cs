using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace StackCalculator20200608.Controllers
{
    [ApiController]
    public class StackController : ControllerBase

    {
        private static Stack<decimal> stack = new Stack<decimal>();

        [HttpGet]
        [Route("api/Test")]
        public string Test()
        {
            return "Success";
        }

        [HttpPost]
        [Route("api/Push")]
        public IActionResult Push([FromBody]decimal number)
        {
            if (stack.Count >= 10)
            {
                return new BadRequestObjectResult("there can't be more than 10 elements in the stack");
            }
            else
            {
                stack.Push(number);
                return new OkObjectResult("Success");
            }
        }

        [HttpPost]
        [Route("api/PushQuery")]
        public IActionResult PushQuery(string num)
        {
            if (stack.Count >= 10)
            {
                return new BadRequestObjectResult("there can't be more than 10 elements in the stack");
            }
            else
            {
                if (decimal.TryParse(num, out decimal number))
                {
                    stack.Push(number);
                    return new OkObjectResult("Success");
                }
                else
                {
                    return new BadRequestObjectResult("Enter a valid number");
                }
            }
        }

        [HttpPost]
        [Route("api/Print")]
        public IActionResult Print()
        {
            if (stack.Count > 0)
            {
                return new OkObjectResult(stack.Peek().ToString());
            }
            else
            {
                return new BadRequestObjectResult("there is no values in the Stack");
            }
        }

        [HttpPost]
        [Route("api/Pop")]
        public IActionResult Pop()
        {
            if (stack.Count >= 1)
            {
                stack.Pop();
                return new OkObjectResult("Success");
            }
            else
            {
                return new BadRequestObjectResult("You need at least 1 value in the stack to perform this operation");
            }
        }

        [HttpPost]
        [Route("api/Add")]
        public IActionResult Add()
        {
            if (stack.Count >= 2)
            {
                stack.Push(stack.Pop() + stack.Pop());
                return new OkObjectResult("Success");
            }
            else
            {
                return new BadRequestObjectResult("You need at least 2 values in the stack to perform this operation");
            }
        }

        [HttpPost]
        [Route("api/Subtract")]
        public IActionResult Subtract()
        {
            if (stack.Count >= 2)
            {
                decimal number1 = stack.Pop();
                decimal number2 = stack.Pop();
                stack.Push((number2) - (number1));
                return new OkObjectResult("Success");
            }
            else
            {
                return new BadRequestObjectResult("You need at least 2 values in the stack to perform this operation");
            }
        }

        [HttpPost]
        [Route("api/Multiply")]
        public IActionResult Multiply()
        {
            if (stack.Count >= 2)
            {
                stack.Push((stack.Pop()) * (stack.Pop()));
                return new OkObjectResult("Success");
            }
            else
            {
                return new BadRequestObjectResult("You need at least 2 values in the stack to perform this operation");
            }
        }

        [HttpPost]
        [Route("api/Divide")]
        public IActionResult Divide()
        {
            if (stack.Count >= 2)
            {
                decimal number1 = stack.Pop();
                decimal number2 = stack.Pop();

                if (number1 != 0)
                {
                    stack.Push((number2) / (number1));
                    return new OkObjectResult("Success");
                }
                else
                {
                    stack.Push(number2);
                    stack.Push(number1);
                    return new BadRequestObjectResult("Can't Divide by 0");
                }
            }
            else
            {
                return new BadRequestObjectResult("You need at least 2 values in the stack to perform this operation");
            }
        }
    }
}