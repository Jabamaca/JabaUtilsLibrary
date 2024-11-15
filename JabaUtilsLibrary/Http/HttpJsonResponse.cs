namespace JabaUtilsLibrary.Http {
    public class HttpJsonResponse<T> where T : HttpResponseData {

        #region Properties

        public string type {
            get; set;
        }
        public string message {
            get; set;
        }
        public T data {
            get; set;
        }

        #endregion

    }
}
