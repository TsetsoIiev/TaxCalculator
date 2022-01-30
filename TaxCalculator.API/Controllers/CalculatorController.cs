using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Net;
using TaxCalculator.Shared.Interfaces;
using TaxCalculator.Shared.Models;
using TaxCalculator.Shared.Validation;

namespace TaxCalculator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ITaxCalculatorService _calculatorService;
        private readonly IMemoryCache _cache;

        public CalculatorController(ITaxCalculatorService taxCalculatorService, IMemoryCache cache)
        {
            _calculatorService = taxCalculatorService;
            _cache = cache;
        }

        [HttpPost("[action]")]
        [ProducesResponseType(typeof(Taxes), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<ValidationFailure>), (int)HttpStatusCode.BadRequest)]
        public IActionResult Calculate([FromBody]TaxPayer model)
        {
            var validator = new TaxPayerValidator();
            var validationReesult = validator.Validate(model);
            if (!validationReesult.IsValid)
                return BadRequest(validationReesult.Errors);

            if (_cache.TryGetValue(model.SSN, out Taxes taxes))
            {
                return Ok(taxes);
            }

            var income = new Income(model.GrossIncome, model.CharitySpent ?? 0);
            var result = _calculatorService.CalculateTax(income);

            _cache.Set(model.SSN, result);

            return Ok(result);
        }
    }
}
