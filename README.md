# Travel API

Stack:
- C#/.NET
- ASP.NET
- Microsoft SQL Server
- Entity Framework

API with excursions managment,orders and authentication


API allows non-authenticated user to HTTP GET all excursions or specified excursion with {id} parameter,
authenticated users can also order excursions, user authenticated as administrator is allow to POST,PUT,DELETE excursions and orders,
GET all users and orders of specified user.


You can check this api on https://excursions.bsite.net/api
(use endpoints mentioned on screenshot below)

Full application(Frontend in progress) - https://excursions.bsite.net/
(Frontend made by https://github.com/PiotrWojcikievcz)

#Swagger screenshot:
![image](https://user-images.githubusercontent.com/92157165/234266464-8efad161-e7bb-4559-8751-06c07ee6e790.png)



USAGE:
Create MS SQL database and add appsettings.json to app directory.
