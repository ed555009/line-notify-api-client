using System.Net;
using Line.Notify.Api.Client.Configs;
using Line.Notify.Api.Client.Interfaces;
using Refit;
using Xunit.Abstractions;

namespace Line.Notify.Api.Client.Tests;

public abstract class BaseServiceTests
{
	protected readonly ITestOutputHelper TestOutputHelper;
	protected readonly NotifyApiConfig NotifyApiConfig;

	public BaseServiceTests(ITestOutputHelper testOutputHelper)
	{
		TestOutputHelper = testOutputHelper;
		NotifyApiConfig = new NotifyApiConfig
		{
			BaseUrl = "http://localhost:5000",
			AuthToken = "MyToken"
		};
	}

	protected static Task<ApiResponse<T>> CreateResponse<T>(HttpStatusCode statusCode) where T : IBaseResponseModel =>
		Task.FromResult(new ApiResponse<T>(
			new HttpResponseMessage(statusCode),
			default,
			new RefitSettings()));

	protected static Task<ApiResponse<object?>> CreateEmptyResponse(HttpStatusCode statusCode) =>
		Task.FromResult(new ApiResponse<object?>(
			new HttpResponseMessage(statusCode),
			default,
			new RefitSettings()));
}
