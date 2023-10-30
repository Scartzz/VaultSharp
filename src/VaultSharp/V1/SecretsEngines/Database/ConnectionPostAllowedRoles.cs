namespace VaultSharp.V1.SecretsEngines.Database
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class ConnectionPostAllowedRoles
    {
        [JsonPropertyName("allowed_roles")]
        public List<string> AllowedRoles { get; set; }
    }
}