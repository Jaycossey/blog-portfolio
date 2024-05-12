# Blog Portfolio With ASP.NET MVC  (WIP)

## Description 

Rework of portfolio with blog features to learn and further practice ASP.NET MVC C# skillset. In order to understand this new-to-me structured approach to Web Development, in a full stack environment, I have undertaken various tutorials on Syntax, languages and frameworks, varying from W3Schools, Microsoft Documentation, and Youtube tutorials. See [Resources](#resources) for further information on my sources for the information provided. 

This project is built to help me further understand the ASP.NET dev environment and is not intended as a full tutorial, please see [Support](#support)

## Contents
- [Walkthrough](#walkthrough---cli-cheatsheet)
    - [Terminology](#terminology)
    - [Create .NET](#create-a-net-project)
    - [MVC Architecture](#the-mvc-architecture)
    - [First Looks](#our-first-look-at-the-template-files)
    - [Adding a Controller](#adding-a-controller)
    - [Adding a View](#adding-a-view)
    - [Adding a Model](#adding-a-model)
    - [Adding a dotnet package](#adding-a-dotnet-package)
    - [DbContext](#dbcontext)
    - [Connection Strings](#connection-strings)
    - [Migrations](#migrations)
    - [CRUD Operations](#crud-operations)
    - [Seed Data](#seed-data)
- [Tech Stack](#tech-stack)
- [Resources](#resources)

## Walkthrough - CLI Cheatsheet

As my main Text Editor is currently VsCode on a Linux Machine, I shall be working with MVC Core, the following is a step by step walthrough of my process, from creation to deployment. 

### Prerequisites

This project requires the dotnet SDK, VsCode, prior programming experience, as well as a basic understanding of web development. See the [Tech Stack](#tech-stack) section for more details on the languages and frameworks used. 

I also highly recommend reading the <a href="https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-8.0&tabs=visual-studio" target="_blank" referrer="noreferrer noopener">documentation</a> to fully understand this program further. Other resources are listed in the [resources](#resources) section of this README file.

### Terminology

ASP (Active Server Pages)

.NET ([dotnet] Proprietary software framework owned by Microsoft)


### The MVC Architecture

The MVC (Model View Controller) is an intuitive, open source and well structured approach to full stack development. 

#### Controller
The project is structured into three catagories, the Controller, which handles the returned pages through the `RenderBody()` method in the `/Views/Shared/_Layout.cshtml` file. As well as controlling what data is passed to the return statement. We will look at these files and methods later on.

#### Model
The Model, forms the structure of the data passed through the Controllers and mimicks that of the data within the Database. Whether that be stored locally or on a Server.

#### View
The View, which is passed to the controllers return statement, is the cshtml that the end user sees. Within the views, which work similar to JS modules and React.JS components, the Model data is displayed dynamically.

This structured approach to development ensures that the programming paradigm of SRP (Single Responsibility Principle) is followed. Modularisation of code allows for reusability and helps reduce repetition of code.

### Create a .NET project
To begin a new .NET project in VsCode, run the following commands from the target directory.

```
// Create a new MVC Core project
dotnet new mvc -o <PROJECTNAME>

// Open and begin coding the project within VsCode
code -r <PROJECTNAME>

// Run project
dotnet run

// Watch server on local port
dotnet watch
```
This creates the template files for the model-view-controller.

We can run the template project with `dotnet run` and open the browser to the port displayed.

### Our first look at the template files

Our MVC project is created with MVC Core, while I will be using MVC 5 (No longer in development) for future projects, the core concepts will remain the same with minor syntactical differences.

An MVC project structure is viewed through the Solution Explorer for a more concise view of the files that will be actively developed. In this case, my files are structured within the BlogPortfolio Directory in the following way:
```
| BlogPortfolio
|--> Dependencies
    |--> Analysers
    |--> Frameworks
|--> Properties
    |--> launchSettings.json
|--> Controllers
    |--> HomeController.cs
|--> Models
    |--> Domain
    |--> 
    |--> ErrorViewModel.cs
|--> Views
    |--> Home
        |--> Index.cshtml
        |--> Privacy.cshtml
    |--> Blog
    |--> Portfolio
    |--> Shared
        |--> Error.cshtml
        |--> _Layout.cshtml
|--> wwwroot
    |--> css
        |--> site.scss
    |--> js
        |--> site.js
    |--> lib
        |--> bootstrap
        |--> jquery
    |--> favicon.ico
|--> appsettings.json
|--> Program.cs
```
While this list is not extensive, the directory structure is the same, and helps visualise the best practices for the MVC architectural development environment.

We can see that the MVC is broken down into the directories and within the C# files, utilises `namespace` to help target the relevant files to run. 

Lets look at Program.cs to begin with, as it is the first file to run when running an ASP.NET web application. 

### Program.cs

The first file to run when accessing a site is the Program.cs file, it calls the `CreateBuilder()` method and assigns it to a variable called `builder`. From here we `AddControllersWithViews()`. This binds the Controllers and the corresponding views to the builder. We then assign an `app` variable and call the `build()` method on the builder. Thereby 'building' the web application. 

Now that we have our application, and as we are still currently in a development environment, we add middleware (via the `UseHttpsRedirection`) to the HTTP requests, redirecting them to HTTPS. (HTTP - HyperText Transfer Protocol, which transmits unencrypted data, HTTPS combines these requests with SSL - Secure Sockets Layer, and TLS - Transport Layer Security, technology for encryption purposes.) 

The `UseStaticFiles()`, `UseRouting()` and `UseAuthorisation()` methods set up the client side and middleware files for the applciation. 

`MapControllerRoute()` sets the default endpoint for the application.

Hovering over these methods in VsCode will provide further more in depth descriptions. However it is important to understand what this program does in order to proceed in development.

### Adding a Controller
 
In order to create an endpoint for our application, we need to add a Controller to the project, we have in our template, a HomeController.cs file, this controls the data and views displayed at the default endpoint. 

When looking at the Controllers directory, we will add a file called 'BlogController.cs'. This should be a C# class file. From this point of the walkthrough forward, any new files will have details listed in the comments of the file itself. 

### Adding a View

Creating a View for the application requires a directory which shares the controllers namespace, in this example, we will use 'Blog' within our 'BlogController' we have the 'Index()' IActionResult which returns the View() method. This follows the naming conventions and returns the Index.cshtml file within the /Views/Blog directory.

To help with navigation following the creation of the view, note the comments in the _Layout.cshtml. Adding the navbar anchors with the `asp-controller` and `asp-action` attributes will bind the controller and resulting actions upon clicking the anchor element and making the request. (Line 53)

### Adding a Model

As previously mentioned, Models are the structure for the data that we have within the applications database. Each model represents a table within the database. In this case, to keep things simple, we will look at creating a 'BlogPost' model. 

Models are sets of classes which represent domain data and logic for the application. (See /Controllers/BlogController.cs)

#### Setting Custom Endpoints

In order to tidy up the url endpoints, we can add a `MapControllerRoute()` method below the default. Adding this method can help with creating API endpoints. See Program.cs line 27.

*Side Note*: most of the walkthrough will be written in the comments from this point forward. With key points being added as I progress through the project. 

### Adding a dotnet package

Packages and tools for development are code that has been written to help streamline the development process, our project is dependent on various packages and would not run without these installed without first writing the code ourselves.

To add dependencies and packages, we run the command:

``` 
// removes previously installed global tools
dotnet tool uninstall --global <TOOLNAME>

// adds dotnet tools
dotnet tool install <TOOLNAME>

// removes a package from the application
dotnet remove package <PACKAGENAME>

// Adds a package for a dotnet appliaction
dotnet add package <PACKAGENAME>
```

The tools and packages that we shall use in this application can be found in [Tech Stack](#tech-stack). The packages are stored under `/Dependencies/Packages/<PACKAGENAME>`

### DbContext

The main class that handles the mapping of Entity Framework (EF) is the DbContext, or database context class. This is an EF specific class which specifies the entities to be included in the data model. See <a href="https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-8.0" target="_blank" referrer="noopener noreferrer">documentation</a> for details.

Our DbContext is stored in the `/Data` directory under `BlogPortfolioDbContext.cs`. 

### Connection Strings

ASP.NETCore includes a design pattern known as Dependency Injection. This is a technique which achieves inversion of control between classes and dependencies. A connection string is a property that is defined within the `appsettings.json` file. Each .NET framework data provider has a Connection object which inherits from <a href="https://learn.microsoft.com/en-us/dotnet/api/system.data.common.dbconnection?view=net-8.0" target="_blank" referrer="noopener noreferrer">DbConnection</a> . There are many resources for Connection String Syntax, both with the official documentation and various cheatsheets. See [resources](#resources) for more details.

Once we have created our connection string and linked it via the `Program.cs` file, (see line 10), we can move onto creating the database with an initial migration.

### Migrations

An EF migration is a way to incrementally update a database schema to keep it in sync with hte applciations data model without manipulating the existing data within the database. See the Microsoft <a href="https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli" target="_blank" referrer="noopener noreferrer">documentation</a> for further information. 

To create a migration we create our model, then run the command:
```
// Creates a migration based on the models currently created.
dotnet ef migrations add <MIGRATIONNAME>
```

This will create a directory called `Migrations` and then subsequently generate files. These are table models which help the program map the data to tables in the database. 

Be sure to read through the generated migration files to understand what each file achieves. 

Once we have the schema, we the run:

```
// updates the database schema 
dotnet ef database update
```
This command creates the databse and tables within it, following the migration mapping. 

As our application grows in scale, we will likely need to update our database schema. To do this we now run:

```
dotnet ef migrations add <UPDATEDMIGRATION>
dotnet ef database update
```

In full the process would look like the following example:

```
// initial migration
dotnet ef migrations add InitialCreate

// create database
dotnet ef database update

/* Adding further models and data */

// create a new migreation
dotnet ef migrations add UpdateTimestampMigration

// update database 
dotnet ef database update
```

Once we have our database created, we update our controller with dependency injection (see line 9 of `/Models/BlogController.cs`) to allow the relational mapping of the database to the CRUD operations we are about to create.

### CRUD Operations

CRUD (Create, Read, Update, Delete) operations, are the four basic database operations, allowing us to handle various functions on a database. See [resources](#resources) for documentation and walkthrough. 

For our application we will create the following views in order to handle these operations.


#### Create

HTTP POST requests. To handle this operation, we will create a view with an asp-controller form which takes user input following the BlogPost model, minus the ID which is generated automatically alongside the published date.

#### Read

HTTP GET requests, we will create two views to handle these requests, our Index.cshtml will list all blogposts, displaying a brief overview of the existing data. Including the title, featured image, short description, and the published date of the post. We will also be able to create a blogpost from this page.

The second view we will create is a Details.cshtml, showing an individual blogpost. From here we will be able to edit and delete the posts.

In order to differentiate which view is shown, we will create an endpoint which takes the ID to filter between posts. 

#### Update

HTTP PUT requests. Our view for this will look similar to the create view, with the caveat that the form is filled with the existing data of the blogpost.

#### Delete

This endpoint will be triggered from within the Update view, as part of the editing functionality, hidden behind a JS conditional render of a confirm button.

#### Updating the controller

In order to handle the various views and functionality, we first need to update our Controller. 

### Seed Data

Seed Data is data that is fed to the application as default. When running an application we use Seed Data as template input. We can use the SeedData.cs model to feed data into the database for initial migrations. See [resources](#resources) for details and documentation walkthrough. In our example, we will feed in a few lorem ipsum (dummy text) BlogPost models to begin structuring our application.

Once we have created and updated our seedData file, we need to add the feed into our `Program.cs` (see line 26).

### Feeding data to the Views

Now that we have seed data, a database, and our basic crud operations, we need to edit the code within the Controller to display that data and handle the functionality of the CRUD operations. 

The specifics (including comments and breakdown) are in the Blog Controller under the respective Action Methods and in the Views. 

### Remaining code

When we have created our data and fed it into our application via SeedData, as well as creating the references via DbContext, we can create our CRUD functionality, this is described in the BlogController.cs file. See [resources](#resources) for more information.

Once our CRUD operations are finalised, we can then use various CSS and JavaScript within our View files to customise the remaining application pages.

### Bonus - Adding a second model to the database

As touched upon in the [migrations](#migrations) section, we can update our models and add new data to a database with a new migration, this is also true with SQL Server and database queries when creating a new table. In our example, we have now added in the PortfolioController, as well as a model (Projects.cs) and an Index.cshtml View. We have also added a new `<a>` tag to our _Layout.cshtml file in order to help navigation during development. In our BlogPortfolioDbContext.cs file, we have also added in a new DbSet method to include our new model.

In our project model, we see differing properties to the BlogPost model. In order to add this to the dbcontext and tables within our db file, we need to migrate the data with an update, once we have completed that then we can create new Seed Data following the migration and DB updates via EF. 



## Tech Stack

- ASP.NET MVC Core
- C#
- CSHTML
- JS
- SQL
- SQLite
- EntityFrameworkCore
    - .Tools
    - .Design
    - .SQLite
    - .SqlServer

## Resources

Sameer Saini - Content Creator and Course Instructor for ASP.NET - <a href="https://www.youtube.com/@SameerSaini" target="_blank" referrer="noreferrer noopener">Youtube</a>

Database Seeding - Microsoft Documentation - <a href="https://learn.microsoft.com/en-us/ef/core/modeling/data-seeding" target="_blank" referrer="noreferrer noopener">Link</a>


ConnectionStrings - Microsoft Documentation - <a href="https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/connection-string-syntax" target="_blank" referrer="noreferrer noopener">Link</a>

ConnectionStrings - Syntax Cheatsheet - <a href="https://www.connectionstrings.com/" target="_blank" referrer="noreferrer noopener">Link</a>

C# Syntax - w3Schools - <a href="https://www.w3schools.com/cs/index.php" target="_blank" referrer="noreferrer noopener">Link</a>

CRUD Operations - Microsoft Documentation - <a href="https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/crud?view=aspnetcore-8.0" target="_blank" referrer="noreferrer noopener">Link</a>

CRUD Operations in MVC - C# Corner - <a href="https://www.c-sharpcorner.com/article/crud-operation-in-asp-net-mvc2/" target="_blank" referrer="noreferrer noopener">Link</a>

## Support

Raise an issue on this <a href="https://github.com/Jaycossey/blog-portfolio" target="_blank" referrer="noreferrer noopener">repo</a> for further support, or contact me via my existing <a href="https://ianscott.netlify.app/" target="_blank" referrer="noreferrer noopener">portfolio</a>


## Side Notes and TODO's:

When working with SQL databases and SQLServer, migrations work the same, the difference is in the dbcontext, which is a reference to the connection strings, these are tailored with the syntax to contextualise the connected server, as well as the database within it. Database files are created with the migrations, so the tables dont exist prior to running the migration commands. 

We also see how the SQL commands work when making endpoint calls within controllers. If we read the terminal when switching to the Blog/Index, we see a SELECT * FROM command, which we know (source w3Schools) is select all from database. These calls run through the dbcontext to target the specific database. 

When connected to a SQLServer, whether that is via mssql or sqlserver within the vscode extention, we can make direct SQL queries to this and write out own SQL. This is very useful when creating APIs and designing those endpoints, we have the option, essentially, to create edits to the server without having to be using the application, provided that we are connected to that server. - THIS IS VERY IMPORTANT knowledge, especially as I progress through my CyberSec course. Knowing how the SQL commands work, allows for potential SQLInjection attacks, providing we are connected to the server, its how hackers and pentesters can access data.