using Line.Notify.Api.Client.Models.Requests;
using Refit;
using ResponseModel = Line.Notify.Api.Client.Models.Responses;

namespace Line.Notify.Api.Client.Interfaces;

[Headers("User-Agent: Line.Notify.Api.Client", "Accept: application/json", "Content-Type: application/json")]
public interface INotifyApi
{
	[Post("/api/notify")]
	Task<ApiResponse<ResponseModel.NotifyModel>> NotifyAsync(
		[Authorize("Bearer")] string token,
		[Body(BodySerializationMethod.UrlEncoded)] MessageModel data);

	[Get("/api/status")]
	Task<ApiResponse<ResponseModel.StatusModel>> StatusAsync([Authorize("Bearer")] string token);

	[Post("/api/revoke")]
	Task<ApiResponse<ResponseModel.RevokeModel>> RevokeAsync([Authorize("Bearer")] string token);
}
