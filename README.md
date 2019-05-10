# UserRegistrationProject
A single page to register users and save their credentials to DB

# Install 
SQL Server 2014 Express<br/>
    - Download, System Requirements, Installation Instructions to be found at https://www.microsoft.com/en-gb/download/details.aspx?id=42299 <br/>
Visual Studio 2019 Community<br/>
    - Download from https://visualstudio.microsoft.com/vs/


# Setup
1) In you SQL Management Studio, run the SQL scripts provided.  <br/><br/>

2) Get the Server name for your Web config to link to the local DB where you ran the previous scripts<br/>
- goto the SQL Management studio, right click on the DB that has been created in previous step (UserRegistration) and click on 'Properties'<br/>
- On the left hand pane under 'Connection' grab the Server Name 'XXXSERVER NAMEXXX'<br/>
- In Visual Studio, navigate to Web Config -  Open Solution Explorer and locate this file under the UserRegistration Project.<br/>
- In Web.config, find the 'connectionStrings' under 'configuration' and replace the value for 'Data Source' with your server name XXXSERVER NAMEXXX'.<br/>
