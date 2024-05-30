## **The Problem:**

  Production line processes following objects: points (a very small objects), circles, rectangles and squares that have certain position and size.

  1. Design a text file format to collect the objects from the production line
     - create a example of the text with all object types

  2. Design SQL database structure to store the data
     - If you have a SQL DB available locally, create the database. If not, describe the database structure in a text file.
     - use data access components of your choice

  3. Implement code that:
    a. reads the data objects from the database 
       - if real database is not available, implement a code that would pretend reading the data.

    b. write code that displays the stored objects in their original positions by calling the Screen class below (do not implement the methods inside of Screen class)

      class Screen
      {
         DrawLine(int x1, int y1, int x2, int y2);
         DrawCircle(int x, int y, int radius);
         DrawPoint(int x, int y);
      }
      
    c. write code that moves all the objects in provided direction x,y provided as parameters

  4. List test cases to automate the functionality
     - code one test for one test case of your choice (skeleton is fine)

  Note: If you would find multiple ways how to interpret the business requirements write them all down and explain why you chose the one that you implement.

## **The Solution: Important tips and notes:**

- **Clone** this repository in your local repo folder then **Open** solution then **Rebuild** solution to restore **Nuget** packages.
- The *WebAPI* application uses *SQL Server* to store theObjects.
    - If you are an Administrator and also have a local *SQL Server* instance, then execute the console App named: *theObjects.Production.Creator*. This will create the database in your server and will add some entries to start working with.
    - If the above has any issues, you also have a sql script in the *Docs* folder of the solution, to manually create the database.
    - Please note that the following projects have the connection string value in the *appsettings.json* file: *theObjects.Production.Creator* and *theObjects.WebAPI*.
- Before launching the website check the *WebAPI* application is running in yout *IIS Express*.
    - We recommend to open a new instance of *Visual Studio 2022 Community Edition* and set *theObjects.WebAPI* as starting project, then run the project. Keep the VS instance opened to run your test app and/or website. A *Swagger* page with all the API's endpoints will be visible. 
- Open the website project: *theObjects.Website* in a different *Visual Studio 2022 Community Edition* instance, login and password to access the website are: 
    - **login**: admin 
    - **password**: 1theobjects23
- Before logging into the website, check that security is working by clicking on any of the menu links in the login page.
- The website generates TXT docs for single objects and for all objects as well.
- *Web UI* for drawing and movinng objects is only implemented for *Point* objects. All the other object's same functionalities are implemented and can be tested using the app console provided for testing: *theObjects.Production.Tester*.
- *JS* validators located at *Insertion/Movement* page just show a red box if empty or invalid values.
