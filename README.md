![enter image description here](https://theinventory.travelgosystems.net/images/logo.png)
##
> **Important tips and notes:**



- **Clone** repository in your local repo folder then **Open** solution then **Rebuild** solution to restore **Nuget** packages.
- Before launching the website check the *WebAPI* application is running in yout *IIS Express*.
- The *WebAPI* application uses *SQLite* to store the inventory products.
- Login and password to access the website are: 
    - **login**: admin 
    - **password**: 1Inventory23
- Before logging into the website, check that security is working by clicking on any of the menu links in the login page.
- An online working version of both, the website and *WebAPI* service are available here:
    - https://theinventory.travelgosystems.net
    - https://theinventorywebapi.travelgosystems.net
    
      >Usage example: https://theinventorywebapi.travelgosystems.net/api/products/all
- If you remove all products in the inventory and want to insert few test ones, just run the console application provided in the solution: *Products.Webapi.Creator*.
- *JS* validators located at Insertion page just show a red box if empty or invalid values.
