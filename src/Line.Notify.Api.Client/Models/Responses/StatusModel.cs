using Line.Notify.Api.Client.Enums;

namespace Line.Notify.Api.Client.Models.Responses;

public class StatusModel : BaseResponseModel
{
	/// <summary>
	/// If the notification target is a user: "USER"<br/>
	/// If the notification target is a group: "GROUP"
	/// </summary>
	public TargetType? TargetType { get; set; }

	/// <summary>
	/// If the notification target is a user, displays user name. If acquisition fails, displays "null."<br/>
	/// If the notification target is a group, displays group name. If the target user has already left the group, displays "null."
	/// </summary>
	public string? Target { get; set; }
}
