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

## Support

Raise an issue on this <a href="https://github.com/Jaycossey/blog-portfolio" target="_blank" referrer="noreferrer noopener">repo</a> for further support, or contact me via my existing <a href="https://ianscott.netlify.app/" target="_blank" referrer="noreferrer noopener">portfolio</a>