# Shopper Store [![Build status](https://ci.appveyor.com/api/projects/status/kksgy2fifpuqaeln?svg=true)](https://ci.appveyor.com/project/tmacharia/shop-challenge-vue)

Shopper store is an application that lists shops near your by distance. It allows you to have your own personal list of favourite/preferred shops that you like for easier access rather than browsing through the entire collection all shops.

<img src="img/shopper-min.gif"/>

<br/>
<br/>
<br/>

# Table of Contents

+ [Introduction](#introduction)
+ [Prerequisites](#prerequisites)
+ [Installation](#installation)
+ [Database Seeding](#database-seeding)
+ [Running](#running-application)
+ [Features](#features)
+ [Architecture](#architecture)
    + [Frontend](#frontend)
        + [Routing](#frontend-routing)
    + [Backend](#backend)
        + [Design Patterns](#design-patterns)
+ [Contributing](#contributing)
+ [Author](#author)
+ [Credits](#credits)

<h2 id="introduction">Introduction</h2>

To adhere to the technical specifications of the challenge requiring the solution to be a single page application, 
the application uses [Vue.js](https://vuejs.org/) in the front-end for routing & navigation between pages while the backend is written
in [Asp.Net Core 2.2.1](https://docs.microsoft.com/en-us/aspnet/core/index?view=aspnetcore-2.2#recommended-learning-path)

<h2 id="prerequisites">Prerequisites</h2>

Below is a list of all the tools & developer resources required to get the project up and running.

+ [Visual Studio 2019](https://visualstudio.microsoft.com/vs/)
+ [.NET Core SDK 2.2](https://dotnet.microsoft.com/download/dotnet-core/2.2)
+ [Nuget](https://www.nuget.org/) - Package manager for .NET apps.
+ [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) - Will act as our ORM.
+ [Asp.Net Core Identity](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-2.2&tabs=visual-studio) - Membership system to add login/register functionality.
+ [Node.js](https://nodejs.org/) - Required for acquisition of npm packages, running webpack commands e.t.c
+ [Webpack](https://webpack.js.org/) - For bundling & minification of front-end dependecies as we shall see later on in this document.

<h2 id="installation">Installation</h2>

To get the application started on your local machine, first clone this git repository by running the following command on a
terminal in a folder of your choice.

```bash
git clone https://github.com/tmacharia/shop-challenge-vue.git
```

Navigate to the cloned directory as follows by running *cd shop-challenge-vue*

**Restore/Install Dependencies**

First, let's get all dependecies & npm packages installed by consecutively running the following commands

**Packages Restore/Install**

```bash
npm run restore
```
This command will run two commands, _dotnet restore_ to restore all .NET nuget packages & _npm install_ that will install all devDependencies needed as outlined in _package.json_

### Build

We now need to generate the static resources i.e js,and css files that will be rendered by the browser and also build the .NET project (the backend) to ascertain that it builds successfully and therefore can run. There are two sets of scripts in _package.json_ for building the project. Both will build the project & generate our static resources in our public folder _wwwroot_

#### Development Build
```bash
npm run build-dev
```
>Builds the project in **Debug** mode and generates sitemaps for the static resources as you will see after running this command. You can checkout _webpack.config.js_ to how we instruct webpack to generate our files in _Development_ mode.

#### Production Build
```bash
npm run build-prod
```
> Builds the project in **Release** mode, generates our static resources & optimizes them by applying **UglifyJsPlugin** to reduce the size of the output js files.

<h2 id="database-seeding">Database Seeding</h2>

To create database schemas & initial seed data to get our application up running, we need to apply the migrations in the _📁 Migrations_ folder.

Before you run the migrations, you need to confirm that the database **ConnectionString** is correct in _appsettings.json_. Make sure that is points to a valid instance of [Microsoft SQL Server](https://www.microsoft.com/en-gb/sql-server/sql-server-downloads).

Command to apply migrations & seed initial data:

```bash
dotnet ef database update --verbose
```

That's it! The application is now ready to run.

<h2 id="running-application">Running Application</h2>

Just run the following command on a terminal in the root directory of the project

```bash
dotnet run
```

The application will immediately start running:

`http://locahost:5000`

<h2 id="features">Application Features</h2>

+ View Nearby Shops - access this on the main page or by navigating to either of the following paths on your browser: (`/shops`)
+ Like Shop - like a shop so that it appears under _My Preferred Shops_ for easy access & hidden from the main page.
+ Dislike Shop - unfavourite a shop by disliking it so that it's hidden from the mainpage for the next 2 hours.
+ Remove Preferred Shop - deletes a shop from the list of _My Preferred Shops_ and unhides from the mainpage. (`/shops/preferred`)
+ User SignUp - allows users to signup/register an account using an email address, username & password. (`/account/signup`)
+ User SignIn - allows already registered users to sign in to their account. (`/account/signin`)

<h2 id="architecture">Architecture</h2>
<h3 id="frontend">Frontend</h2>

Using vue.js, we modularize all our features/requirements into components with each having it's own folder as shown in the figure below.


```
📦ClientApp
 ┣ 📂components
 ┃ ┣ 📂account
 ┃ ┃ ┣ 📜account.css
 ┃ ┃ ┣ 📜account.ts
 ┃ ┃ ┣ 📜account.vue.html
 ┃ ┃ ┣ 📜signin.ts
 ┃ ┃ ┣ 📜signin.vue.html
 ┃ ┃ ┣ 📜signup.ts
 ┃ ┃ ┗ 📜signup.vue.html
 ┃ ┣ 📂app
 ┃ ┃ ┣ 📜app.ts
 ┃ ┃ ┗ 📜app.vue.html
 ┃ ┣ 📂navmenu
 ┃ ┃ ┣ 📜navmenu.css
 ┃ ┃ ┣ 📜navmenu.ts
 ┃ ┃ ┗ 📜navmenu.vue.html
 ┃ ┣ 📂preferred-shops
 ┃ ┃ ┣ 📜preferred-shops.ts
 ┃ ┃ ┗ 📜preferred-shops.vue.html
 ┃ ┣ 📂shops
 ┃ ┃ ┣ 📜shops.ts
 ┃ ┃ ┗ 📜shops.vue.html
 ┃ ┗ 📜cookiesHelper.ts
 ┣ 📂css
 ┃ ┗ 📜site.css
 ┗ 📜boot.ts
 ```

 <h4 href="frontend-routing">Routing</h4>

 In _boot.ts_, which acts as the main entry point for our frontend application, we register routes for all our features that will instruct the browser what to render for what routes.

 <img src="img/vue-routes-min.png" alt="Frontend Routing image"/>

<h3 id="backend">Backend</h2>

Server-side solution architecture, structure & organization.

<img src="img/backend-structure-min.png" alt="backend solution structure image"/>

<h4 id="design-patterns">Design Patterns & Principles</h4>

Below is a list of some of the design patterns, principles and best practises in accordance to the framework used (AspNet Core) & general software engineering guidelines:

1 [Inversion of Control Containers & Dependency Injection Pattern](https://martinfowler.com/articles/injection.html#InversionOfControl)

> Inversion of control is all about giving control to the container to get instance objects rather than creating objects using the **new operator**, let the container do that for you.

<img src="img/di-container-min.png" alt="DI container image"/>

<i>
    As you can see in the figure above, we are adding <b>ShopDbContext</b> to the default Asp.Net Core container so that it can be available to any controller at runtime.
    <br/><br/>
    We are also configuring <a href="https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity-custom-storage-providers?view=aspnetcore-2.2">Microsoft ASP.NET Core Identity</a> Users model, Roles model, and the storage provider for these models. This will in turn avail identity interfaces, and other methods to use in user account membership & access control.
    <br/><br/>
    Let's now see how we use the added services in our controllers/Api Endpoints.
</i>

**Dependency Injection in AccountsController**
<br/>

<img src="img/di-injection-account-controller-min.png" alt="DI in account controller image"/>

<i>
Here, we are using constructor injection to provide our controller with the services it requires which are already created/initialized by the DI container. This services are used in user account login & registration.
</i>

**Dependency Injection in ShopsController**
<br/>

<img src="img/di-injection-shops-controller-min.png" alt="DI in shops controller image"/>

<i>
Here, we are also using contructor injection to avail this controller with <b>ShopsDbContext</b> from the DI container so that we access the list of registered shops in the database.
</i>

<br/>
<br/>

<h2 id="contributing">Contributing</h2>

Just fork this repository to get started. 

>**N.B** Follow the project's current structure & methodologies when adding new features to enable consitency in throughout the project. 

#### For Example:

Let's say you want to add a new feature, below are some guidelines to get you started:

1. Create a new page - by adding a new component in _ClientApp/components/{feature-name}/_. Remember to use a descriptive name that symbolizes what your feature does.
2. Add html, css, and Typescript file as it is in the other components.
3. Register route - add a route in _ClientApp/boot.ts_ that points to your component so users can access it.
4. If your feature does/requires some server processing, you may need to create a controller in _Controllers/_ folder and add the API endpoints you need. You can call your endpoints from the frontend in your Typescript file using Axios as it is the case _ClientApp/components/shops.ts_ component.
5. If you need a new database table, all schema definitions are in the _Models/_ folder, once you've added your new class, remember to add it to **ShopDbContext** class so that EntityFramework knows that a new table/migration should be generated.

Once you've made your updates; be it updates, fixes, or new feature developments, create a pull request and your changes will get reviewed and merged to master.

<h2 id="author">Author</h2>

Project written by <a href="https://github.com/tmacharia">Timothy Macharia</a> 

Incase of any questions, drop me an inbox at my
<a href="mailto:timothy.macharia@outlook.com" style="font-size:1.5em;">📧Email
</a>

<h2 id="credits">Credits</h2>

This project is part of a coding challenge by <a href="https://github.com/hiddenfounders">United Remote</a>