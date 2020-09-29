# Introduction 


# Getting Started
# Build and Test

IMP: All installs would be 64-bit default

1. Installing SQL Server [latest] Developer

2. Install Raven db from https://ravendb.net/download/  On the Other downloads section select Product - server, Branch – stable, version – 3.5.6 and download installer. During installation select Developer installation and as Service.

Once installed Open http://localhost:8080 and if this loads we are good.

3. Install latest versions of the following. (Default install source: Google and download. Easy)
	a. Visual Studio Code
4. NodeJS: (https://nodejs.org/en/download) v.6.11.3
5. Install Git (https://git-scm.com/downloads)
During install, when prompted: Choose your preferred editor (hint: VS Code). Use Git from windows command prompt. Choose OpenSSL library. Checkout Windows style, commit unix style. Use windows default console window. Enable file system caching + Git credential manager.
	i. Source Tree: UI for Git (https://www.sourcetreeapp.com)
6. NServiceBus
	i. Also install latest versions of ServiceControl and ServicePulse (by Particular Software), or get latest installer from particular website https://particular.net/downloads
	ii. ServiceControl setup:
		1. Add New instance (on startup), with all default settings, except 
			a. Transport: MSMQ
			b. Audit Forwarding: On
7. Turn Windows Features On
Control Panel > Programs and Features > Turn Windows Features On (link on left)
We need ASP .NET 4.7 and MSMQ Server

8. Utilities:
	a. Launchy – install in “Normal” mode when asked.
	b. 7zip
	c. ConEmu (useful tabbed command window)
	d. Notepad++
	e. Postman

9. Paket Restore
In File Explorer, show hidden folders
Go to hidden folder .paket and run paket restore
10. Build solution in Visual Studio (hope everything builds by now)

11. Configure flyway
Download flyway https://flywaydb.org/documentation/commandline/
 and install
Make sure, in Sql Server Configuration manager(C:\Windows\SysWOW64\SQLServerManager14.msc):
	a. Under SQL Server Services, make sure SQL Server Browser is running
	b. Under Sql Server Network Config > Protocols for MSSQL, make sure TCP/IP (surely) and Named pipes (maybe needed) is Enabled 
			(if you had to enable, Sql Server main service will need to be restarted)
			 
From ~\flyway\libs\x64, copy ntlmauth.dll to Java’s bin directory: 
		C:\Program Files\Java\jre1.x.x_y\bin
		
		Note:
		If Java/Jre is missing install it 
		Setup Environment variables (PC > Properties > Advanced system settings > Advanced (tab) > Environment Variables)
		 
		Make sure your Java_Home or Java environment variable is pointing to right java folder. Like C:\Program Files\Java\jdk1.8.0_172 or where ever it is located

12. Launchy
Download Launchy https://www.launchy.net/download.php and install
Configure Launchy settings
Open Launchy (Alt + space)
Click Settings (*) icon > Catalog (tab)
Under Directories, Add (+):    <your git repo>\Launchy
	a. For this path, on the right, Click (+) under File Types and add *.bat
Hit “Rescan Catalog” at the bottom

Alt Space will give you option to start the applications (Server and the Api)


# Contribute
Git 

Create a fork from https://dev.azure.com/khanshahed/ReportingModule/_git/ReportingModule.UI

A. Name it with your initial
https://dev.azure.com/khanshahed/ReportingModule/_git/ReportingModule.UI.[[userid]]
E.g. https://dev.azure.com/khanshahed/ReportingModule/_git/ReportingModule.UI.skhan

B. Once this is done, clone the repo to your machine e.g.,
	1. create a folder c:\ReportingModule.UI
	2. cd c:\ReportingModule.UI
	3. "git clone https://dev.azure.com/khanshahed/ReportingModule/_git/ReportingModule.UI.skhan ." (replace with your [userid] when you forked the repo and please note the space dot (.) after the [userid])
	4. add original ReportingModule.UI as upstream by running this command -git remote add upstream https://khanshahed@dev.azure.com/khanshahed/ReportingModule/_git/ReportingModule.UI
	
	5. now if you run command - git remote -v - you should see two remotes with your [userid]
	For example
	origin https://dev.azure.com/khanshahed/ReportingModule/_git/ReportingModule.UI.skhan (fetch)origin https://dev.azure.com/khanshahed/ReportingModule/_git/ReportingModule.UI.skhan (push)upstream https://khanshahed@dev.azure.com/khanshahed/ReportingModule/_git/ReportingModule.UI (fetch)upstream https://khanshahed@dev.azure.com/khanshahed/ReportingModule/_git/ReportingModule.UI (push)
	
	Once you have this, you are all set to go
	
	
Workflow
	1. Checkout master - git checkout master
	2. create a branch for your ticket e.g. git checkout -b rm-ticket01
	3. Make your changes. commit.
	4. now push to origin4.1 first time - git push -u origin rm-ticket014.2 subsequent - git push origin
	5. Create pull request by going to your repository - VSTS will show you a message to create a pull request - e.g. https://khanshahed@dev.azure.com/khanshahed/ReportingModule/_git/ReportingModule.UI.<userid></userid>
	6. Once pull request is done, sync your repo' master branch6.1 git checkout master6.2 git fetch upstream master6.3 git rebase upstream/master6.4 git push origin6.5 finally delete your branch - git branch -d rm-ticket01
go to step 1 and start over

Debugging NSBServer.ReportingModule in Visual Studio
Configure external progam (NServiceBus.Host.exe).

1. Right click the NsbServer.ReportingModule project
2. Click properties
3. Select the Debug tab
4. On the Debug tab choose "Select external Program" radio button and point to the output folder to locate NServiceBus.Host.exe 
example C:\ReportingModule.Api.skhan\Output\NsbServer.ReportingModule\NServiceBus.Host.exe
Note the path will be as per your setup and installation.
