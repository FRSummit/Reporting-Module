# These variables should be set via the Octopus web portal:
#
#   ServiceName         - Name of the Windows service
#   ServiceExecutable   - Path to the .exe containing the service
# 
# sc.exe is the Service Control utility in Windows
  
$service = Get-Service $ServiceName -ErrorAction SilentlyContinue

if ($service)
{
    Write-Host "Starting the service"
    Start-Service $ServiceName
}
