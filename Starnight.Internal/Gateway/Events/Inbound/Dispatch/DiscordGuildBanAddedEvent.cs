namespace Starnight.Internal.Gateway.Events.Inbound.Dispatch;

using System;
using System.Text.Json.Serialization;

using Starnight.Internal.Gateway.Payloads.Inbound.Dispatch;

/// <summary>
/// Represents a GuildBanAdded event.
/// </summary>
public sealed record DiscordGuildBanAddedEvent : IDiscordGatewayDispatchEvent<GuildBanAddedPayload>
{
	/// <inheritdoc/>
	[JsonPropertyName("s")]
	public required Int32 Sequence { get; set; }

	/// <inheritdoc/>
	[JsonPropertyName("t")]
	public required String EventName { get; set; }

	/// <inheritdoc/>
	[JsonPropertyName("d")]
	public required GuildBanAddedPayload Data { get; set; }

	/// <inheritdoc/>
	[JsonPropertyName("op")]
	public required DiscordGatewayOpcode Opcode { get; set; }
}
