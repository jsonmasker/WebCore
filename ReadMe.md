Intro Link: https://github.com/thannong123zero/WebCore_V2

# WebCore V2 🚀

A comprehensive, enterprise-ready web application framework built with .NET 9 and Angular 20, designed for rapid development of modern web applications with built-in enterprise features.

## 🏗️ Architecture Overview

WebCore V2 follows a clean, layered architecture pattern with clear separation of concerns:

```
📁 WebCore/
├── 🖥️ WebCore.Server/          # ASP.NET Core Web API
├── 🌐 webcore.client/          # Angular 20 Frontend
├── 🧠 BusinessLogic/            # Business Logic Layer
├── 📊 DataAccess/               # Entity Framework Data Layer
└── 🔧 Common/                   # Shared Components & Services
```

## ✨ Key Features

### 🔐 Authentication & Security
- **JWT Token Authentication** with configurable expiration
- **ASP.NET Core Identity** integration
- **Role-based Authorization** system
- **API Key Authentication** support
- **CORS Configuration** for cross-origin requests

### 📧 Communication Services
- **Email Services** with MailKit integration
- **SMS Services** for notifications
- **File Attachment Support** for emails
- **Template-based Email System**

### 📊 Data Management
- **Entity Framework Core** with SQL Server
- **MongoDB Integration** for logging and analytics
- **Unit of Work Pattern** implementation
- **Repository Pattern** for data access
- **AutoMapper** for object mapping

### 🔧 Utility Services
- **QR Code Generation** services
- **Word to PDF Conversion** capabilities
- **File Storage Services** for document management
- **Action Logging** with MongoDB
- **Excel Processing** with EPPlus

### 🌍 Localization & Internationalization
- **Multi-language Support** with resource files
- **Province/Location Data** management
- **Configurable Localization** settings

### 📱 Modern Frontend
- **Angular 20** with latest features
- **CoreUI Framework** for professional UI components
- **Chart.js Integration** for data visualization
- **JWT Token Management** in frontend
- **Ng-Zorro (Ant Design)** components
- **Responsive Design** with modern UX

## 🛠️ Technology Stack

### Backend (.NET 9)
- **Framework**: ASP.NET Core 9.0
- **Database**: SQL Server with Entity Framework Core
- **Authentication**: JWT Bearer + ASP.NET Core Identity
- **Documentation**: OpenAPI/Swagger
- **Email**: MailKit
- **File Processing**: EPPlus, SkiaSharp
- **Logging**: MongoDB Driver
- **Templates**: RazorEngineCore

### Frontend (Angular 20)
- **Framework**: Angular 20.1.3
- **UI Framework**: CoreUI 5.5.5
- **Charts**: Chart.js 4.4.9
- **Icons**: CoreUI Icons
- **Additional UI**: Ng-Zorro Ant Design
- **HTTP Client**: Angular HTTP with JWT integration

## 🚀 Getting Started

### Prerequisites
- .NET 9 SDK
- Node.js 18+ and npm
- SQL Server (or SQL Server Express)
- MongoDB (for logging features)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/thannong123zero/WebCore_V2.git
   cd WebCore_V2
   ```

2. **Configure Database Connection**
   Update `appsettings.json` in `WebCore.Server`:
   ```json
   {
     "ConnectionStrings": {
       "SqlConnection": "Your SQL Server Connection String"
     },
     "UserActionLogging": {
       "ConnectionString": "mongodb://localhost:27017",
       "DatabaseName": "WebCoreDatabase"
     }
   }
   ```

3. **Install Backend Dependencies**
   ```bash
   dotnet restore
   ```

4. **Install Frontend Dependencies**
   ```bash
   cd webcore.client
   npm install
   ```

5. **Run Database Migrations**
   ```bash
   dotnet ef database update --project DataAccess --startup-project WebCore.Server
   ```

6. **Start the Application**
   ```bash
   # Start backend (from root directory)
   dotnet run --project WebCore.Server
   
   # Start frontend (in separate terminal)
   cd webcore.client
   npm start
   ```

## 📋 Configuration

### Application Settings
Configure your application through `appsettings.json`:

```json
{
  "AppConfig": {
    "ServerUrl": "https://localhost:7154",
    "ClientUrl": "https://localhost:50567",
    "PythonServiceUrl": "http://localhost:8000"
  },
  "Key": "your-jwt-secret-key",
  "Issuer": "Server",
  "Audience": "Client",
  "ExpiredTime": 5
}
```

### Email Configuration
```json
{
  "DisplayName": "Your App Name",
  "From": "noreply@yourapp.com",
  "Host": "smtp.gmail.com",
  "Port": 587,
  "UseSSL": true
}
```

## 🏗️ Project Structure

### Backend Layers

#### **Common Layer**
- Shared models, constants, and configurations
- Reusable services (Email, SMS, File Storage, QR Code)
- Custom attributes and extensions
- ViewModels and DTOs

#### **DataAccess Layer**
- Entity Framework DbContext
- Repository pattern implementation
- Unit of Work pattern
- Database configurations
- Entity DTOs

#### **BusinessLogic Layer**
- Business rules and logic
- Service interfaces and implementations
- Helper classes for various features
- Application-specific operations

#### **WebCore.Server**
- REST API controllers
- Authentication and authorization
- Swagger documentation
- Startup configuration

### Frontend Structure
- **Components**: Reusable UI components
- **Services**: HTTP services and business logic
- **Guards**: Route protection and authentication
- **Models**: TypeScript interfaces and models
- **Modules**: Feature-based module organization

## 🔌 API Features

### Core Endpoints
- **Authentication**: `/api/auth/*` - Login, register, token refresh
- **User Management**: `/api/users/*` - User CRUD operations
- **File Management**: `/api/files/*` - Upload, download, storage
- **QR Codes**: `/api/qr/*` - QR code generation and management
- **Email**: `/api/email/*` - Email sending and templates

### API Documentation
Access Swagger documentation at: `https://localhost:7154/swagger`

## 🧪 Testing

```bash
# Run backend tests
dotnet test

# Run frontend tests
cd webcore.client
npm test
```

## 📦 Deployment

### Production Build
```bash
# Build backend
dotnet publish -c Release -o ./publish

# Build frontend
cd webcore.client
npm run build
```

### Docker Support
The application is ready for containerization with Docker for easy deployment.

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📝 License

This project is licensed under the MIT License - see the LICENSE file for details.

## 📞 Support

For support and questions:
- Create an issue on GitHub
- Contact: jsonmasker@gmail.com

---

**WebCore V2** - Building modern web applications with enterprise-grade features and developer-friendly architecture. 🚀
