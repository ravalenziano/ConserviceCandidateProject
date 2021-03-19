:::Project Requirements:::

HR department requires the ability to do the following items:   
    ●   Ability to view all team members on a single page.
    ●   Add a new team member as they are hired, delete a team member record when needed, and mark a team member as terminated.
    ●   Edit a team member’s record, i.e. address, position, department, etc.
    ●   An activity tracker that will record when a team member’s permissions change, when a team member’s manager changes, and when a team member’s position changes.
    ●   A reporting page to view recruiting, and retention efforts including:
           ○    Weekly hire numbers
           ○    Terminated numbers for the current year
    ●   In an effort to maintain the site’s security have a page to view all permission assignments for all team members.

HR has asked that the following items be included in the team member record:
    ●   Name
    ●   Address
    ●   Email Address
    ●   Preferred Contact Phone Number
    ●   Position
    ●   Department
    ●   Start Date
    ●   End Date
    ●   Employment Status
    ●   Shift
    ●   Manager
    ●   Team Member Photo
    ●   Favorite Color

Minimum Viable Product : 

Option 1: Web Application
    ●   Create a web application - this application can any .net Stack Web application (MVC, Core, Blazor) or any Javascript framework spa/project (react, angular, etc)
    ●   Use Bootstrap for UI (preferred but not required)

Option 2:  Winform  Application
    ●   Create a (.Net 4.5 +) console application

Option 3: WPF Application
    ●   Create a (.Net 4.5 +) WPF console application

For ALL options, the application should include the following:
    ●   No authentication required
    ●   Data should be stored in a SQL Database (preferred but not required to be in SQL database)
    ●   A way to view all team members in the database
    ●   Ability sort and filter employees on the all team page
    ●   Ability to search for team members by name on the all team page
    ●   The ability to add, delete, and edit team member records
    ●   A reporting page for displaying recruiting and retention metrics
    ●   A page to view the activity log of modifications made to a team member record

Nice Features, to include after you complete the MVP:
    ●   Photo upload for team member photos
    ●   Ability to create new departments/positions
    ●   A report view detailing the number of employees in each department/manager
    ●   A tree hierarchy view of the management chain throughout all employees.
    ●   A notification system that alerts certain users when changes are made within the system.


:::Setup instructions:::

1. Edit appsettings.json
   i)ConnectionStrings.DefaultConnection - Set db connection string
   ii)Emails - Set SmtpClient, Username, Password, FromEmail

2. Run Migrations
     i)In Package Manager Console change to project folder
     ii) dotnet ef database update

3. Run application

:::Location of Features:::

For ALL options, the application should include the following:

    ●   A way to view all team members in the database   
             ---> Employees tab
    ●   Ability sort and filter employees on the all team page  
             ---> Employees tab
    ●   Ability to search for team members by name on the all team page  
                ---> Employees tab
    ●   The ability to add, delete, and edit team member records   
                 ---> Employees tab i)Add New ii) Click on Row to edit
    ●   A reporting page for displaying recruiting and retention metrics  
           ○    Weekly hire numbers
           ○    Terminated numbers for the current year
                      ---> Retention Metrics tab
    ●   A page to view the activity log of modifications made to a team member record 
                  ---> Activity Log tab
   ●  Page to view/edit permission assignments. 
                    ---> Permissions tab i)Click on Row to edit

Nice Features, to include after you complete the MVP:
    ●   Photo upload for team member photos 
               ---> Employees tab, either Add New or Edit existing 
    ●   Ability to create new departments/positions 
                 --->Departments tab/Positions tab
    ●   A report view detailing the number of employees in each department/manager 
             --->Employee Count tab
    ●   A tree hierarchy view of the management chain throughout all employees. 
             --->Management Chain tab
    ●   A notification system that alerts certain users when changes are made within the system.  
               ---> Activity Log tab then Notifications subtab.