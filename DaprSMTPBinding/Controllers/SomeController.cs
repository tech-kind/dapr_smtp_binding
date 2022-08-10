namespace DaprSMTPBinding.Controllers
{
    [ApiController]
    [Route("")]
    public class SomeController : ControllerBase
    {
        private readonly ILogger<SomeController> _logger;

        public SomeController(ILogger<SomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost("/action")]
        public async ValueTask<ActionResult> Action([FromServices] DaprClient daprClient)
        {
            _logger.LogInformation("Action executed!!!");

            var body = EmailUtils.CreateEmailBody();
            var metadata = new Dictionary<string, string>
            {
                ["emailFrom"] = "noreply@example.com",
                ["emailTo"] = "hoge@example.com",
                ["subject"] = "テストメールです！"
            };

            await daprClient.InvokeBindingAsync("sendmail", "create", body, metadata);
            return Ok();
        }
    }
}
