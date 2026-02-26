# 🛡️ Koperasi Tentera - Mobile Backend API

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=for-the-badge&logo=dotnet)
![SQL Server](https://img.shields.io/badge/SQL%20Server-EF%20Core-CC2927?style=for-the-badge&logo=microsoft-sql-server)
![Swagger](https://img.shields.io/badge/Swagger-OpenAPI-85EA2D?style=for-the-badge&logo=swagger)

Professional .NET Web API backend developed for the **Koperasi Tentera** mobile application onboarding. This project implements complex registration and migration flows with a focus on **SOLID principles**, **Clean Architecture**, and **Security**.

---

## 🚀 Key Features

* **Registration - New Customer**: Complete onboarding flow from basic details to PIN setup[cite: 1].
* **Migrate Existing User**: Specialized logic for legacy members to onboard to the modern mobile app[cite: 2].
* **Dual Verification**: Mock OTP logic supporting both Mobile and Email verification sequences.
* **Secure Authentication**: 6-Digit PIN setup with built-in validation for identity protection.
* **Robust Exception Handling**: Centralized Middleware to handle validation errors (Already Exists, Wrong OTP, etc.).
* **Biometric Ready**: Entity structure prepared for Biometric activation steps.

---

## 🛠 Tech Stack & Architecture

* **Framework**: ASP.NET Core Web API (.NET 10.0)
* **ORM**: Entity Framework Core (Database First/Code First)
* **Database**: Microsoft SQL Server
* **Design Patterns**: 
    * **Dependency Injection (DI)** for decoupled services.
    * **Service Pattern** to abstract business logic from controllers.
    * **DTOs (Data Transfer Objects)** for secure data exchange.
    * **Global Exception Handling Middleware**.

---

## 📖 How to Run the Project

### 1. Database Configuration
1.  Open **SQL Server Management Studio (SSMS)**.
2.  Create a database named `KoperasiTenteraDb`.
3.  Ensure your `appsettings.json` connection string matches your local server:
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=KoperasiTenteraDb;Trusted_Connection=True;TrustServerCertificate=True;"
    }
    ```

### 2. Execution
1.  Open the solution (`.slnx`) in **Visual Studio**.
2.  Build the project (`Ctrl + Shift + B`).
3.  Press **F5** to run.
4.  Navigate to `/swagger` to access the interactive API documentation.

---

## 📑 API Documentation (Endpoints)

| Endpoint | Method | Description |
| :--- | :--- | :--- |
| `GET /api/Registration/status/{ic}` | GET | Initial check to route user to New vs Migrated flow. |
| `POST /api/Registration/register-details` | POST | [cite_start]Saves Step 1 info (Full Name, Mobile, Email)[cite: 1]. |
| `POST /api/Registration/generate-otp` | POST | Generates a Mock OTP (`1234`) for development testing. |
| `POST /api/Registration/verify-otp` | POST | Validates the OTP code and tracks registration progress. |
| `POST /api/Registration/finalize-registration` | POST | [cite_start]Accepts Privacy Terms and sets the 6-digit Security PIN. |

---

## 🛡️ Standardized Error Responses
For a seamless frontend experience, all validation errors return a consistent JSON body:

```json
{
  "success": false,
  "message": "Account already exists. Please login."
}
