# Nearyby Shops
[![Build status](https://ci.appveyor.com/api/projects/status/kksgy2fifpuqaeln?svg=true)](https://ci.appveyor.com/project/tmacharia/shop-challenge-vue)

Coding challenge of an app listing shops nearby

## Introduction

To adhere to the technical specifications of the challenge requiring the solution to be a single page application, 
the application uses [Vue.js](https://vuejs.org/) in the front-end for routing & navigation between pages while the backend is written
in [Asp.Net Core 2.2.1](https://docs.microsoft.com/en-us/aspnet/core/index?view=aspnetcore-2.2#recommended-learning-path)

## Developer Resources & Tools Used

Below is a list of all the tools & developer resources required/used for the project and links of where to get them.

+ [Visual Studio 2019](https://visualstudio.microsoft.com/vs/)
+ [.NET Core SDK 2.2](https://dotnet.microsoft.com/download/dotnet-core/2.2)
+ [Nuget](https://www.nuget.org/) - Package manager for .NET apps.
+ [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) - Will act as our ORM.
+ [Asp.Net Core Identity](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-2.2&tabs=visual-studio) - Membership system to add login/register functionality.
+ [Node.js](https://nodejs.org/) - Required for acquisition of npm packages, running webpack commands e.t.c
+ [Webpack](https://webpack.js.org/) - For bundling & minification of front-end dependecies as we shall see later on in this document.

## Project Structure

## Getting Started

To get the application started on your local machine, first clone this git repository by running the following command on a
terminal in a folder of your choice.

```bash
git clone https://github.com/tmacharia/shop-challenge-vue.git
```

Navigate to the cloned directory as follows:

```bash
cd shop-challenge-vue
```
### Restore/Install Dependencies
First, let's get all dependecies & npm packages installed by consecutively running the following commands

**Npm Packages Install**
```bash
npm install
```
Installs all devDependencies needed as outlined in _package.json_
 **Nuget Packages Restore**
 ```bash
 npm run restore
 ```
 This will restore all nuget packages used in the project plus load the target framework/sdk for the projects.

 ### Building & Generation of front-end resources