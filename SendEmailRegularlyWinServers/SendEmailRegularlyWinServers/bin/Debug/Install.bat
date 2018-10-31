%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\installutil.exe "%~dp0SendEmailRegularlyWinServers.exe"
Net Start SendMailSRegularService
sc config SendMailSRegularService start= auto
pause