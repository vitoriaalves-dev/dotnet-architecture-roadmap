No projeto, foram criadas as pastas com essas nomenclaturas para organizar os arquivos de acordo com a arquitetura hexagonal e ficar
didaticamente visivel. Mas em um projeto real, as estruturas são bem mais 'limpas' e não são usadas essas nomenclaturas, mas sim pastas como 'Controllers', 'Services', 'Repositories', etc. O importante é entender o conceito de separação de responsabilidades e dependências, e não a nomenclatura ou estrutura exata das pastas.

Em um sistema real a estrutura poderia ser algo como:

    EcommerceApp
    ├── Api
    │   └── Controllers
    ├── Application
    │   ├── Interfaces
    │   └── Services
    ├── Domain
    │   └── Entities
    ├── Infrastructure
    │   └── Repositories

    Arquitetura hexagonal ✔️
    Nomes limpos ✔️
    Sem overengineering ✔️

🧠 Regra de ouro
    Arquitetura é sobre dependências, não sobre pastas.