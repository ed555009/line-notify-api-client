using Line.Notify.Api.Client.Interfaces;

namespace Line.Notify.Api.Client.Models.Responses;

/// <summary>
/// Base response model
/// </summary>
public abstract class BaseResponseModel : IBaseResponseModel
{
	/// <summary>
	/// Value according to HTTP status code
	/// </summary>
	public int? Status { get; set; }

	/// <summary>
	/// Message visible to end-user
	/// </summary>
	public string? Message { get; set; }
}
