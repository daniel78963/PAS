# PAS Products And Services DDD with .NET 6

Sample implementation of the Clean Architecture Principles with .NET Core. 

# Features

- Entity Framework
- Repository 
- Generic Repository 
- Unit Of Work
- OrderBy
- Validation fieds with Attributes

# OrderBy
Example
```sh
https://localhost:7288/api/ProductCategory?OrderBy=NameCategory%20desc
```

- SortHelper
- Nuget: System.Linq.Dynamic.Core

# Rate Limit
out of .NET 6 
This package contains an IpRateLimitMiddleware and a ClientRateLimitMiddleware to support the IP Address and client-key throttling strategies respectively. 

- SortHelper
- Nuget: AspNetCoreRateLimit
- AspNetCoreRateLimit.Redis
