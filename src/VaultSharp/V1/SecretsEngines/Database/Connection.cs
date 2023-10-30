namespace VaultSharp.V1.SecretsEngines.Database
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class ConnectionDetails
    {
        [JsonPropertyName("backend")]
        public string Backend { get; set; }
        [JsonPropertyName("connection_url")]
        public string ConnectionUrl { get; set; }
        [JsonPropertyName("max_connection_lifetime")]
        public string MaximumConnectionLifetime { get; set; }
        [JsonPropertyName("max_idle_connections")]
        public int MaximumIdleConnections { get; set; }
        [JsonPropertyName("max_open_connections")]
        public int MaximumOpenConnections { get; set; }
        [JsonPropertyName("username")]
        public string Username { get; set; }
    }

    public class Connection
    {
        [JsonPropertyName("allowed_roles")]
        public List<string> AllowedRoles { get; set; }
        [JsonPropertyName("connection_details")]
        public ConnectionDetails ConnectionDetails { get; set; }
        [JsonPropertyName("password_policy")]
        public string PasswordPolicy { get; set; }
        [JsonPropertyName("plugin_name")]
        public string PluginName { get; set; }
        [JsonPropertyName("plugin_version")]
        public string PluginVersion { get; set; }
        [JsonPropertyName("root_credentials_rotate_statements")]
        public List<string> RootCredentialsRotateStatements { get; set; }
    }

    public class NewConnection
    {
        [JsonPropertyName("plugin_name")]
        public string PluginName { get; set; }

        [JsonPropertyName("verify_connection")]
        public bool VerifyConnection { get; set; }

        [JsonPropertyName("connection_url")]
        public string ConnectionUrl { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("max_open_connections")]
        public int MaxOpenConnections { get; set; }

        [JsonPropertyName("max_idle_connections")]
        public int MaxIdleConnections { get; set; }

        [JsonPropertyName("max_connection_lifetime")]
        public string MaxConnectionLifetime { get; set; }
    }
}