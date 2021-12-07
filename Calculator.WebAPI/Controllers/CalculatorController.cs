using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                decimal first = ConvertToDecimal(firstNumber);
                decimal second = ConvertToDecimal(secondNumber);
                var sum = first + second;
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                decimal first = ConvertToDecimal(firstNumber);
                decimal second = ConvertToDecimal(secondNumber);
                var subtraction = first - second;
                return Ok(subtraction.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                decimal first = ConvertToDecimal(firstNumber);
                decimal second = ConvertToDecimal(secondNumber);
                var multiplication = first * second;
                return Ok(multiplication.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                decimal first = ConvertToDecimal(firstNumber);
                decimal second = ConvertToDecimal(secondNumber);
                var multiplication = first / second;
                return Ok(multiplication.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public IActionResult Mean(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                decimal first = ConvertToDecimal(firstNumber);
                decimal second = ConvertToDecimal(secondNumber);
                var mean = (first + second) / 2;
                return Ok(mean.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("square-root/{number}")]
        public IActionResult SquareRoot(string number)
        {
            if (IsNumeric(number))
            {
                var squareRoot = Math.Sqrt((double)ConvertToDecimal(number));
                return Ok(squareRoot.ToString());
            }
            return BadRequest("Invalid Input");
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strNumber, 
                NumberStyles.Any, 
                NumberFormatInfo.InvariantInfo, 
                out number);
            return isNumber;
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            return Convert.ToDecimal(strNumber);
        }

    }
}
