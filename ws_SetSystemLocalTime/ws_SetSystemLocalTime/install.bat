%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\installutil.exe "%~dp0ws_SetSystemLocalTime.exe"
Net Start setSystemLocalTimeService
sc config setSystemLocalTimeService start= auto
pause