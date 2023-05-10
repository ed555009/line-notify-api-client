using Line.Notify.Api.Client.Configs;
using Line.Notify.Api.Client.Interfaces;
using Line.Notify.Api.Client.Models.Requests;
using Line.Notify.Api.Client.Models.Responses;
using Refit;

namespace Line.Notify.Api.Client.Services;

public class NotifyService : INotifyService
{
	private readonly INotifyApi _notifyApi;
	private readonly NotifyApiConfig _notifyApiConfig;

	public NotifyService(INotifyApi notifyApi, NotifyApiConfig notifyApiConfig)
	{
		_notifyApi = notifyApi;
		_notifyApiConfig = notifyApiConfig;
	}

	public async Task<ApiResponse<NotifyModel>> NotifyAsync(MessageModel data, string? authToken = null) =>
		await _notifyApi.NotifyAsync(authToken ?? _notifyApiConfig.AuthToken, data);

	public async Task<ApiResponse<RevokeModel>> RevokeAsync(string? authToken = null) =>
		await _notifyApi.RevokeAsync(authToken ?? _notifyApiConfig.AuthToken);

	public async Task<ApiResponse<StatusModel>> StatusAsync(string? authToken = null) =>
		await _notifyApi.StatusAsync(authToken ?? _notifyApiConfig.AuthToken);
}
