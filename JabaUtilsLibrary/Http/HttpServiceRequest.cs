using System;
using System.Text;
using System.Text.Json;
using System.Net.Http;

namespace JabaUtilsLibrary.Http {
    public abstract class HttpServiceRequest<T, U> where T : HttpRequestData where U : HttpResponseData {

        #region Properties

        private static readonly HttpClient _sharedClient = new ();

        public abstract string ServiceUrl {
            get;
        }

        protected Action<U> _onResponseAction;
        public Action<U> OnResponseAction => _onResponseAction;
        protected Action<string> _internalErrorAction;
        public Action<string> InternalErrorAction => _internalErrorAction;
        protected Action<Exception> _exceptionErrorAction;
        public Action<Exception> ExceptionErrorAction => _exceptionErrorAction;

        #endregion

        #region Methods

        public void SetOnResponseAction (Action<U> action) {
            _onResponseAction = action;
        }

        public void SetInternalFailAction (Action<string> action) {
            _internalErrorAction = action;
        }

        public void SetExceptionFailAction (Action<Exception> action) {
            _exceptionErrorAction = action;
        }

        protected abstract T GetRequestParams ();

        private string GetRequestParamsJson () {
            return JsonSerializer.Serialize (GetRequestParams ());
        }

        public async void ExecuteHttpRequestAsync () {
            try {
                string jsonContent = GetRequestParamsJson ();
                HttpContent content = new StringContent (jsonContent, Encoding.UTF8, "application/json");
                var response = await _sharedClient.PostAsync (ServiceUrl, content);
                string responseData = await response.Content.ReadAsStringAsync ();

                if (response.IsSuccessStatusCode) {
                    HttpJsonResponse<U> responseDto = JsonSerializer.Deserialize<HttpJsonResponse<U>> (responseData);
                    OnResponseAction?.Invoke (responseDto.data);
                } else {
                    InternalErrorAction?.Invoke (responseData);
                }
            } catch (Exception e) {
                ExceptionErrorAction?.Invoke (e);
            }
        }

        #endregion

    }
}