# Semana 8 — NoSQL (MongoDB) aplicado com propósito

## Objetivo

O objetivo desta semana foi introduzir um banco NoSQL no sistema
de forma **criteriosa e arquitetural**, sem substituir o banco relacional.

O foco não foi a tecnologia em si, mas **quando e por que usar NoSQL**.

---

## Motivação

Bancos relacionais são excelentes para:
- escrita transacional
- integridade referencial
- consistência forte

Porém, eles **não são ideais para todos os cenários**,
especialmente quando há:
- muitas leituras
- consultas orientadas a relatório
- necessidade de dados prontos para consumo

Diante disso, foi adotada uma abordagem híbrida:
- SQL Server como fonte de verdade
- MongoDB como modelo de leitura (read model)

---

## Decisão Arquitetural

Foi aplicada uma variação simples de **CQRS**:

- **Write Model**  
  - SQL Server  
  - EF Core  
  - Dados normalizados  

- **Read Model**  
  - MongoDB  
  - Documentos denormalizados  
  - Otimizado para leitura  

Essa separação foi possível sem impacto no core do sistema
graças à **Arquitetura Hexagonal**.

---

## Papel do MongoDB no sistema

O MongoDB foi utilizado exclusivamente para armazenar
**relatórios de pedidos**, com as seguintes características:

- dados consolidados
- estrutura pronta para leitura
- ausência de joins
- sem necessidade de transações complexas

O documento armazenado representa uma projeção do pedido,
não uma entidade de domínio.

---

## Modelo do Documento

Exemplo de documento salvo no MongoDB:

```json
{
  "_id": "order-id",
  "createdAt": "2026-03-01T10:00:00Z",
  "totalItems": 3,
  "items": [
    { "productId": "1", "quantity": 2 },
    { "productId": "2", "quantity": 1 }
  ]
}