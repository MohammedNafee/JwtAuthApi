# JWT Authentication in .NET Core with Swagger UI

## 📌 Project Overview

This project demonstrates how to implement **JWT Authentication** in a **.NET Core Web API** and integrate it with **Swagger UI** for testing. It includes:

- User login with JWT token generation.
- Secure API endpoints using JWT authentication.
- Configuring Swagger to accept JWT tokens.

---

## 🛠 Technologies Used

- **.NET Core 6+**
- **C#**
- **JWT (JSON Web Token)**
- **ASP.NET Core Authentication & Authorization**
- **Swagger (Swashbuckle.AspNetCore)**

---

## 🚀 Getting Started

### 🔹 Prerequisites

Ensure you have the following installed:

- .NET SDK 6+ ([Download Here](https://dotnet.microsoft.com/en-us/download))
- Visual Studio Code or Visual Studio
- Postman (optional, for testing)

### 🔹 Setup Instructions

1️⃣ **Clone the repository**

```sh
 git clone https://github.com/your-repo/jwt-auth-dotnet.git
 cd jwt-auth-dotnet
```

2️⃣ **Install dependencies**

```sh
dotnet restore
```

3️⃣ **Run the project**

```sh
dotnet run
```

---

## 🔑 JWT Authentication Setup

### 📄 **Configuration in **``

```json
{
  "Jwt": {
    "Key": "YourSuperSecretKey12345",
    "Issuer": "yourapp.com",
    "Audience": "yourapp.com"
  }
}
```

### 🛠 **Enable JWT Authentication in **``

```csharp
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]);
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });
builder.Services.AddAuthorization();
```

---

## 🔐 Authentication Endpoints

### 1️⃣ **User Login (POST **``**)**

- **Request:**

```json
{
  "username": "admin",
  "password": "password"
}
```

- **Response:**

```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI..."
}
```

### 2️⃣ **Protected API (GET **``**)**

- **Requires JWT Token in Authorization Header**
- **Response:**

```json
{
  "message": "This is a protected resource!"
}
```

---

## 📌 Using JWT in Swagger UI

1️⃣ **Run the application** → `dotnet run` 2️⃣ **Open Swagger** → `https://localhost:<port>/swagger` 3️⃣ **Login via **`` → Copy the token. 4️⃣ **Authorize in Swagger** (Click "Authorize" button, enter `Bearer <TOKEN>`) 5️⃣ **Access protected endpoints**

---

🔥 Happy Coding! 🚀

# JwtAuthApi
