using InvisibleFriendLibrary.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InvisibleFriendAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SmtpConfigurationController : ControllerBase{

private readonly ILogger<SmtpConfigurationController> _logger;

    public SmtpConfigurationController(ILogger<SmtpConfigurationController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetSmtpConfiguration")]
    public SmtpConfiguration Get()
    {
        var smtp = new SmtpConfiguration();
        var database = DataBase.Get();
        if (database != null && database.SmtpConfiguration != null){
            smtp = database.SmtpConfiguration;
        }
        return smtp;
    }

    [HttpPost(Name = "PostSmtpConfiguration")]
    public ActionResult Post(SmtpConfiguration smtpConfiguration)
    {
        var database = DataBase.Get();
        if (database != null){
            if (database.SmtpConfiguration == null){
                database.SmtpConfiguration = new SmtpConfiguration();
            }
            database.SmtpConfiguration = smtpConfiguration;
            database.Save();
        }
        return Ok();
    }

    [HttpPut(Name = "PutSmtpConfiguration")]
    public ActionResult Put(SmtpConfiguration smtpConfiguration)
    {
        return Post(smtpConfiguration);
    }

    [HttpDelete(Name = "DeleteSmtpConfiguration")]
    public ActionResult Delete()
    {
        var database = DataBase.Get();
        if (database != null){
            database.SmtpConfiguration = null;
            database.Save();
        }
        return Ok();
    }
    
}