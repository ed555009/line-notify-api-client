using System.ComponentModel.DataAnnotations;
using Line.Notify.Api.Client.Interfaces;

namespace Line.Notify.Api.Client.Models.Requests;

/// <summary>
/// Notify message model
/// </summary>
public class MessageModel : IBaseRequestModel
{
	/// <summary>
	/// Message body, 1000 characters max
	/// </summary>
	[Required, MaxLength(1000)]
	public string? Message { get; set; }

	/// <summary>
	/// Thumbnail image url, maximum size of 240×240px JPEG
	/// </summary>
	public string? ImageThumbnail { get; set; }

	/// <summary>
	/// Fullsize image url, maximum size of 2048×2048px JPEG
	/// </summary>
	public string? ImageFullsize { get; set; }

	/// <summary>
	/// Sticker package ID<br/>
	/// https://developers.line.biz/en/docs/messaging-api/sticker-list/
	/// </summary>
	public long? StickerPackageId { get; set; }

	/// <summary>
	/// Sticker ID
	/// </summary>
	public long? StickerId { get; set; }

	/// <summary>
	/// true: The user doesn't receive a push notification when the message is sent.<br/>
	/// false: The user receives a push notification when the message is sent (unless they have disabled push notification in LINE and/or their device).<br/>
	/// If omitted, the value defaults to false.
	/// </summary>
	public bool NotificationDisabled { get; set; } = false;
}
