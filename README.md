# DockerDB
(api + postgres + pgAdmin) in Docker

```
    ┌────────┐   ┌─────────┐    ┌──────────┐   ┌─────────┐ 
    │        │   │         │    │          │   │         │
    │ C# WEB ├──►│ C# API  ├────┤ Postgres │◄──┤ pgAdmin │
    │        │   │         │    │          │   │         │
    └────────┘   └─────────┘    └──────────┘   └─────────┘
                      ▲
 ┌───────────┐        │
 │Other users│────────┘
 └───────────┘
```

единственная проблема нужно создать sript-migration и выполнить его через pgAdmin или pgsql

apiClient сгенерировать NSwagStudio
