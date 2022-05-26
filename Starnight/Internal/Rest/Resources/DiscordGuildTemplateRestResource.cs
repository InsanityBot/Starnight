namespace Starnight.Internal.Rest.Resources;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using Microsoft.Extensions.Caching.Memory;

using Starnight.Internal.Entities.Guilds;
using Starnight.Internal.Rest.Payloads.GuildTemplates;

using static DiscordApiConstants;

using HttpMethodEnum = HttpMethod;

/// <summary>
/// Represents a wrapper for all requests to the guild template resource.
/// </summary>
public class DiscordGuildTemplateRestResource : AbstractRestResource
{
	private readonly RestClient __rest_client;

	/// <inheritdoc/>
	public DiscordGuildTemplateRestResource
	(
		RestClient client,
		IMemoryCache cache
	)
		: base(cache)
		=> this.__rest_client = client;

	/// <summary>
	/// Fetches the guild template object corresponding to the given template code.
	/// </summary>
	public async ValueTask<DiscordGuildTemplate> GetGuildTemplateAsync
	(
		String templateCode
	)
	{
		IRestRequest request = new RestRequest
		{
			Path = $"/{Guilds}/{Templates}/{TemplateCode}",
			Url = new($"{BaseUri}/{Guilds}/{Templates}/{templateCode}"),
			Method = HttpMethodEnum.Get,
			Context = new()
			{
				["endpoint"] = $"/{Guilds}/{Templates}/{TemplateCode}",
				["cache"] = this.RatelimitBucketCache,
				["exempt-from-global-limit"] = false
			}
		};

		HttpResponseMessage response = await this.__rest_client.MakeRequestAsync(request);

		return JsonSerializer.Deserialize<DiscordGuildTemplate>(await response.Content.ReadAsStringAsync())!;
	}

	/// <summary>
	/// Creates a new guild from the given guild template.
	/// </summary>
	/// <remarks>
	/// This endpoint can only be used by bots in less than 10 guilds.
	/// </remarks>
	/// <param name="templateCode">Template code to create the guild from.</param>
	/// <param name="payload">Request payload.</param>
	/// <returns>The newly created guild.</returns>
	public async ValueTask<DiscordGuild> CreateGuildFromTemplateAsync
	(
		String templateCode,
		CreateGuildFromTemplateRequestPayload payload
	)
	{
		IRestRequest request = new RestRequest
		{
			Path = $"/{Guilds}/{Templates}/{TemplateCode}",
			Url = new($"{BaseUri}/{Guilds}/{Templates}/{templateCode}"),
			Payload = JsonSerializer.Serialize(payload),
			Method = HttpMethodEnum.Post,
			Context = new()
			{
				["endpoint"] = $"/{Guilds}/{Templates}/{TemplateCode}",
				["cache"] = this.RatelimitBucketCache,
				["exempt-from-global-limit"] = false
			}
		};

		HttpResponseMessage response = await this.__rest_client.MakeRequestAsync(request);

		return JsonSerializer.Deserialize<DiscordGuild>(await response.Content.ReadAsStringAsync())!;
	}

	/// <summary>
	/// Returns all guild templates associated with this guild.
	/// </summary>
	/// <param name="guildId">Snowflake identifier of the guild in question.</param>
	public async ValueTask<IEnumerable<DiscordGuildTemplate>> GetGuildTemplatesAsync
	(
		Int64 guildId
	)
	{
		IRestRequest request = new RestRequest
		{
			Path = $"/{Guilds}/{GuildId}/{Templates}",
			Url = new($"{BaseUri}/{Guilds}/{guildId}/{Templates}"),
			Method = HttpMethodEnum.Get,
			Context = new()
			{
				["endpoint"] = $"/{Guilds}/{guildId}/{Templates}",
				["cache"] = this.RatelimitBucketCache,
				["exempt-from-global-limit"] = false
			}
		};

		HttpResponseMessage response = await this.__rest_client.MakeRequestAsync(request);

		return JsonSerializer.Deserialize<IEnumerable<DiscordGuildTemplate>>(await response.Content.ReadAsStringAsync())!;
	}
}
