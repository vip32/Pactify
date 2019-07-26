using System.Net;
using Pactify.Definitions.Http;

namespace Pactify.Builders.Http
{
    public class HttpPactResponseBuilder : IHttpPactResponseBuilder, IBuildingAccessor<HttpPactResponse>
    {
        private readonly HttpPactResponse _pactResponse;

        public HttpPactResponseBuilder()
        {
            _pactResponse = new HttpPactResponse();
        }

        public IHttpPactResponseBuilder WithHeader(string key, string value)
        {
            _pactResponse.Headers.Add(key, value);
            return this;
        }

        public IHttpPactResponseBuilder WithStatusCode(HttpStatusCode statusCode)
        {
            _pactResponse.StatusCode = statusCode;
            return this;
        }

        public IHttpPactResponseBuilder WithBody(object body)
        {
            if (body is null)
            {
                throw new PactifyException("HTTP Body must be provided");
            }

            _pactResponse.Body = body;
            return this;
        }

        public IHttpPactResponseBuilder WithBody<TBody>() where TBody : new()
            => WithBody(new TBody());
        
        public HttpPactResponse Build()
            => _pactResponse;
    }
}