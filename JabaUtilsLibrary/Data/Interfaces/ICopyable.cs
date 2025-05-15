using System;

namespace JabaUtilsLibrary.Data.Interfaces {
    public interface ICopyable<T> : ICloneable where T : ICloneable {

        #region Methods

        T Copy ();

        #endregion

    }
}
