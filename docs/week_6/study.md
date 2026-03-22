-> Tipos de estruturas de pastas em projetos reais:

🟢 Estrutura MAIS comum em projetos reais (Hexagonal pragmática)
Opção 1️⃣ — Hexagonal “disfarçada” (a mais usada)

EcommerceApp
├── Api
│   └── Controllers
├── Application
│   ├── Interfaces
│   └── Services
├── Domain
│   ├── Entities
│   └── ValueObjects
├── Infrastructure
│   ├── Persistence
│   └── Repositories
└── Program.cs

Como isso mapeia para Hexagonal
    Conceito	                    Onde fica
    Ports (In/Out)	            Application/Interfaces
    Inbound Adapters	        Api/Controllers
    Outbound Adapters	        Infrastructure/*
    Core (Domain + Use cases)	Domain + Application

👉 Arquitetura existe, mas não “grita”.

🟢 Estrutura MUITO usada em empresas .NET

src
├── Ecommerce.Api
├── Ecommerce.Application
├── Ecommerce.Domain
├── Ecommerce.Infrastructure

Cada projeto é um assembly diferente.

🟡 Estrutura orientada a features (mais moderna)

Muito comum em sistemas grandes:

EcommerceApp
├── Products
│   ├── ProductController.cs
│   ├── ProductService.cs
│   ├── IProductRepository.cs
│   └── Product.cs
├── Orders
│   ├── OrderController.cs
│   ├── OrderService.cs
│   ├── IOrderRepository.cs
│   └── Order.cs
└── Program.cs

🔹 Internamente, cada feature respeita hexagonal
🔹 Externamente, o código fica muito navegável