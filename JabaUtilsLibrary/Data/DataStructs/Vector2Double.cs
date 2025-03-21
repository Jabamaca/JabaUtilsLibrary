using JabaUtilsLibrary.Data.BitConvertion;
using System;

namespace JabaUtilsLibrary.Data.DataStructs {
    public class Vector2Double : IBitConvertion, ICloneable {

        #region Properties

        public double x = 0f;
        public double y = 0f;

        #endregion

        #region Constructors

        public Vector2Double () {
            x = 0f;
            y = 0f;
        }

        public Vector2Double (double x, double y) {
            this.x = x;
            this.y = y;
        }

        public Vector2Double (Vector2Int vi) {
            x = vi.x;
            y = vi.y;
        }

        #endregion

        #region Methods

        #region Modify Methods

        public void Add (double x, double y) {
            this.x += x;
            this.y += y;
        }

        public void Add (Vector2Double other) {
            Add (other.x, other.y);
        }

        public void Subtract (double x, double y) {
            this.x -= x;
            this.y -= y;
        }

        public void Subtract (Vector2Double other) {
            Subtract (other.x, other.y);
        }

        public void ScalarMultBy (double scale) {
            x *= scale;
            y *= scale;
        }

        public void Normalize () {
            double mag = Magnitude ();
            ScalarMultBy (1f / mag);
        }

        #endregion

        #region Getter Methods

        public double SqrMagnitude () {
            return (x * x) + (y * y);
        }

        public double Magnitude () {
            return Math.Sqrt (SqrMagnitude ());
        }

        public Vector2Double Normalized () {
            Vector2Double clone = (Vector2Double)Clone ();
            clone.Normalize ();
            return clone;
        }

        #endregion

        #region Abstract Methods

        public static Vector2Double Zero () {
            return new Vector2Double (0f, 0f);
        }

        public static double DotProduct (Vector2Double a, Vector2Double b) {
            return (a.x * b.x) + (a.y * b.y);
        }

        #endregion

        #endregion

        #region Implement IBitConvertion

        public int GetByteCount () {
            return sizeof (double) // X
                + sizeof (double) // Y
                ;
        }

        public bool NextBytesToParams (byte[] bytes, ref int currentByteIndex) {
            // X
            if (!BitConvertionUtils.NextBytesToDouble (bytes, ref currentByteIndex, out x))
                return false;
            // Y
            if (!BitConvertionUtils.NextBytesToDouble (bytes, ref currentByteIndex, out y))
                return false;

            return true;
        }

        public byte[] ToByteArray () {
            byte[] byteArray = new byte[GetByteCount ()];
            int currentByteIndex = 0;

            // X
            BitConvertionUtils.AddBytesToByteArray (BitConvertionUtils.ToByteArray (x), byteArray, ref currentByteIndex);
            // Y
            BitConvertionUtils.AddBytesToByteArray (BitConvertionUtils.ToByteArray (y), byteArray, ref currentByteIndex);

            return byteArray;
        }

        #endregion

        #region

        public object Clone () {
            return MemberwiseClone ();
        }

        #endregion

        #region Internal Methods

        public override int GetHashCode () {
            return base.GetHashCode ();
        }

        public override bool Equals (object obj) {
            if (!(obj is Vector2Double other))
                return false;

            return this.x.Equals (other.x)
                && this.y.Equals (other.y);
        }

        #endregion

        #region Override Operators

        public static Vector2Double operator - (Vector2Double v) {
            return new Vector2Double (-v.x, -v.y);
        }

        public static Vector2Double operator + (Vector2Double a, Vector2Double b) {
            return new Vector2Double (a.x + b.x, a.y + b.y);
        }

        public static Vector2Double operator - (Vector2Double a, Vector2Double b) {
            return new Vector2Double (a.x - b.x, a.y - b.y);
        }

        public static Vector2Double operator * (Vector2Double v, int scale) {
            return new Vector2Double (v.x * scale, v.y * scale);
        }

        #endregion

    }
}
