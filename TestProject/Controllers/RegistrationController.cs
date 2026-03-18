using Microsoft.AspNetCore.Mvc;
using TestProject.DTOs;
using TestProject.Interfaces;

namespace TestProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _service;
        public RegistrationController(IRegistrationService service) => _service = service;

        [HttpGet("status/{ic}")]
        public async Task<IActionResult> CheckStatus(string ic)
        {
            var result = await _service.GetUserStatus(ic);
            return Ok(new { success = true, data = result });
        }
        [HttpPost("register-details")]
        public async Task<IActionResult> Step1(Step1Request req)
        {
            var userId = await _service.ProcessStep1(req);
            return Ok(new { success = true, message = "Personal details saved successfully.", data = new { userId = userId } });
        }

        [HttpPost("generate-otp")]
        public async Task<IActionResult> RequestOtp(string ic, string type)
        {
            var otp = await _service.GenerateMockOtp(ic, type);
            return Ok(new { success = true, message = $"OTP generated successfully for {type}.", data = new { mockOtp = otp } });
        }

        [HttpPost("verify-otp")]
        public async Task<IActionResult> Verify(VerifyOtpRequest req)
        {
            await _service.ValidateOtp(req);
            return Ok(new { success = true, message = "OTP verified successfully." });
        }

        [HttpPost("finalize-registration")]
        public async Task<IActionResult> Finalize(PinRequest req)
        {
            await _service.CompleteRegistration(req);
            return Ok(new { success = true, message = "Registration completed successfully. You can now login." });
        }
    }
}