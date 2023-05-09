using System.Net;
using Line.Notify.Api.Client.Configs;
using Line.Notify.Api.Client.Interfaces;
using Line.Notify.Api.Client.Services;
using Moq;
using Xunit.Abstractions;
using RequestModel = Line.Notify.Api.Client.Models.Requests;
using ResponseModel = Line.Notify.Api.Client.Models.Responses;

namespace Line.Notify.Api.Client.Tests;

public class NotifyServiceTests : BaseServiceTests
{
	private readonly Mock<INotifyApi> _notifyApiMock;
	private readonly Mock<NotifyApiConfig> _notifyApiConfigMock;
	private readonly INotifyService _notifyService;

	public NotifyServiceTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
	{
		_notifyApiMock = new Mock<INotifyApi>();
		_notifyApiConfigMock = new Mock<NotifyApiConfig>();
		_notifyService = new NotifyService(_notifyApiMock.Object, _notifyApiConfigMock.Object);
	}

	[Fact]
	public async void NotifyAsync_ShouldSucceedAsync()
	{
		// Given
		_ = _notifyApiMock
			.Setup(x => x.NotifyAsync(It.IsAny<string>(), It.IsAny<RequestModel.MessageModel>()))
			.Returns(CreateResponse<ResponseModel.NotifyModel>(HttpStatusCode.OK));

		// When
		var result = await _notifyService.NotifyAsync(new RequestModel.MessageModel
		{
			Message = "Test message"
		});

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async void StatusAsync_ShouldSucceed()
	{
		// Given
		_ = _notifyApiMock.Setup(x => x.StatusAsync(It.IsAny<string>()))
			.Returns(CreateResponse<ResponseModel.StatusModel>(HttpStatusCode.OK));

		// When
		var result = await _notifyService.StatusAsync();

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async void RevokeAsync_ShouldSucceed()
	{
		// Given
		_ = _notifyApiMock.Setup(x => x.RevokeAsync(It.IsAny<string>()))
			.Returns(CreateResponse<ResponseModel.RevokeModel>(HttpStatusCode.OK));

		// When
		var result = await _notifyService.RevokeAsync();

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}
}
