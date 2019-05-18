# theInventory


- Before launching the website check the WebAPI application is running in yout IIS Express.
- The WebAPI application uses SQL lite to store the inventory products.
- Login and password to access the website are: 
    - login: admin 
    - password: 1Inventory23
- Before log in into the website check that security is working by clicking on any of the menu links in the login page.
- An online working verion of the website and WebAPI service are available at:
    - https://theinventory.travelgosystems.net
    - https://theinventorywebapi.travelgosystems.net
- If you remove all products in the inventory and want to insert few test ones, just run the console application provided in the solution: Products.Webapi.Creator.
- Validators in Insertion page just check empty values: 
    - Weight value needs to be checked as a valid int pattern.
    - Price value needs to be checked as a valid decimal pattern.
    - Expiry Date needs to be checked as a valid dd/mm/yyyy string pattern.
