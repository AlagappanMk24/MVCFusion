MVCFushion 🚀
  
Welcome to MVCFushion, a cutting-edge ASP.NET Core solution showcasing modular, scalable projects built with clean architecture. This repository hosts the Redis Cache Demo and URL Shortener projects, each delivering a modern, responsive user experience with a sleek gradient UI. Dive in to explore high-performance caching with Redis or efficient URL shortening! 🌟

📑 Table of Contents

Redis Cache Demo 🔧
Features ✨
Real-World Example 📋
How It Works 🔄


Projects Overview 📚
Architecture 🏛️
Technologies 🛠️
Setup Instructions ⚙️
Usage 🎮
Project Structure 📂
Contributing 🤝
License 📜


Redis Cache Demo 🔧
The Redis Cache Demo is a powerful ASP.NET Core MVC application that harnesses Redis for lightning-fast caching of key-value pairs. With a modern, card-based UI featuring a gradient header, it’s both functional and visually stunning, making it easy to manage cached data. Perfect for developers looking to boost performance with in-memory storage! 💾
Features ✨

Store Key-Value Pairs: Cache data in Redis with a 1-hour TTL for efficient storage. 🕒
Retrieve Values: Fetch cached values by key with hit tracking. 🔍
Delete Keys: Remove keys from the cache with a single click. 🗑️
View All Entries: See all cached entries in a responsive table with creation times and hit counts. 📊
Sleek UI: Built with Bootstrap 5, featuring gradient headers, card-based forms, and hover effects. 🎨
Clean Architecture: Organized into Domain, Application, Infrastructure, and Web layers for scalability. 🏗️

Real-World Example 📋
Imagine you're running a website where users log in, and you need to store their session tokens for quick access. Here’s a sample payload from TestPayloads.txt:

Key: session:abc123
Value: eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9 (a JWT token for a user’s session)

The Redis Cache Demo lets you:

Store the session token in Redis for fast access during user requests.
Retrieve the token to verify login status.
Delete the token when the user logs out.
Track how often the token is accessed for analytics.

How It Works 🔄
The Redis Cache Demo uses Redis for high-speed, in-memory caching and SQLite to log metadata like hit counts. Here’s the flow using the session:abc123 payload:

Launch the App 🚀  

Visit https://localhost:5002 to see a modern interface with forms and a table.
The app connects to Redis (localhost:6379) and SQLite (redisdemo.db).


Store a Key-Value Pair 💾  

Enter session:abc123 (key) and eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9 (value) in the "Store" form.  
Click "Store." The app saves the pair in Redis (1-hour expiration) and logs metadata in SQLite.  
A success message appears: "Stored key 'session:abc123' successfully."  
The table updates:  Key: session:abc123 | Value: eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9 | Created At: 7/2/2025 4:27 PM | Hits: 0




Retrieve a Value 🔍  

Enter session:abc123 in the "Retrieve" form and click "Retrieve."  
The app fetches the value from Redis, increments the hit count in SQLite, and shows: "Retrieved value: eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9."  
The table updates:  Key: session:abc123 | Value: eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9 | Created At: 7/2/2025 4:27 PM | Hits: 1




Delete a Key 🗑️  

Enter session:abc123 in the "Delete" form and click "Delete."  
The app removes the key from Redis and SQLite, showing: "Deleted key 'session:abc123' successfully."  
The table removes the entry.


Automatic Expiration ⏳  

Redis deletes keys after 1 hour (e.g., by 5:27 PM).  
SQLite retains metadata until manually deleted via the UI.


View All Entries 📊  

The table shows all cached keys, values, creation times, and hit counts, updating after each action.



Why Redis? It’s blazing fast for temporary data like session tokens, reducing database load and speeding up your app! ⚡

Projects Overview 📚

RedisCacheDemo 🔧: Manages key-value pairs with Redis caching at https://localhost:5002.
UrlShortener 🔗: Shortens URLs with click tracking at https://localhost:5001.
Shared 🎨: Shared CSS/JS for consistent, modern UI across projects.

Each project is independent, modular, and part of the MVCFushion solution for seamless organization.

Architecture 🏛️
The Redis Cache Demo follows clean architecture for maintainability:

Domain 📋: Core entities (e.g., CacheEntry) with no dependencies.
Application ⚙️: Business logic, services, and DTOs for caching operations.
Infrastructure 💾: Redis and SQLite data access.
Web 🌐: MVC controllers, views, and a responsive UI.

This structure ensures scalability and ease of adding new features or projects.

Technologies 🛠️

ASP.NET Core MVC 8.0 🌐: Robust web framework.
StackExchange.Redis 🔗: High-performance Redis client.
Entity Framework Core 💿: ORM for SQLite metadata.
SQLite 📂: Lightweight database for metadata.
Bootstrap 5 🎨: Modern, responsive UI framework.
.NET 8.0 🚀: High-performance runtime.
C# 12 💻: Modern programming features.


Setup Instructions ⚙️
Prerequisites

.NET 8.0 SDK 📦: Download
Redis Server 🔴: Running on localhost:6379
Windows: Use Redis Windows port or WSL.
Linux/macOS: sudo apt-get install redis-server or brew install redis.


SQLite 💾: Included with EF Core.
Git 🗃️: For cloning the repository.
IDE: Visual Studio 2022 or any compatible IDE.

Steps

Clone the Repository 📥:
git clone https://github.com/yourusername/MVCFushion.git
cd MVCFushion


Start Redis 🔴:
redis-server

Update RedisConnection in RedisCacheDemo.Web/appsettings.json if using a different Redis server.

Restore Dependencies 📦:
dotnet restore MVCFushion.sln


Set Up SQLite Database 💾:
cd RedisCacheDemo.Infrastructure
dotnet ef migrations add InitialCreate
dotnet ef database update

This creates redisdemo.db for metadata.

Run the Redis Cache Demo 🚀:
cd ../RedisCacheDemo.Web
dotnet run

Open https://localhost:5002.

(Optional) Run URL Shortener 🔗:
cd ../UrlShortener.Web
dotnet run

Open https://localhost:5001.



Usage 🎮

Access the Redis Cache Demo 🌐:

Visit https://localhost:5002 to see the sleek UI with forms and a table.
Use forms to store, retrieve, or delete key-value pairs.


Test with Sample Payloads 📋:

Use TestPayloads.txt for testing:
session:abc123:eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9
key1:Hello World
config:theme:dark


Store session:abc123, retrieve it, and delete it to explore the workflow.



Monitor Cache Activity 📊:

The table displays keys, values, creation times, and hit counts.
Success/error messages animate after each action for a polished experience.




Project Structure 📂
MVCFushion/
├── RedisCacheDemo.Domain/         🧩 Core entities (CacheEntry)
├── RedisCacheDemo.Application/    ⚙️ Business logic and services
├── RedisCacheDemo.Infrastructure/ 💾 Redis and SQLite data access
├── RedisCacheDemo.Web/           🌐 MVC controllers, views, UI
├── UrlShortener.Domain/           🧩 URL Shortener entities
├── UrlShortener.Application/      ⚙️ URL Shortener logic
├── UrlShortener.Infrastructure/   💾 URL Shortener data access
├── UrlShortener.Web/             🌐 URL Shortener MVC app
├── Shared/                       🎨 Shared CSS/JS for UI consistency
├── MVCFushion.sln                📄 Solution file
├── README.md                     📖 This file
├── LICENSE                       📜 MIT License
└── .gitignore                    🚫 Excludes build artifacts and databases


Contributing 🤝
We’d love your contributions to make MVCFushion even better! 🌟

Fork the repository 🍴.
Create a feature branch: git checkout -b feature/YourFeature 🌱.
Commit changes: git commit -m 'Add YourFeature' ✅.
Push to the branch: git push origin feature/YourFeature 🚀.
Open a pull request with a clear description 📝.

Follow coding standards and include tests for new features.

License 📜
This project is licensed under the MIT License. See the LICENSE file for details.

Built with passion for high-performance, scalable web solutions! 🚀Questions or feedback? Reach out via GitHub Issues! 😊
