# SignalFood

### Project Layers
```cs
    EntityLayer
    DataAccessLayer => EntityLayer + DtoLayer
    BusinessLayer   => DataAccessLayer + EntityLayer + DtoLayer
    SignalFoodApi   => BusinessLayer + DataAccessLayer + EntityLayer + DtoLayer
    SignalFoodWebUI
```

### Packages of SignalFood Project Layers
```cs
    DataAccessLayer
    - Microsoft.EntityFrameworkCore 6.0.25
    - Microsoft.EntityFrameworkCore.Design 6.0.25
    - Microsoft.EntityFrameworkCore.SqlServer 6.0.25
    - Microsoft.EntityFrameworkCore.Tools 6.0.25
```
```cs
    SignalFoodApi
    - AutoMapper 12.0.1
    - AutoMapper.Extensions.Microsoft.DependencyInjection 12.0.1
    - Microsoft.EntityFrameworkCore.Design 6.0.25
    - Swashbuckle.AspNetCore 6.5.0
```
```cs
    SignalFoodWebUI
    - client-side library - @microsoft/signalr@6.0.6
```

Use this commands for the `Migration Operations`:
- Create Migration
```
    PM> Add-Migration [MigrationName]
```
- Update Data   (Add Configurations)
```
    PM> Update-Database
```
- Remove Last Migration
```
    PM> Remove-Migration
```
- Drop the Database
```
    PM> Drop-Database
```

