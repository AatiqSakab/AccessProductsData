# AccessProductsData API

This is a secure ASP.NET Core Web API that allows users to register/login and perform CRUD operations on products. All protected endpoints require JWT authentication.

---

## ✅ Features

- User registration and login
- JWT authentication
- Role-based product access (if extended)
- Secure product management (CRUD)
- SQL Server as the database
- Swagger UI with token support for testing

---

### 1. Configure DB and JWT

Edit `appsettings.json`:

```json
"Jwt": {
  "Key": "ThisIsASecretKeyForJwtAuth123!",
  "Issuer": "yourdomain.com",
  "Audience": "yourdomain.com"
},
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\MSSQLLocalDB;Database=ProductDb;Trusted_Connection=True;"
}
```

### 2. Migrate and Create Database

Run in **Package Manager Console**:

```powershell
Add-Migration InitialCreate
Update-Database
```

---

## 🚀 Run the App

```bash
dotnet run
```

Visit Swagger UI at: `https://localhost:5001/swagger`

---

## 🔐 Using Authentication in Swagger

1. Use `/api/user/register` to create an account.
2. Use `/api/user/login` to receive a JWT token.
3. Click the **Authorize** button in Swagger.
4. Paste the token in this format:

```
Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
```

5. Now all `[Authorize]` endpoints will work.

---

## 📬 Endpoints Summary

### 🔓 Public

- `POST /api/user/register`
- `POST /api/user/login`

### 🔒 Secured (JWT required)

- `GET /api/product`
- `GET /api/product/{id}`
- `POST /api/product`
- `DELETE /api/product/{id}`


