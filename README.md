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

## **Important tips and notes:**



- **Clone** this repository in your local repo folder then **Open** solution then **Rebuild** solution to restore **Nuget** packages.
- Before launching the website check the *WebAPI* application is running in yout *IIS Express*.
- The *WebAPI* application uses *SQLite* to store the theObjects products.
- Login and password to access the website are: 
    - **login**: admin 
    - **password**: 1theObjects23
- Before logging into the website, check that security is working by clicking on any of the menu links in the login page.
- An online working version of both, the website and *WebAPI* service are available here:
    - https://thetheObjects.travelgosystems.net
    - https://thetheObjectswebapi.travelgosystems.net
    
      >Usage example: https://thetheObjectswebapi.travelgosystems.net/api/products/all
- If you remove all products in the theObjects and want to insert few test ones, just run the console application provided in the solution: *Products.Webapi.Creator*.
- *JS* validators located at Insertion page just show a red box if empty or invalid values.
