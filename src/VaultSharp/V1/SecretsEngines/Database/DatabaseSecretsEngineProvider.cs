using System.Net.Http;
using System.Threading.Tasks;
using VaultSharp.Core;
using VaultSharp.V1.Commons;

namespace VaultSharp.V1.SecretsEngines.Database
{
    using System.Collections.Generic;

    internal class DatabaseSecretsEngineProvider : IDatabaseSecretsEngine
    {
        private readonly Polymath _polymath;

        public DatabaseSecretsEngineProvider(Polymath polymath)
        {
            _polymath = polymath;
        }

        public async Task<Secret<Connection>> ReadConnectionAsync(string connectionName, string mountPoint = null, string wrapTimeToLive = null)
        {
            Checker.NotNull(connectionName, "connectionName");

            return await _polymath.MakeVaultApiRequest<Secret<Connection>>(mountPoint ?? _polymath.VaultClientSettings.SecretsEngineMountPoints.Database, "/config/" + connectionName.Trim('/'), HttpMethod.Get, wrapTimeToLive: wrapTimeToLive).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }
        
        public async  Task AllowRolesForConnection(string connectionName, List<string> allRoleNames, string mountPoint = null)
        {
            Checker.NotNull(connectionName, "connectionName");

            await _polymath.MakeVaultApiRequest(mountPoint ?? _polymath.VaultClientSettings.SecretsEngineMountPoints.Database, "/config/" + connectionName.Trim('/'), HttpMethod.Post, new ConnectionPostAllowedRoles(){AllowedRoles = allRoleNames}).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }
        
        public async Task CreateConnectionAsync(string connectionName, NewConnection newConnection, string mountPoint = null)
        {
            Checker.NotNull(connectionName, "connectionName");
            Checker.NotNull(newConnection, "newConnection");

            await _polymath.MakeVaultApiRequest(mountPoint ?? _polymath.VaultClientSettings.SecretsEngineMountPoints.Database, "/config/" + connectionName.Trim('/'), HttpMethod.Post, newConnection).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }
        
        public async Task RotateRootAsync(string connectionName, string mountPoint = null)
        {
            Checker.NotNull(connectionName, "connectionName");

            await _polymath.MakeVaultApiRequest(mountPoint ?? _polymath.VaultClientSettings.SecretsEngineMountPoints.Database, "/rotate-root/" + connectionName.Trim('/'), HttpMethod.Post).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }
        
        public async Task CreateRoleAsync(string roleName, Role role, string mountPoint = null)
        {
            Checker.NotNull(roleName, "roleName");
            Checker.NotNull(role, "role");

            await _polymath.MakeVaultApiRequest(mountPoint ?? _polymath.VaultClientSettings.SecretsEngineMountPoints.Database, "/roles/" + roleName.Trim('/'), HttpMethod.Post, role).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task<Secret<Role>> ReadRoleAsync(string roleName, string mountPoint = null, string wrapTimeToLive = null)
        {
            Checker.NotNull(roleName, "roleName");

            return await _polymath.MakeVaultApiRequest<Secret<Role>>(mountPoint ?? _polymath.VaultClientSettings.SecretsEngineMountPoints.Database, "/roles/" + roleName.Trim('/'), HttpMethod.Get, wrapTimeToLive: wrapTimeToLive).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task<Secret<ListInfo>> ReadAllRolesAsync(string mountPoint = null, string wrapTimeToLive = null)
        {
            return await _polymath.MakeVaultApiRequest<Secret<ListInfo>>(mountPoint ?? _polymath.VaultClientSettings.SecretsEngineMountPoints.Database, "/roles", _polymath.ListHttpMethod, wrapTimeToLive: wrapTimeToLive).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task DeleteRoleAsync(string roleName, string mountPoint = null)
        {
            Checker.NotNull(roleName, "roleName");

            await _polymath.MakeVaultApiRequest(mountPoint ?? _polymath.VaultClientSettings.SecretsEngineMountPoints.Database, "/roles/" + roleName.Trim('/'), HttpMethod.Delete).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task<Secret<UsernamePasswordCredentials>> GetCredentialsAsync(string roleName, string mountPoint = null, string wrapTimeToLive = null)
        {
            Checker.NotNull(roleName, "roleName");

            return await _polymath.MakeVaultApiRequest<Secret<UsernamePasswordCredentials>>(mountPoint ?? _polymath.VaultClientSettings.SecretsEngineMountPoints.Database, "/creds/" + roleName.Trim('/'), HttpMethod.Get, wrapTimeToLive: wrapTimeToLive).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task CreateStaticRoleAsync(string roleName, StaticRole staticRole, string mountPoint = null)
        {
            Checker.NotNull(roleName, "roleName");
            Checker.NotNull(staticRole, "staticRole");

            await _polymath.MakeVaultApiRequest(mountPoint ?? _polymath.VaultClientSettings.SecretsEngineMountPoints.Database, "/static-roles/" + roleName.Trim('/'), HttpMethod.Post, staticRole).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task<Secret<StaticRole>> ReadStaticRoleAsync(string roleName, string mountPoint = null, string wrapTimeToLive = null)
        {
            Checker.NotNull(roleName, "roleName");

            return await _polymath.MakeVaultApiRequest<Secret<StaticRole>>(mountPoint ?? _polymath.VaultClientSettings.SecretsEngineMountPoints.Database, "/static-roles/" + roleName.Trim('/'), HttpMethod.Get, wrapTimeToLive: wrapTimeToLive).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task<Secret<ListInfo>> ReadAllStaticRolesAsync(string mountPoint = null, string wrapTimeToLive = null)
        {
            return await _polymath.MakeVaultApiRequest<Secret<ListInfo>>(mountPoint ?? _polymath.VaultClientSettings.SecretsEngineMountPoints.Database, "/static-roles", _polymath.ListHttpMethod, wrapTimeToLive: wrapTimeToLive).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task DeleteStaticRoleAsync(string roleName, string mountPoint = null)
        {
            Checker.NotNull(roleName, "roleName");

            await _polymath.MakeVaultApiRequest(mountPoint ?? _polymath.VaultClientSettings.SecretsEngineMountPoints.Database, "/static-roles/" + roleName.Trim('/'), HttpMethod.Delete).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task<Secret<StaticCredentials>> GetStaticCredentialsAsync(string roleName, string mountPoint = null, string wrapTimeToLive = null)
        {
            Checker.NotNull(roleName, "roleName");

            return await _polymath.MakeVaultApiRequest<Secret<StaticCredentials>>(mountPoint ?? _polymath.VaultClientSettings.SecretsEngineMountPoints.Database, "/static-creds/" + roleName.Trim('/'), HttpMethod.Get, wrapTimeToLive: wrapTimeToLive).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task RotateStaticCredentialsAsync(string roleName, string mountPoint = null)
        {
            Checker.NotNull(roleName, "roleName");

            await _polymath.MakeVaultApiRequest(mountPoint ?? _polymath.VaultClientSettings.SecretsEngineMountPoints.Database, "/rotate-role/" + roleName.Trim('/'), HttpMethod.Post).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }
    }
}