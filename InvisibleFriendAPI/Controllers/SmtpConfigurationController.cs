using InvisibleFriendLibrary.Entities;
using InvisibleFriendLibrary.Services;
using Microsoft.AspNetCore.Mvc;

namespace InvisibleFriendAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SmtpConfigurationController : ControllerBase{

    private readonly ILogger<SmtpConfigurationController> _logger;
    private SmtpServices smtpService;

    public SmtpConfigurationController(ILogger<SmtpConfigurationController> logger, SmtpServices smtpService)
    {
        _logger = logger;
        this.smtpService = smtpService;
    }

    [HttpGet(Name = "GetSmtpConfiguration")]
    public SmtpConfiguration Get()
    {
        return this.smtpService.Get();
    }

    [HttpPost(Name = "PostSmtpConfiguration")]
    public ActionResult Post(SmtpConfiguration smtpConfiguration)
    {
        this.smtpService.Post(smtpConfiguration);
        return Ok();
    }

    [HttpPut(Name = "PutSmtpConfiguration")]
    public ActionResult Put(SmtpConfiguration smtpConfiguration)
    {
        this.smtpService.Put(smtpConfiguration);
        return Ok();
    }

    [HttpDelete(Name = "DeleteSmtpConfiguration")]
    public ActionResult Delete()
    {
       this.smtpService.Delete();
        return Ok();
    }
    
}