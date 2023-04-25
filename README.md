# Travel API

Stack:
- ASP.net
- Microsoft SQL Server
- Entity Framework

API with excursions managment,orders and authentication



#Swagger screenshot:
![image](https://user-images.githubusercontent.com/92157165/234266464-8efad161-e7bb-4559-8751-06c07ee6e790.png)

API allows non-authenticated user to HTTP GET all excursions or specified excursion with {id} parameter,
authenticated users can also order excursions, user authenticated as administrator is allow to POST,PUT,DELETE excursions and orders,
GET all users and orders of specified user.


USAGE:
Create MS SQL database and change appsettings.json in app directory.
