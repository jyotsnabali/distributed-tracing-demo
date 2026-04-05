# distributed-tracing-demo
CPA demo for monitoring

## Overview

A 3-app distributed tracing demo built with .NET 8, designed to be deployed as three separate Azure App Services.

```
distributed-tracing-demo/
│
├── FrontendApi/          # App 1 – entry point (CPA hits this)
├── IntegrationApi/       # App 2 – MuleSoft stand-in
├── BackendApi/           # App 3 – backend processor
└── README.md
```

## Request Flow

```
CPA → FrontendApi → IntegrationApi → BackendApi
```

Each service calls the next one downstream via `HttpClient`. Application Insights automatically propagates trace context through the `traceparent` / `Request-Id` headers so all three hops appear as a single end-to-end transaction in the Application Map.

## Projects

### FrontendApi (App 1)
- Entry point that receives requests from CPA
- Calls `IntegrationApi /process` and returns `"Frontend processed request"`

### IntegrationApi (App 2)
- Acts as a MuleSoft stand-in
- Calls `BackendApi /process` and returns `"Integration processed request"`
- Uses `IHttpClientFactory` so Application Insights can inject trace headers automatically

### BackendApi (App 3)
- Terminal service; receives the trace and returns `"Backend processed request"`

## Deployment

Before deploying, replace the placeholder URLs in the controllers:

| File | Placeholder | Replace with |
|------|-------------|--------------|
| `FrontendApi/Controllers/ProcessController.cs` | `INTEGRATION-APP-NAME` | Your Integration App Service name |
| `IntegrationApi/Controllers/ProcessController.cs` | `BACKEND-APP-NAME` | Your Backend App Service name |

## Local Development

```bash
# Run each app in a separate terminal
dotnet run --project BackendApi      # http://localhost:5002
dotnet run --project IntegrationApi  # http://localhost:5001
dotnet run --project FrontendApi     # http://localhost:5000
```
