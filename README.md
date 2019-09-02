# Nearby Shops
[![Build status](https://ci.appveyor.com/api/projects/status/kksgy2fifpuqaeln?svg=true)](https://ci.appveyor.com/project/tmacharia/shop-challenge-vue)

Coding challenge of an app listing shops nearby

<img src="img/shopper.gif"/>

# Table of Contents

+ [Introduction]()
+ [Prerequisites]()
+ [Installation]()
+ [Database Seeding]()
+ [Running]()
+ [Features]()
+ [Architecture]()
    
    + [Frontend]()
    + [Backend]()
+ [Contributing]()
+ [Authors]()
+ [License]()

## Introduction

To adhere to the technical specifications of the challenge requiring the solution to be a single page application, 
the application uses [Vue.js](https://vuejs.org/) in the front-end for routing & navigation between pages while the backend is written
in [Asp.Net Core 2.2.1](https://docs.microsoft.com/en-us/aspnet/core/index?view=aspnetcore-2.2#recommended-learning-path)

## Prerequisites

Below is a list of all the tools & developer resources required to get the project up and running.

+ [Visual Studio 2019](https://visualstudio.microsoft.com/vs/)
+ [.NET Core SDK 2.2](https://dotnet.microsoft.com/download/dotnet-core/2.2)
+ [Nuget](https://www.nuget.org/) - Package manager for .NET apps.
+ [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) - Will act as our ORM.
+ [Asp.Net Core Identity](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-2.2&tabs=visual-studio) - Membership system to add login/register functionality.
+ [Node.js](https://nodejs.org/) - Required for acquisition of npm packages, running webpack commands e.t.c
+ [Webpack](https://webpack.js.org/) - For bundling & minification of front-end dependecies as we shall see later on in this document.

## Installation

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

## Database Seeding

To create database schemas & initial seed data to get our application up running, we need to apply the migrations in the _📁 Migrations_ folder.

Before you run the migrations, you need to confirm that the database **ConnectionString** is correct in _appsettings.json_. Make sure that is points to a valid instance of [Microsoft SQL Server](https://www.microsoft.com/en-gb/sql-server/sql-server-downloads).

Command to apply migrations & seed initial data:

```bash
dotnet ef database update --verbose
```

That's it! The application is now ready to run.

## Running The Application

Just run the following command on a terminal in the root directory of the project

```bash
dotnet run
```

The application will immediately start running:

`http://locahost:5000`

## Application Features


