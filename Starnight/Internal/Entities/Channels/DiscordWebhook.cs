namespace Starnight.Internal.Entities.Channels;

using System;
using System.Text.Json.Serialization;

using Starnight.Internal.Entities.Guilds;
using Starnight.Internal.Entities.Users;

/// <summary>
/// Represents a discord webhook.
/// </summary>
public record DiscordWebhook : DiscordSnowflakeObject
{
	/// <summary>
	/// The type of this webhook.
	/// </summary>
	[JsonPropertyName("type")]
	public DiscordWebhookType Type { get; init; }

	/// <summary>
	/// Snowflake identifier of the guild this webhook belongs to, if any.
	/// </summary>
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
	[JsonPropertyName("guild_id")]
	public Int64? GuildId { get; init; }

	/// <summary>
	/// Snowflake identifier of the channel this webhook belongs to, if any.
	/// </summary>
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
	[JsonPropertyName("channel_id")]
	public Int64? ChannelId { get; init; }

	/// <summary>
	/// The user which created the webhook.
	/// </summary>
	[JsonPropertyName("user")]
	public DiscordUser? Creator { get; init; }

	/// <summary>
	/// The default displayname of this webhook.
	/// </summary>
	[JsonPropertyName("name")]
	public String? Name { get; init; }

	/// <summary>
	/// Default avatar hash for this webhook.
	/// </summary>
	[JsonPropertyName("avatar")]
	public String? AvatarHash { get; init; }

	/// <summary>
	/// Secure token for this webhook.
	/// </summary>
	[JsonPropertyName("token")]
	public String? Token { get; init; }

	/// <summary>
	/// The bot/oauth2 application which created this webhook.
	/// </summary>
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
	[JsonPropertyName("application_id")]
	public Int64? ApplicationId { get; init; }

	/// <summary>
	/// The guild owning the channel this webhook is sourced from.
	/// </summary>
	[JsonPropertyName("source_guild")]
	public DiscordGuild? SourceGuild { get; init; }

	/// <summary>
	/// The channel this webhook is sourced from.
	/// </summary>
	[JsonPropertyName("source_channel")]
	public DiscordChannel? SourceChannel { get; init; }

	/// <summary>
	/// The URL used to execute this webhook.
	/// </summary>
	[JsonPropertyName("url")]
	public String? Url { get; init; }
}
