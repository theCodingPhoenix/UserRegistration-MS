# UserRegistrationProject
A single page to register users and save their credentials to DB.<br/>
Project uses TSQL, ASP .NET MVC 5, C#

# Installation
Visual Studio 2019 Community Edition<br/>
    - Download from https://visualstudio.microsoft.com/vs/ <br/>
SQL Server 2014 Express<br/>
    - Download, System Requirements, Installation Instructions to be found at https://www.microsoft.com/en-gb/download/details.aspx?id=42299 

# Setup
1) Clone this repo using the link provided and open up the project in Visual Studio.<br/><br/>

2) In your SQL Management Studio, run the SQL scripts provided in UserRegistration DB Script.txt. <br/>
- Search the FILENAME and replace XXXYour Local DB PathXXX with your local db path for SQL Server <br/><br/>

3) Get the Server name for your Web config to link to the local DB where you ran the previous scripts<br/>
- Goto the SQL Management studio, right click on the DB that has been created in previous step (UserRegistration) and click on 'Properties'<br/>
- On the left hand pane under 'Connection' grab the Server Name 'XXXSERVER NAMEXXX'<br/>
- In Visual Studio, navigate to Web Config -  Open Solution Explorer and locate this file under the UserRegistration Project.<br/>
- In Web.config, find the 'connectionStrings' under 'configuration' and replace the value for 'Data Source' with your server name XXXSERVER NAMEXXX'.<br/>


# Limitations
- At the moment DB script is a text file within the project, this could be added to its own source control in order to avoid hassle of having to transfer the changes to the text file<br/>
- Support for unit testing pending and more test cases can be added to validate passwords / duplicate emails.
