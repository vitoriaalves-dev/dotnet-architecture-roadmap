Para esse primeiro caso de estudo, a arquitetura em camadas é suficiente para organizar o código e manter as responsabilidades bem definidas. No entanto, é importante reconhecer que, à medida que o sistema evolui, as camadas podem começar a se acoplar de maneiras indesejadas:

- Application depende de Infrastructure ❌
- Domain é passivo ❌
- Infra conhece Domain ❌
- Controllers conhecem Services concretos ❌

👉 Isso é NORMAL em arquitetura em camadas
👉 E é exatamente por isso que ela evolui para Hexagonal

O Próximo passo é entender como a arquitetura hexagonal resolve esses problemas, mantendo as camadas organizadas e as dependências apontando para dentro. Na próxima semana, vamos explorar os princípios da arquitetura hexagonal e como aplicá-la no nosso projeto.