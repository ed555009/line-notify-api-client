# Line.Notify.Api.Client

[![GitHub](https://img.shields.io/github/license/ed555009/line-notify-api-client)](LICENSE)
![Build Status](https://dev.azure.com/edwang/github/_apis/build/status/line-notify-api-client?branchName=master)
[![Nuget](https://img.shields.io/nuget/v/Line.Notify.Api.Client)](https://www.nuget.org/packages/Line.Notify.Api.Client)

![Coverage](https://sonarcloud.io/api/project_badges/measure?project=line-notify-api-client&metric=coverage)
![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=line-notify-api-client&metric=alert_status)
![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=line-notify-api-client&metric=reliability_rating)
![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=line-notify-api-client&metric=security_rating)
![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=line-notify-api-client&metric=vulnerabilities)

## Description

This is a .NET6 library for interacting with the [LINE Notify Api](https://notify-bot.line.me/en/).

## Quick start

### Installation

```bash
dotnet add package Line.Notify.Api.Client
```

### Appsettings.json

```json
{
	"Line": {
		"Notify": {
			"BaseUrl": "https://notify-api.line.me",
			"AuthToken": "YOUR_LINE_AUTH_TOKEN"
		}
	}
}
```

### Add services

```csharp
using Line.Notify.Api.Client.Extensions;

ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
	// this injects as SINGLETON
	services.AddLineNotifyApiServices(configuration);

	// you can also inject as SCOPED or TRANSIENT by specifying the ServiceLifetime
	services.AddLineNotifyApiServices(configuration, ServiceLifetime.Scoped);
}
```

### Using services

```csharp
using Line.Notify.Api.Client.Interfaces;
using Line.Notify.Api.Client.Services;
using Line.Notify.Api.Client.Models.Requests;

public class MyProcess
{
	private readonly INotifyService _notifyService;

	public MyProcess(INotifyService notifyService) =>
		_notifyService = notifyService;

	public async Task NotifyAsync()
	{
		var result = await _notifyService.NotifyAsync(new MessageModel
		{
			Message = "Test message"
		});
	}
}
```

## Reference

- [LINE Notify API Document](https://notify-bot.line.me/doc/en/)
