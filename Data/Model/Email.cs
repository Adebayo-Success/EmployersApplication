using System;

namespace Data.Model;

public class Email
{
    public required string SmtpServer { get; set; }
    public int Port { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string FromEmail { get; set; }
}
