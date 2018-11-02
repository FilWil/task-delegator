# task-delegator

App for delegating tasks from pool between users using drag and drop. 
Communication beetween database and frontend was made using AJAX requests and REST API.

Drag and drop events were handled with use of Dragula library.

# Short instruction on how to start an app on localhost server:
App needs .NET Core SDK with at least 2.1.3 version (tested on 2.1.403)

1. Download project files from GitHub repository
2. Change connection string to database in appsettings.json (change server for existing server and provide database name)
3. Use .NET CLI to run the following commands:

   ``` dotnet ef migrations add <name_of_migration> ```
   
   ``` dotnet ef database update ```
4. Run project hosted on IIS using either VisualStudio or command:

   ```dotnet run```
   
# Screenshots:
   ![Main](https://i.imgur.com/ooOG6Qv.png "Main")
   
   
   ![RWD](https://i.imgur.com/ygd047i.png "RWD")
   
   ![Scrollable](https://i.imgur.com/X10Nnei.png "Scrollable")
   
