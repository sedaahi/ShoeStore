# ShoeStore

online shopping website

### Project Structure
```
/src
* ApplicationCore
* Infrastructure
* Web

/tests
* UnitTests
```

### Migrations
```
/Infrastructure
Add-Migration InitialCreate -Context StoreContext -OutputDir "Data\Migrations"
Update-database -Context StoreContext

```

### Packages

```
/ApplicationCore
Install-Package Ardalis.Specification -v 5.2.0 

/Infrastructure
Install-Package Microsoft.EntityFrameworkCore -v 5.0.14
Install-Package Npgsql.EntityFrameworkCore.PostgreSQL -v 5.0.10
Install-Package Ardalis.Specification.EntityFrameworkCore -v 5.2.0
```

### Resources

* https://github.com/yigith/TechMarket
* https://github.com/dotnet-architecture/eShopOnContainers
* https://www.connectionstrings.com/postgresql/