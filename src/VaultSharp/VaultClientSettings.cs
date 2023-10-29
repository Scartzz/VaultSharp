using System;
using System.Net.Http;
using VaultSharp.V1.AuthMethods;
using VaultSharp.V1.SecretsEngines;

namespace VaultSharp
{
    using System.Threading.Tasks;
    using VaultSharp.Core;

    /// <summary>
    /// The vault client settings.
    /// </summary>
    public class VaultClientSettings
    {
        /// <summary>
        /// Constructor with bare minimal required fields.
        /// </summary>
        /// <param name="vaultServerUriWithPort"></param>
        /// <param name="authMethodInfo"></param>
        /// <param name="httpRequestFunc"></param>
        public VaultClientSettings(string vaultServerUriWithPort, IAuthMethodInfo authMethodInfo, Func<HttpRequestSettings, HttpRequestMessage, Task<HttpResponseMessage>> httpRequestFunc)
        {
            VaultServerUriWithPort = vaultServerUriWithPort;
            AuthMethodInfo = authMethodInfo;
            HttpRequestFunc = httpRequestFunc;
        }

        /// <summary>
        /// The Vault Server Uri with port.
        /// </summary>
        public string VaultServerUriWithPort { get; }

        /// <summary>
        /// The auth method to be used to acquire a vault token.
        /// </summary>
        public IAuthMethodInfo AuthMethodInfo { get; }

        /// <summary>
        /// Flag to indicate async context.
        /// </summary>
        public bool ContinueAsyncTasksOnCapturedContext { get; set; }

        /// <summary>
        /// The Api timeout.
        /// </summary>
        public TimeSpan? VaultServiceTimeout { get; set; }

        /// <summary>
        /// The per http request delegate invoked before every vault api http request.
        /// </summary>
        public Action<HttpRequestMessage> BeforeApiRequestAction { get; set; }

        /// <summary>
        /// The per http response delegate invoked after every vault api http response.
        /// </summary>
        public Action<HttpResponseMessage> AfterApiResponseAction { get; set; }

        /// <summary>
        /// Flag to indicate how the vault token should be passed to the API.
        /// Default is to use the Authorization: Bearer &lt;vault-token&gt; scheme.
        /// </summary>
        public bool UseVaultTokenHeaderInsteadOfAuthorizationHeader { get; set; }

        /// <summary>
        /// The namespace to use to achieve tenant level isolation.
        /// Enterprise Vault only.
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// A function that accepts each request to the Vault and returns the bare response.
        /// Don't worry about setting any vault specific values on this.
        /// </summary>
        public Func<HttpRequestSettings, HttpRequestMessage, Task<HttpResponseMessage>> HttpRequestFunc { get; set; }

        /// <summary>
        /// Use custom secret engine mount points globally rather than on every method call.
        /// See <see cref="V1.SecretsEngines.SecretsEngineMountPoints.Defaults" /> for defaults.
        /// </summary>
        public SecretsEngineMountPoints SecretsEngineMountPoints { get; set; } = new SecretsEngineMountPoints();
    }
}
