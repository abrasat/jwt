using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;

namespace JWT.Extensions.AspNetCore
{
    public class JwtAuthenticationOptions : AuthenticationSchemeOptions
    {
        /// <summary>
        /// The keys used to sign the JWT.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">Plain-text secret for HMACSHA algorithms.</list>
        /// <list type="bullet">Public Key for RS algorithms.</list>
        /// </remarks>
        public string[] Keys { get; set; }

        /// <summary>
        /// The flag whether to verify the signature or not. The default value is <see langword="true" />.
        /// </summary>
        public bool VerifySignature { get; set; } = true;

        /// <summary>
        /// Handles missing authentication header.
        /// </summary>
        /// <remarks>
        /// For the default behavior <see cref="JwtAuthenticationHandler.OnMissingHeader" />.
        /// </remarks>
        public Func<ILogger, AuthenticateResult> OnMissingHeader { get; set; } = JwtAuthenticationHandler.OnMissingHeader;

        /// <summary>
        /// Handles incorrect authentication scheme.
        /// </summary>
        /// <remarks>
        /// For the default behavior <see cref="JwtAuthenticationHandler.OnIncorrectScheme" />.
        /// </remarks>
        public Func<ILogger, string, string, AuthenticateResult> OnIncorrectScheme { get; set; } = JwtAuthenticationHandler.OnIncorrectScheme;

        /// <summary>
        /// Handles empty authentication header.
        /// </summary>
        /// <remarks>
        /// For the default behavior <see cref="JwtAuthenticationHandler.OnEmptyHeader" />.
        /// </remarks>
        public Func<ILogger, string, AuthenticateResult> OnEmptyHeader { get; set; } = JwtAuthenticationHandler.OnEmptyHeader;

        /// <summary>
        /// Handles successful authentication header.
        /// </summary>
        /// <remarks>
        /// For the default behavior <see cref="JwtAuthenticationHandler.OnSuccessfulTicket" />.
        /// </remarks>
        public Func<ILogger, AuthenticationTicket, AuthenticateResult> OnSuccessfulTicket { get; set; } = JwtAuthenticationHandler.OnSuccessfulTicket;

        /// <summary>
        /// Handles failed authentication header.
        /// </summary>
        /// <remarks>
        /// For the default behavior <see cref="JwtAuthenticationHandler.OnFailedTicket" />.
        /// </remarks>
        public Func<ILogger, Exception, AuthenticateResult> OnFailedTicket { get; set; } = JwtAuthenticationHandler.OnFailedTicket;

        /// <summary>
        /// Whether to include by default AuthenticationScheme into the resulting <see cref="ClaimsIdentity" />.
        /// </summary>
        /// <remarks>
        /// The default value is <c>true</c>.
        /// </remarks>
        public bool IncludeAuthenticationScheme { get; set; } = true;

        /// <summary>
        /// Type of the payload to deserialize to.
        /// </summary>
        /// <remarks>
        /// The default value is <see cref="Dictionary{String, String}" />.
        /// </remarks>
        public Type PayloadType { get; set; } = typeof(Dictionary<string, string>);
    }
}