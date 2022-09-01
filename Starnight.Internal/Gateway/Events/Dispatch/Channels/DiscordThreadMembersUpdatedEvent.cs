namespace Starnight.Internal.Gateway.Events.Dispatch.Channels;

using System;
using System.Text.Json.Serialization;

using Starnight.Internal.Gateway;
using Starnight.Internal.Gateway.Payloads.Clientbound.Dispatch;

/// <summary>
/// Represents a ThreadMembersUpdated event.
/// </summary>
public sealed record DiscordThreadMembersUpdatedEvent : IDiscordGatewayDispatchPayload<ThreadMembersUpdatedPayload>
{
	/// <inheritdoc/>
	[JsonPropertyName("s")]
	public required Int32 Sequence { get; init; }

	/// <inheritdoc/>
	[JsonPropertyName("t")]
	public required String EventName { get; init; }

	/// <inheritdoc/>
	[JsonPropertyName("d")]
	public required ThreadMembersUpdatedPayload Data { get; init; }

	/// <inheritdoc/>
	[JsonPropertyName("op")]
	public required DiscordGatewayOpcode Opcode { get; init; }
}