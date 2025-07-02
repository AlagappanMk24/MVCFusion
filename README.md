# 🚀 MVCFusion

Welcome to **MVCFusion**, a modular ASP.NET Core solution built with **Clean Architecture** principles.  
This repository includes various powerful projects:

- 🧠 **Redis Cache** – Lightning-fast key-value caching using Redis.
- 🔗 **URL Shortener** – A robust service to shorten and track links.

All are designed for **scalability**, **maintainability**, and **modern UX/UI**.

---

## 📚 Table of Contents

- [🔴 Redis Cache](#-redis-cache)
  - 🚀 Features
  - 🌍 Real-World Example
  - ⚙️ How It Works
- [📦 Projects Overview](#-projects-overview)
- [🏛️ Architecture](#-architecture)
- [🛠️ Technologies](#-technologies)
- [⚙️ Setup Instructions](#-setup-instructions)
- [🧪 Usage](#-usage)
- [📁 Project Structure](#-project-structure)
- [🤝 Contributing](#-contributing)
- [📄 License](#-license)

---

## 🔴 Redis Cache

An ASP.NET Core MVC application demonstrating how to integrate Redis for caching with an intuitive UI and rich metadata tracking.

### 🚀 Features

✅ Store key-value pairs with 1-hour TTL  
🔍 Retrieve cached values with hit tracking  
❌ Delete individual keys  
📋 View all entries in a responsive table  
✨ Modern Bootstrap 5 UI with gradient header and card layout  
🏗️ Clean architecture using Domain, Application, Infrastructure, and Web layers  

---

### 🌍 Real-World Example

Storing session tokens? No problem!

```txt
Key:    session:abc123  
Value:  eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9

🔐 Use case:

Store JWT token in Redis for quick access

Retrieve it to verify login

Delete when user logs out

Track hits for analytics

⚙️ How It Works
🧩 The app uses Redis for in-memory storage and SQLite for tracking metadata (e.g., hit count). Example flow:

🟢 Start the App
Open: https://localhost:5002

💾 Store
Input key and value → Click "Store" → Stored in Redis with 1-hour TTL and metadata in SQLite.

📥 Retrieve
Input key → Click "Retrieve" → Value fetched, hit count updated.

🗑️ Delete
Input key → Click "Delete" → Key removed from both Redis & SQLite.

⏳ Automatic Expiry
Redis auto-removes keys after TTL; SQLite keeps metadata until manually deleted.

📊 View All Entries
Table displays: Key | Value | Created At | Hit Count

📦 Projects Overview

Project	Description	URL
🧠 RedisCacheDemo	Redis-based key-value management with metadata	https://localhost:5002
🔗 UrlShortener	URL shortening service with analytics	https://localhost:5001
💡 Shared	Common styles/scripts across the projects	–

Each project is self-contained and follows the same clean architecture principles.

🏛️ Architecture

📂 Clean Architecture layers:

Domain 🧬 – Core entities (e.g., CacheEntry)

Application ⚙️ – Business logic and DTOs

Infrastructure 🧱 – Redis + SQLite data access

Web 🌐 – MVC UI, controllers, and views

Benefits: ✅ Modularity ✅ Scalability ✅ Easy to extend

🛠️ Technologies

💻 ASP.NET Core MVC 8.0

🧠 Redis via StackExchange.Redis

🗃️ SQLServer with Entity Framework Core

🎨 Bootstrap 5

🧰 .NET 8.0, C# 12

⚙️ Setup Instructions

📋 Prerequisites

.NET 8.0 SDK
Redis Server (default: localhost:6379)
Windows: Redis port for Windows / WSL

Linux/macOS: sudo apt install redis / brew install redis

Git + IDE (e.g., Visual Studio 2022)

SQLServer (comes with EF Core)

🔧 Steps
📥 Clone Repo

git clone https://github.com/yourusername/MVCFushion.git
cd MVCFushion

▶️ Start Redis

bash
Copy
Edit
redis-server
(Ensure Redis is running at localhost:6379, or edit appsettings.json.)

🔁 Restore Dependencies

dotnet restore MVCFushion.sln
🗃️ Setup SQLServer

cd RedisCacheDemo.Infrastructure
dotnet ef migrations add InitialCreate
dotnet ef database update
🚀 Run Redis Cache Demo

cd ../RedisCacheDemo.Web
dotnet run
📍 Navigate to: https://localhost:5002

(Optional) Run URL Shortener

cd ../UrlShortener.Web
dotnet run
📍 Navigate to: https://localhost:5001

🧪 Usage
📥 Access the App

Go to https://localhost:5002
Use the forms to Store ➡️ Retrieve ➡️ Delete keys

🧾 Test Payloads (TestPayloads.txt)

session:abc123:eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9
key1:Hello World
config:theme:dark

📈 Monitor Cache Activity

View keys, values, timestamps, and hit counts in a responsive table.
🎉 Success/failure messages appear after each action.

📁 Project Structure

MVCFushion/
├── RedisCacheDemo.Domain/         
├── RedisCacheDemo.Application/    
├── RedisCacheDemo.Infrastructure/
├── RedisCacheDemo.Web/           
├── UrlShortener.Domain/
├── UrlShortener.Application/
├── UrlShortener.Infrastructure/
├── UrlShortener.Web/
├── Shared/                      
├── MVCFushion.sln                 
├── README.md                 
├── LICENSE                      
└── .gitignore                   

🤝 Contributing
We welcome contributions! 🚀

Fork the repo

Create a branch: git checkout -b feature/YourFeature

Commit: git commit -m "Add YourFeature"

Push: git push origin feature/YourFeature

Open a Pull Request 🛠️

Please follow coding standards & include relevant tests.
