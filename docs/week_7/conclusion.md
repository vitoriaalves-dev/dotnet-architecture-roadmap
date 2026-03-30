# Semana 7 – Modelagem SQL

Nesta semana, o foco foi a persistência relacional,
tratando o banco de dados como detalhe de infraestrutura.

Decisões:
- SQL Server como banco relacional
- EF Core apenas na camada de infraestrutura
- Entidades do domínio reutilizadas, sem poluição por ORM
- Repositórios SQL implementando Ports