using Line.Notify.Api.Client.Models.Requests;
using Refit;
using ResponseModel = Line.Notify.Api.Client.Models.Responses;

namespace Line.Notify.Api.Client.Interfaces;

public interface INotifyService
{
	/// <summary>
	/// Sends notifications to users or groups that are related to an access token
	/// </summary>
	Task<ApiResponse<ResponseModel.NotifyModel>> NotifyAsync(MessageModel data, string? authToken = null);

	/// <summary>
	/// An API for checking connection status
	/// </summary>
	Task<ApiResponse<ResponseModel.StatusModel>> StatusAsync(string? authToken = null);

	/// <summary>
	/// An API used on the connected service side to revoke notification configurations<br/>
	/// If returns status code 200, the request is accepted, revoking all access tokens and ending the process<br/>
	/// If returns status code 401, the access tokens have already been revoked and the connection will be deleted<br/>
	/// If returns any other status code, the process will end (you can try again at a later time)
	/// </summary>
	Task<ApiResponse<ResponseModel.RevokeModel>> RevokeAsync(string? authToken = null);
}
