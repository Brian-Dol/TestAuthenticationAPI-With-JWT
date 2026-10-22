<div align="center">

<img src="https://capsule-render.vercel.app/api?type=waving&color=0:0f172a,100:0ea5e9&height=170&section=header&text=JWT%20Authentication%20API&fontColor=ffffff&fontSize=44&fontAlignY=38&desc=An%20ASP.NET%20Core%20sample%20for%20JWT%20and%20role-based%20authorization&descAlignY=60&descSize=16" alt="JWT Authentication API — ASP.NET Core JWT and role authorization sample" />

![C#](https://img.shields.io/badge/C%23-.NET%206-512bd4?style=flat-square&logo=dotnet&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-Web%20API-512bd4?style=flat-square&logo=dotnet&logoColor=white)
![JWT](https://img.shields.io/badge/Auth-JWT-000000?style=flat-square&logo=jsonwebtokens&logoColor=white)
![Razor Pages](https://img.shields.io/badge/UI-Razor%20Pages-512bd4?style=flat-square&logo=dotnet&logoColor=white)

</div>

A small ASP.NET Core project containing JWT login and role-protected controller examples alongside a Razor Pages host. The intended authentication implementation is in `Startup.cs` and the API controllers; the current `Program.cs` does not register that pipeline, as noted below.

## ✨ Features

- Declares `POST /api/Login` to authenticate against an in-memory list and issue a 15-minute JWT.
- JWT validation is configured in `Startup.cs` using issuer, audience, expiry, and signing-key checks.
- Declares role-protected endpoints for administrators, sellers, and either role under `/api/User`.
- Declares an unauthenticated `/api/User/Public` endpoint.
- Includes Razor Pages and ASP.NET Core MVC controller source.

## 🏗️ Architecture

The repository contains two pieces of host configuration: `Program.cs` starts Razor Pages, while `Startup.cs` contains the controller and JWT setup. They are not connected in the current entry point.

### Controller routes declared in source

| Method | Route | Access |
|---|---|---|
| `POST` | `/api/Login` | Anonymous; checks the in-memory sample users |
| `GET` | `/api/User/Admins` | `Administrator` role |
| `GET` | `/api/User/Sellers` | `Seller` role |
| `GET` | `/api/User/AdminsAndSellers` | `Administrator` or `Seller` role |
| `GET` | `/api/User/Public` | No authorization attribute |

If the controller pipeline is wired into the host, protected requests use `Authorization: Bearer <token>`.

## 🧰 Tech stack

| Layer | Technology |
|---|---|
| Language and runtime | C#, .NET 6 |
| Web framework | ASP.NET Core MVC, Web API, Razor Pages |
| Authentication | JWT bearer authentication and role claims |
| Packages | `Microsoft.AspNetCore.Authentication.JwtBearer`, `Microsoft.IdentityModel.Tokens`, `System.IdentityModel.Tokens.Jwt` |
| Persistence | In-memory sample users; no user database configured |

## 🚀 Getting started

Install the .NET 6 SDK, then from the repository directory:

```powershell
dotnet restore
dotnet run
```

The launch profile uses `https://localhost:7126` and `http://localhost:5009`. With the current `Program.cs`, this starts the Razor Pages host; API controllers and JWT authentication are not registered, so the routes listed above are not available from the running host without a code change.

## 📁 Project structure

```text
.
├── Controllers/       # Login and role-based user controllers
├── Models/            # Login payload, user model, sample user list
├── Pages/             # Razor Pages and error page
├── Program.cs         # Current Razor Pages application entry point
├── Startup.cs         # Separate MVC/controller and JWT configuration
└── TestAuthenticationAPI.csproj
```

## 🗺️ Roadmap/Notes

- Learning/demo code only; it is not production-ready authentication. Users and passwords are hard-coded in `UserConstants.cs`, and the JWT signing key is committed in `appsettings.json`. Replace these values and use secure configuration before any deployment; do not reuse them.
- Wire the controller/JWT configuration into the application entry point before relying on the declared API routes.
- The project targets .NET 6, which is out of support. Upgrade to a supported .NET release before production use.
- No automated test project is present.

## 👤 Author

**Brian Dol**, Senior Full Stack Engineer · [Portfolio](https://portfolio.dol-brian23.workers.dev/) · [LinkedIn](https://linkedin.com/in/brian-dol-31a06115a/)
