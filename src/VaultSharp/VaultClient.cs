using VaultSharp.Core;
using VaultSharp.V1;

namespace VaultSharp
{
    using System;

    /// <summary>
    /// The concrete Vault client class.
    /// </summary>
    public class VaultClient : IVaultClient
    {
        private readonly Polymath _polymath;
        private readonly VaultClientV1 _client;
        private bool _disposed;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="vaultClientSettings"></param>
        public VaultClient(VaultClientSettings vaultClientSettings)
        {
            _polymath = new Polymath(vaultClientSettings);
            _client = new VaultClientV1(_polymath);
        }
        
        ~VaultClient() => Dispose(false);

        private void CheckDisposed()
        {
            if (this._disposed)
                throw new ObjectDisposedException(this.GetType().FullName);
        }

        /// <summary>
        /// Gets the V1 Client interface for Vault Api.
        /// </summary>
        public IVaultClientV1 V1
        {
            get
            {
                CheckDisposed();
                return _client;
            }
        }

        /// <summary>
        /// Gets the Vault Client Settings.
        /// </summary>
        public VaultClientSettings Settings
        {
            get => _polymath.VaultClientSettings;
        }

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            _polymath.Dispose();

            _disposed = true;
        }
    }
}
