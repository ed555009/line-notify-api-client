using System.Text;
using System.Text.Json;
using Line.Notify.Api.Client.Extensions;
using Line.Notify.Api.Client.Interfaces;
using Line.Notify.Api.Client.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace Line.Notify.Api.Client.Tests;

public class ServicesExtensionTests : BaseServiceTests
{
	private readonly string _settings;

	public ServicesExtensionTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
	{
		_settings = JsonSerializer.Serialize(new
		{
			Line = new
			{
				Notify = new
				{
					NotifyApiConfig.BaseUrl,
					NotifyApiConfig.AuthToken
				}
			}
		});
	}

	[Fact]
	public void AddLineNotifyApiServices_ShouldSucceed()
	{
		// Given
		var services = new ServiceCollection();
		var builder = new ConfigurationBuilder();
		var configuration = builder.AddJsonStream(new MemoryStream(Encoding.UTF8.GetBytes(_settings))).Build();

		// When
		ServicesExtensions.AddLineNotifyApiServices(services, configuration);

		// Then
		Assert.Contains(services, x => x.ServiceType == typeof(INotifyApi));

		Assert.Contains(services, x => x.ServiceType == typeof(INotifyService)
								 && x.ImplementationType == typeof(NotifyService));
	}
}
