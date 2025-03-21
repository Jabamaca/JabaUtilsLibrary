namespace JabaUtilsLibrary.Http {
    public class HttpJsonResponse<T> where T : HttpResponseData {

        #region Properties

#pragma warning disable IDE1006 // Naming Styles
        public string type {
#pragma warning restore IDE1006 // Naming Styles
            get; set;
        }

#pragma warning disable IDE1006 // Naming Styles
        public string message {
#pragma warning restore IDE1006 // Naming Styles
            get; set;
        }

#pragma warning disable IDE1006 // Naming Styles
        public T data {
#pragma warning restore IDE1006 // Naming Styles
            get; set;
        }

        #endregion

    }
}
