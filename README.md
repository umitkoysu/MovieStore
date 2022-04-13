# MovieStore

# Requirements

* .NET 6
* PostgreSQL

# How to run
```bash
git clone https://github.com/umitkoysu/MovieStore.git
cd MovieStore
cd src
cd Project.MovieStore.API
```

Edit database connection configurations in .appsettings.json file

```bash
 "Database": {
    "Provider": "pgsql",
    "ConnectionString": "Host=localhost;Database=MovieStoreDB;Username={USERNAME};Password={PASSWORD}"
  },
```

```bash
dotnet run
```

You should see the swagger in http://localhost:5000/swagger/index.html
