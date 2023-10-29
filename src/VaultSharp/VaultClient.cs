using VaultSharp.Core;
using VaultSharp.V1;

namespace VaultSharp
{
    /// <summary>
    /// The concrete Vault client class.
    /// </summary>
    public class VaultClient : IVaultClient
    {
        private readonly Polymath _polymath;
        private readonly VaultClientV1 _client;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="vaultClientSettings"></param>
        public VaultClient(VaultClientSettings vaultClientSettings)
        {
            _polymath = new Polymath(vaultClientSettings);
            _client = new VaultClientV1(_polymath);
        }

        /// <summary>
        /// Gets the V1 Client interface for Vault Api.
        /// </summary>
        public IVaultClientV1 V1
        {
            get => _client;
        }

        /// <summary>
        /// Gets the Vault Client Settings.
        /// </summary>
        public VaultClientSettings Settings
        {
            get => _polymath.VaultClientSettings;
        }
    }
}
