using System.Net.Http.Json;

namespace Zalo.Web.Services
{
    public abstract class ApiServiceBase
    {
        private readonly HttpClient _httpClient;

        public ApiServiceBase(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<TResult> GetAsync<TResult>(string url, Func<HttpResponseMessage, Exception> errorHandler = null)
        {
            try
            {
                var res = await _httpClient.GetAsync(url);
                if (res.IsSuccessStatusCode)
                {
                    return await res.Content.ReadAsAsync<TResult>();
                }
                else
                {
                    if (errorHandler != null)
                    {
                        throw errorHandler(res);
                    }
                    else
                    {
                        var aer = await res.Content.ReadAsAsync<ApiErrorResponse>();
                        if (aer != null)
                        {
                            throw new ApiErrorException(aer.ErrorDescription, aer.CorrelationId);
                        }

                        throw new System.Exception(res.ReasonPhrase);
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<T> PostAsync<T, U>(string url, U data, Func<HttpResponseMessage, Exception> errorHandler = null)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync(url, data);
                if (res.IsSuccessStatusCode)
                {
                    return await res.Content.ReadAsAsync<T>();
                }
                else
                {
                    if (errorHandler != null)
                    {
                        throw errorHandler(res);
                    }
                    else
                    {
                        if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
                        {
                            throw new ApiNotFoundException(res.ReasonPhrase);
                        }

                        var aer = await res.Content.ReadAsAsync<ApiErrorResponse>();
                        if (aer != null)
                        {
                            throw new ApiErrorException(aer.ErrorDescription, aer.CorrelationId);
                        }

                        throw new System.Exception(res.ReasonPhrase);
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<T> PutAsync<T, U>(string url, U data, Func<HttpResponseMessage, Exception> errorHandler = null)
        {
            try
            {
                var res = await _httpClient.PutAsJsonAsync(url, data);
                if (res.IsSuccessStatusCode)
                {
                    return await res.Content.ReadAsAsync<T>();
                }
                else
                {
                    if (errorHandler != null)
                    {
                        throw errorHandler(res);
                    }
                    else
                    {
                        if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
                        {
                            throw new ApiNotFoundException(res.ReasonPhrase);
                        }

                        var aer = await res.Content.ReadAsAsync<ApiErrorResponse>();
                        if (aer != null)
                        {
                            throw new ApiErrorException(aer.ErrorDescription, aer.CorrelationId);
                        }

                        throw new System.Exception(res.ReasonPhrase);
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        // public async Task<bool> PostAsync<T>(string url, T data, Func<HttpResponseMessage, Exception> errorHandler = null)
        // {
        //     try
        //     {
        //         var res = await _httpClient.PostAsJsonAsync(url, data);
        //         if (res.IsSuccessStatusCode)
        //         {
        //             return await res.Content.ReadAsAsync<bool>();
        //         }
        //         else
        //         {
        //             if (errorHandler != null)
        //             {
        //                 throw errorHandler(res);
        //             }
        //             else
        //             {
        //                 // try to deserialize ApiError

        //                 if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
        //                 {
        //                     throw new ApiNotFoundException(res.ReasonPhrase);
        //                 }

        //                 var aer = await res.Content.ReadAsAsync<ApiErrorResponse>();
        //                 if (aer != null)
        //                 {
        //                     throw new ApiErrorException(aer.ErrorDescription, aer.CorrelationId);
        //                 }

        //                 throw new System.Exception(res.ReasonPhrase);
        //             }
        //         }
        //     }
        //     catch
        //     {
        //         throw;
        //     }
        // }

        public async Task PostAsync<T>(string url, T data, Func<HttpResponseMessage, Exception> errorHandler = null)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync(url, data);
                if (res.IsSuccessStatusCode)
                {
                    return;// await Task.CompletedTask;//await res.Content.ReadAsAsync<bool>();
                }
                else
                {
                    if (errorHandler != null)
                    {
                        throw errorHandler(res);
                    }
                    else
                    {
                        // try to deserialize ApiError

                        if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
                        {
                            throw new ApiNotFoundException(res.ReasonPhrase);
                        }

                        var aer = await res.Content.ReadAsAsync<ApiErrorResponse>();
                        if (aer != null)
                        {
                            throw new ApiErrorException(aer.ErrorDescription, aer.CorrelationId);
                        }

                        throw new System.Exception(res.ReasonPhrase);
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteAsync(string url, Func<HttpResponseMessage, Exception> errorHandler = null)
        {
            try
            {
                var res = await _httpClient.DeleteAsync(url);
                if (res.IsSuccessStatusCode)
                {
                    return;// await Task.CompletedTask;//await res.Content.ReadAsAsync<bool>();
                }
                else
                {
                    if (errorHandler != null)
                    {
                        throw errorHandler(res);
                    }
                    else
                    {
                        // try to deserialize ApiError

                        if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
                        {
                            throw new ApiNotFoundException(res.ReasonPhrase);
                        }

                        var aer = await res.Content.ReadAsAsync<ApiErrorResponse>();
                        if (aer != null)
                        {
                            throw new ApiErrorException(aer.ErrorDescription, aer.CorrelationId);
                        }

                        throw new System.Exception(res.ReasonPhrase);
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task PostContentAsync(string url, HttpContent data, Func<HttpResponseMessage, Exception> errorHandler = null)
        {
            try
            {
                var res = await _httpClient.PostAsync(url, data);
                if (res.IsSuccessStatusCode)
                {
                    return;// await Task.CompletedTask;//await res.Content.ReadAsAsync<bool>();
                }
                else
                {
                    if (errorHandler != null)
                    {
                        throw errorHandler(res);
                    }
                    else
                    {
                        // try to deserialize ApiError

                        if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
                        {
                            throw new ApiNotFoundException(res.ReasonPhrase);
                        }

                        var aer = await res.Content.ReadAsAsync<ApiErrorResponse>();
                        if (aer != null)
                        {
                            throw new ApiErrorException(aer.ErrorDescription, aer.CorrelationId);
                        }

                        throw new System.Exception(res.ReasonPhrase);
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task PostAsync(string url, Func<HttpResponseMessage, Exception> errorHandler = null)
        {
            try
            {
                var res = await _httpClient.PostAsync(url, null);
                if (res.IsSuccessStatusCode)
                {
                    return;
                }
                else
                {
                    if (errorHandler != null)
                    {
                        throw errorHandler(res);
                    }
                    else
                    {
                        if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
                        {
                            throw new ApiNotFoundException(res.ReasonPhrase);
                        }

                        var aer = await res.Content.ReadAsAsync<ApiErrorResponse>();
                        if (aer != null)
                        {
                            throw new ApiErrorException(aer.ErrorDescription, aer.CorrelationId);
                        }

                        throw new System.Exception(res.ReasonPhrase);
                    }
                }
            }
            catch
            {
                throw;
            }
        }
    }
}