using Message.Interfaces;
using Message.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Message.Controllers;

[ApiController]
[Route("MessageService/[controller]")]
public class MessageController : ControllerBase
{
    private readonly ISendMailService sendMailService;

    public MessageController(ISendMailService sendMailService)
    {
        this.sendMailService = sendMailService;
    }

    [HttpPost]
    [Route("SmsPhoneOtp")]
    public async Task<ActionResult> SmsOtpToPhoneAsync(SmsOtpViewModel viewModel)
    {
        var message = await MessageResource.CreateAsync(
            to: new PhoneNumber(viewModel.ToPhone),
            from: new PhoneNumber("+12768811643"),
            body: @$"Mã Otp của bạn là : {viewModel.Otp}, Không chia sẻ mã này cho bất cứ ai (Otp sẽ hết hạn sau 60s)"
        );
        Console.WriteLine(message.Uri);
        return this.Ok($"Gửi tin nhắn tới số {viewModel.ToPhone}");
    }

    [HttpPost]
    [Route("SendMail")]
    public async Task<ActionResult> SendMailAsync()
    {
        await sendMailService.SendEmailAsync("quang.bv205401@sis.hust.edu.vn", "Bùi Việt Quang", "Yêu Tạ Phương Yến");

        return this.Ok($"Đã gửi email tới zzzquangzzzthuzzz@gmail.com");
    }
}
