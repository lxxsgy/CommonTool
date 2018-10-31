using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ICPSendMailRegularly.BLL
{
    public class Mails
    {
        private static ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //发件人邮箱地址

        public static bool SendMial(string MailTitle, string MailBody, string[] MailAttachment)
        {
            bool SendOK = false;
            try
            {
                string[] mailAttachment = MailAttachment;
                string []receiveAddress =ConfigurationManager.AppSettings["ReceivedAddress"].ToString().Split(';');
                //发件人邮箱地址
                string fromAddress = ConfigurationManager.AppSettings["FromAddress"].ToString();
                //发件人邮箱密码
                string passWord = ConfigurationManager.AppSettings["Password"].ToString();
                //发件服务器端口号
                int port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);
                //发件服务器地址
                string host = ConfigurationManager.AppSettings["Host"].ToString();
                //邮件内容
                string body = MailBody;
                //邮件主题
                string title = MailTitle;
                System.Net.Mail.SmtpClient SendMaillClient = new System.Net.Mail.SmtpClient();
                SendMaillClient.Port = port;
                if(!string.IsNullOrEmpty(host))
                {
                    SendMaillClient.Host = host;
                }
                SendMaillClient.EnableSsl = true;
                SendMaillClient.UseDefaultCredentials = true;
                SendMaillClient.Credentials = new System.Net.NetworkCredential(fromAddress, passWord);
                SendMaillClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
                mailMessage.From = new System.Net.Mail.MailAddress(fromAddress,fromAddress,System.Text.Encoding.GetEncoding("UTF-8"));
                mailMessage.Body = body;
                mailMessage.Subject = title;
                mailMessage.IsBodyHtml = true;
                mailMessage.Priority = System.Net.Mail.MailPriority.High;
                mailMessage.SubjectEncoding = System.Text.Encoding.GetEncoding("UTF-8");
                mailMessage.BodyEncoding = System.Text.Encoding.GetEncoding("UTF-8");
                if(mailAttachment!=null)
                {
                    for(int i = 0;i< mailAttachment.Length;i++)
                    {
                        mailMessage.Attachments.Add(new System.Net.Mail.Attachment(mailAttachment[i]));
                    }
                }
                if (receiveAddress != null)
                {
                    for (int i = 0; i < receiveAddress.Length; i++)
                    {
                        if(!string.IsNullOrEmpty(receiveAddress[i]))
                        {
                            mailMessage.To.Add(receiveAddress[i]);
                        }
                       
                    }
                }
                try
                {
                    SendMaillClient.Send(mailMessage);
                    SendOK = true;
                } catch(SmtpFailedRecipientsException ex)
                {
                    SendOK = false;
                }
               
              
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

            return SendOK;
        }

    }
}
