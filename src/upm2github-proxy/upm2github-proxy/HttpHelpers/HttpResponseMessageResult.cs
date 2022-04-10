using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace upm2github_proxy.HttpHelpers;

public class HttpResponseMessageResult : IActionResult
{
    private readonly HttpResponseMessage _responseMessage;

    public HttpResponseMessageResult(HttpResponseMessage responseMessage)
    {
        _responseMessage = responseMessage; // could add throw if null
    }

    public async Task ExecuteResultAsync(ActionContext context)
    {
        var response = context.HttpContext.Response;


        if (_responseMessage == null)
        {
            throw new InvalidOperationException("Response message cannot be null");
        }

        using (_responseMessage)
        {
            response.StatusCode = (int) _responseMessage.StatusCode;

            var responseFeature = context.HttpContext.Features.Get<IHttpResponseFeature>();
            if (responseFeature != null)
            {
                responseFeature.ReasonPhrase = _responseMessage.ReasonPhrase;
            }

            var responseHeaders = _responseMessage.Headers;

            // Ignore the Transfer-Encoding header if it is just "chunked".
            // We let the host decide about whether the response should be chunked or not.
            if (responseHeaders.TransferEncodingChunked == true
                && responseHeaders.TransferEncoding.Count == 1)
            {
                responseHeaders.TransferEncoding.Clear();
            }

            foreach (var (key, value) in responseHeaders)
            {
                response.Headers.Append(key, value.ToArray());
            }

            var contentHeaders = _responseMessage.Content.Headers;

            // Copy the response content headers only after ensuring they are complete.
            // We ask for Content-Length first because HttpContent lazily computes this
            // and only afterwards writes the value into the content headers.
            var unused = contentHeaders.ContentLength;

            foreach (var (key, value) in contentHeaders)
            {
                response.Headers.Append(key, value.ToArray());
            }

            await _responseMessage.Content.CopyToAsync(response.Body);
        }
    }
}