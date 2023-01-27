<a name="readme-top"></a>

<!-- TABLE OF CONTENTS -->

# 📗 Table of Contents

- [📖 About the Project](#about-project)
  - [🛠 Built With](#built-with)
    - [Tech Stack](#tech-stack)
    - [Key Features](#key-features)
- [💻 Getting Started](#getting-started)
  - [Setup](#setup)
  - [Prerequisites](#prerequisites)
  - [Install](#install)
  - [Usage](#usage)
- [👥 Authors](#authors)
- [⭐️ Show your support](#support)
- [🙏 Acknowledgements](#acknowledgements)
- [❓ FAQ (OPTIONAL)](#faq)
- [📝 License](#license)

<!-- PROJECT DESCRIPTION -->

# 📖 AdvancedWebAPI <a name="about-project"></a>

*AdvancedWebAPI* is a .NET Solution that uses a layer architecture to expose a minimal Web API 
and to validate advanced data recovery using paging, filtering, searching and sorting.

# Web API Service:

## getAdvancedPeople Method:
### Paging:
![Paging](https://user-images.githubusercontent.com/8497300/212796101-1ad6c6df-c560-47d7-96f1-248b89a9a18a.png)

### Paging Header:
![Paging Response Header](https://user-images.githubusercontent.com/8497300/212796227-e74d418a-91c7-4f12-8ac8-c27920416f9c.png)

### Paging in Postman:
![Paging Postman](https://user-images.githubusercontent.com/8497300/212796141-5899c960-2d28-4a74-b5c7-fe1bf214b411.png)

### Filtering:
![Filtering](https://user-images.githubusercontent.com/8497300/212796372-e72f8c71-0e2f-4a56-8bd9-c4858f6eb345.png)

### Filtering in Postman:
![Filtering Postman](https://user-images.githubusercontent.com/8497300/212796428-cabd41d8-91bb-454d-a0db-316996691e91.png)

### Searching:
![Searching](https://user-images.githubusercontent.com/8497300/212796554-3c6aa3f9-6fd1-4de7-b74e-adb38bb15e91.png)

### Searching in Postman:
![Searching Postman](https://user-images.githubusercontent.com/8497300/212796589-624693b2-9409-44b9-8469-4d2fa89aca71.png)

## Sorting:
![Sorting](https://user-images.githubusercontent.com/8497300/212796661-c7261b3e-06eb-4245-a536-65065df61068.png)

### Sorting in Postman:
![Sorting Postman](https://user-images.githubusercontent.com/8497300/212796630-53a822b7-f87f-495c-8903-24213848a607.png)

## DTO Schema:
![DTO Schema](https://user-images.githubusercontent.com/8497300/212795992-d4e9977b-1cc2-4100-9882-51c7f338142e.png)

## getAllPeople Method:
![01](https://user-images.githubusercontent.com/8497300/212795860-4446485a-e7c6-43af-9b64-abd4b6ca094a.png)
## 🛠 Built With <a name="built-with"></a>

### Tech Stack <a name="tech-stack"></a>

.NET Core Minimal API, 

<details>
  <summary>Server</summary>
  <ul>
    <li><a href="https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis">Minimal API</a></li>
  </ul>
</details>

<details>
<summary>Database</summary>
  <ul>
    <li><a href="https://www.microsoft.com/en-US/download/details.aspx?id=101064">SQL Server</a></li>
  </ul>
</details>

<!-- Features -->

### Key Features <a name="key-features"></a>

- **EF Core Database First**
- **Unit of Work and Repository Patterns**
- **Services Dependency Injection**

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- GETTING STARTED -->

## 💻 Getting Started <a name="getting-started"></a>

To get a local copy up and running, follow these steps:

### Prerequisites

In order to run this project you need:

- Visual Studio .NET 2022 updated to use NET Core 7
- SQL Server Database 

### Setup

1. Clone this repository to your desired folder:

```sh
  cd my-folder
  git clone https://github.com/NeckerFree/AdvancedWebAPI
```

2. Download and restore the Adventure Works Database according to your SQL Server version
[Adventure Works DB](https://github.com/Microsoft/sql-server-samples/releases/tag/adventureworks)

3. Create a User as db_owner of this batabase

4. Modify the connection string (AdventureWorksConnection) in the file \AWA.MinApi\appsettings.json to point your database
### Install

Install this project with:
1. Build the solution and assure that doesn't have errors

2. Set the project AWA.MinApi as default 

### Usage

To run the project, 

- Start the application (F5) 

- The /swagger/index.html page is displayed

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- AUTHORS -->

## 👥 Authors <a name="authors"></a>

👤 **Elio Cortés**

- GitHub: [@NeckerFree](https://github.com/NeckerFree)
- Twitter: [@ElioCortesM](https://twitter.com/ElioCortesM)
- LinkedIn: [elionelsoncortes](https://www.linkedin.com/in/elionelsoncortes/)


<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- CONTRIBUTING -->

## 🤝 Contributing <a name="contributing"></a>

Contributions, issues, and feature requests are welcome!

Feel free to check the [issues page](../../issues/).

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- SUPPORT -->

## ⭐️ Show your support <a name="support"></a>

If you like this project please start my project

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- ACKNOWLEDGEMENTS -->

## 🙏 Acknowledgments and references <a name="acknowledgements"></a>
This project is based on the articles published by Code Maze:
[Paging](https://code-maze.com/paging-aspnet-core-webapi)
[Filtering](https://code-maze.com/filtering-aspnet-core-webapi)
[Searching](https://code-maze.com/searching-aspnet-core-webapi)
[Sorting](https://code-maze.com/sorting-aspnet-core-webapi)

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- FAQ (optional) -->

## ❓ FAQ (OPTIONAL) <a name="faq"></a>

- **What command are required to Scaffold from Scratch a DB First?**

  - Run next commands:
  ```
    dotnet add AWA.DataAccess package Microsoft.EntityFrameworkCore.Design
    dotnet add AWA.DataAccess package Microsoft.EntityFrameworkCore.SqlServer

    dotnet ef dbcontext scaffold "Data Source=.;Initial Catalog=AdventureWorks2017; User Id=XXUser;Password=XXPWD;Encrypt=False" Microsoft.EntityFrameworkCore.SqlServer --project AWA.DataAccess --output-dir "AWA.Models\Models" --context-dir "AWA.DataAccess\Data" --namespace AWA.Models --context-namespace AWA.DataAccess --context AdventureWorksContext -f --no-onconfiguring
    dotnet tool install --global dotnet-ef
    dotnet tool update --global dotnet-ef 
  ```
- **How to Implement Unit Of Work and Generic Repository pattern?**
   - [Unit Of Work And Generic Repository pattern](https://www.c-sharpcorner.com/article/implement-unit-of-work-and-generic-repository-pattern-in-a-web-api-net-core-pro)
   - [Repository Pattern and Unit of Work](https://enlear.academy/repository-pattern-and-unit-of-work-with-asp-net-core-web-api-6802e1aa4f78)

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- LICENSE -->

## 📝 License <a name="license"></a>

This project is [MIT](./LICENSE) licensed.

[MIT license](https://choosealicense.com/licenses/mit/) 

<p align="right">(<a href="#readme-top">back to top</a>)</p>







