🏗️ Responsabilidade de cada camada

🟦 Controllers (Apresentação)
    - Receber HTTP: Porta de entrada para as requisições do usuário.
    - Retornar HTTP: Formata a resposta (Status Code, JSON).
⚠️ Regra de Ouro: NUNCA deve conter regras de negócio.

🟩 Application
    - Orquestração: Gerencia o fluxo dos casos de uso.
    - Uso do Domínio: Chama as entidades e serviços necessários.
    - Decisão: Define "o que acontece" no processo, mas não "como" a regra de negócio funciona internamente.

🟨 Domain
    - Entidades: Objetos que representam o coração do sistema.
    - Regras de Negócio Puras: Onde a lógica real reside.
    - Isolamento: Não deve possuir dependências de frameworks ou bibliotecas externas.

🟥 Infrastructure
    - Persistência: Onde os dados são salvos (mesmo que em memória por enquanto).
    - Detalhes Técnicos: Conexões com banco de dados, envio de e-mail, logs.
    - Implementações Concretas: O "trabalho sujo" e as ferramentas que dão suporte ao sistema.

Dica: Mantenha as dependências sempre apontando para dentro (em direção ao Domain). O Domínio nunca deve saber que o Banco de Dados ou o Controller existem.