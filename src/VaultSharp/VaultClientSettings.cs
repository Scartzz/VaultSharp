using System;
using System.Net.Http;
using VaultSharp.V1.AuthMethods;
using VaultSharp.V1.SecretsEngines;

namespace VaultSharp
{
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
        public VaultClientSettings(string vaultServerUriWithPort, IAuthMethodInfo authMethodInfo)
        {
            VaultServerUriWithPort = vaultServerUriWithPort;
            AuthMethodInfo = authMethodInfo;
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
        /// The one time http client's http message handler delegate.
        /// Use this to set proxy settings etc.
        /// </summary>
        public Action<HttpMessageHandler> PostProcessHttpClientHandlerAction { get; set; }

        /// <summary>
        /// The per http request delegate invoked before every vault api http request.
        /// </summary>
        public Action<HttpClient, HttpRequestMessage> BeforeApiRequestAction { get; set; }

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

#if NET45
        /// <summary>
        /// A factory delegate to use if you want to provide your own http client handler.
        /// Don't worry about setting any vault specific values on your http client handler.
        /// Just create your http client handler and pass it in. 
        /// VaultSharp will set all the necessary things.
        /// Use this option to use e.g. a factory like the HttpClientHandlerFactory from Microsoft.
        /// </summary>
        public Func<WebRequestHandler> HttpClientHandlerProviderFunc { get; set; }
#elif NET46 || NET461 || NET462 || NET47 || NET471 || NET472 || NET48
        /// <summary>
        /// A factory delegate to use if you want to provide your own http client handler.
        /// Don't worry about setting any vault specific values on your http client handler.
        /// Just create your http client handler and pass it in. 
        /// VaultSharp will set all the necessary things.
        /// Use this option to use e.g. a factory like the HttpClientHandlerFactory from Microsoft.
        /// </summary>
        public Func<WinHttpHandler> HttpClientHandlerProviderFunc { get; set; }
#elif NETSTANDARD2_0 || NETSTANDARD2_1 || NET481
        /// <summary>
        /// A factory delegate to use if you want to provide your own http client handler.
        /// Don't worry about setting any vault specific values on your http client handler.
        /// Just create your http client handler and pass it in. 
        /// VaultSharp will set all the necessary things.
        /// Use this option to use e.g. a factory like the HttpClientHandlerFactory from Microsoft.
        /// </summary>
        public Func<HttpClientHandler> HttpClientHandlerProviderFunc { get; set; }
#else
        /// <summary>
        /// A factory delegate to use if you want to provide your own http client handler.
        /// Don't worry about setting any vault specific values on your http client handler.
        /// Just create your http client handler and pass it in. 
        /// VaultSharp will set all the necessary things.
        /// Use this option to use e.g. a factory like the HttpClientHandlerFactory from Microsoft.
        /// </summary>
        public Func<SocketsHttpHandler> HttpClientHandlerProviderFunc { get; set; }
#endif

        /// <summary>
        /// A factory delegate to use if you want to provide your own http client.
        /// The Handler already has the certificates etc. enabled. 
        /// Don't worry about setting any vault specific values on your http client.
        /// Just create your http client and pass it in. 
        /// VaultSharp will set all the necessary things.
        /// Use the handler parameter to set proxy etc. 
        /// It is essential that your HttpClient use the handler, since it has certificate auth etc.
        /// </summary>
        public Func<HttpMessageHandler, HttpClient> HttpClientProviderFunc { get; set; }

        /// <summary>
        /// Use custom secret engine mount points globally rather than on every method call.
        /// See <see cref="V1.SecretsEngines.SecretsEngineMountPoints.Defaults" /> for defaults.
        /// </summary>
        public SecretsEngineMountPoints SecretsEngineMountPoints { get; set; } = new SecretsEngineMountPoints();
    }
}
