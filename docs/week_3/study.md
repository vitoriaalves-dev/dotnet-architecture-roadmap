# Semana 3 – Design Patterns

## Strategy
O padrão Strategy permite definir uma família de algoritmos,
encapsulá-los e torná-los intercambiáveis.

No contexto de notificações:
- Cada tipo de envio (Email, SMS, Push) é uma estratégia
- O código cliente não precisa conhecer a implementação

## Factory
O padrão Factory centraliza a criação de objetos,
evitando que o código cliente dependa de classes concretas.

Combinado com Strategy:
- A Factory decide qual estratégia criar
- O Service apenas usa a abstração