## ASP.NET MVC

It is a ASP.NET Core Web Application with `AspNetCore.Identity` package, that allows us to register and login the Users. According to a concept of this application, some functionalities are allowed for `annonymous` Users, some for Users that are `logged in` and some for `admin`. The logged in Users are able to add a new comment. The Admin can add a new city and a new country. Additionally, he can remove comments. All data are saved in database.

Application is based on:
* MVC model of Web Application,
* AspNetCore.Identity as a package to register Users,
* Entity Framework for C#,
* SQL as a database (Microsoft SQL Server),

How to launch application:
* Run your MS SQL Server,
* In the `appsettings.json` file change a value of `ApplicationDbContextConnection` properties to your own,
* Execute `update-datbase` command in a NuGet console,
* Run an application,
* Make sure, the database has been created and you are able to see 4 tables.

Admin credentials: 
* Login: `admin@gmail.com`,
* Password: `password`

SQL tables relations:
* City table is connected with AspNetUsers table by `1:1` relation,
* Coutry table is connected with AspNetUsers table by `1:1` relation,
* AspNetUsers table is connected with Comment table by `1:n` relation,

## Main View
The content of this view is based on the User status (not logged in, logged in) and role (no role, user, admin). At this case we are not logged in. Note, that we are able to see only 2 links in a navbar.

![1](https://user-images.githubusercontent.com/81427498/221918664-524bce3a-ba0c-4d42-8f5d-559bf0b01d95.jpg)

## Registration View
All input are validated by attibutes added in a model.

![2](https://user-images.githubusercontent.com/81427498/221919635-00b45fed-6682-4c20-9d6d-907e770ef7cd.jpg)

## Admin Functionalities View
The screenshot below represents all functionality allowed only for Admin.

![5](https://user-images.githubusercontent.com/81427498/221920389-496b458d-e732-40e1-8215-4e09a9cd11dd.jpg)

## Remove View
The Admin is allowed to remove comments.

![6](https://user-images.githubusercontent.com/81427498/221921412-5abb9eab-4994-4711-8604-25ecd5133208.jpg)
