# 🍔 Food Delivery REST API Backend

A scalable, secure backend API for a Food Delivery application built with **ASP.NET Core 8.0**, **PostgreSQL**, and **Entity Framework Core**.

## 🛠️ Tech Stack & Tools
- **Framework:** ASP.NET Core 8.0 Web API
- **Database:** PostgreSQL
- **ORM:** Entity Framework Core (Code-First)
- **Security:** JWT (JSON Web Tokens) & BCrypt Password Hashing
- **Documentation & Testing:** Swagger UI & Postman

## 🚀 Features
- **User Authentication:** Role-based registration & login (`Admin`, `Customer`, `RestaurantOwner`).
- **Restaurant Management:** Endpoint to manage restaurants and menu items.
- **Order Placement:** Automated cart total calculation fetching real item prices server-side.
- **Database Indexing:** Optimized indexing on foreign keys and user lookup fields for fast querying.

## 📡 Key API Endpoints

| Method | Endpoint | Description | Auth Required |
| :--- | :--- | :--- | :--- |
| `POST` | `/api/Auth/register` | Register a new user | No |
| `POST` | `/api/Auth/login` | Login and receive JWT token | No |
| `GET` | `/api/Restaurants` | Get all restaurants & menus | No |
| `POST` | `/api/Restaurants` | Add a restaurant | Admin |
| `POST` | `/api/Orders` | Place a food order | Customer |
| `GET` | `/api/Orders/my-orders` | Get logged-in user order history | Customer |

## ⚙️ How to Run Locally

1. **Clone the repository:**
   ```bash
   git clone [https://github.com/jayasivakumar/food-delivery-backend-dotnet.git](https://github.com/jayasivakumar/food-delivery-backend-dotnet.git)
   cd food-delivery-backend-dotnet
