```mermaid
---
title: Deposit Workflow
---
flowchart TD
    A([START]) --> B[/Deposit Request/]
    B --> C[Locate Account]
    C --> D[Validate Deposit]
    D --> E[Calculate New Balance]
    E --> F[Update Account Balance]
    F --> G[Record Transaction]
    G --> H[Logs the User's action]
    H --> I[Return the updated balance]
    I --> J([END])
```