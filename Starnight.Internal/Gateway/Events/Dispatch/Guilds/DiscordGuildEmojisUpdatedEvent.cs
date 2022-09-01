namespace Starnight.Internal.Gateway.Events.Dispatch.Guilds;

using System;
using System.Text.Json.Serialization;

using Starnight.Internal.Gateway.Payloads.Clientbound.Dispatch;

/// <summary>
/// Represents a GuildEmojisUpdated event.
/// </summary>
public sealed record DiscordGuildEmojisUpdatedEvent : IDiscordGatewayDispatchPayload<GuildEmojisUpdatedPayload>
{
	/// <inheritdoc/>
	[JsonPropertyName("s")]
	public required Int32 Sequence { get; init; }

	/// <inheritdoc/>
	[JsonPropertyName("t")]
	public required String EventName { get; init; }

	/// <inheritdoc/>
	[JsonPropertyName("d")]
	public required GuildEmojisUpdatedPayload Data { get; init; }

	/// <inheritdoc/>
	[JsonPropertyName("op")]
	public required DiscordGatewayOpcode Opcode { get; init; }
}