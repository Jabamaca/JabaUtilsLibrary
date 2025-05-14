using JabaUtilsLibrary.Data.BitConvertion;
using System;

namespace JabaUtilsLibrary.Data.DataStructs {
    public struct Vector2Float : IBitConvertion, ICloneable {

        #region Properties

        public float x;
        public float y;

        #endregion

        #region Constructors

        public Vector2Float (float x, float y) {
            this.x = x;
            this.y = y;
        }

        public Vector2Float (Vector2Int vi) {
            x = vi.x;
            y = vi.y;
        }

        #endregion

        #region Methods

        #region Modify Methods

        public void Add (float x, float y) {
            this.x += x;
            this.y += y;
        }

        public void Add (Vector2Float other) {
            Add (other.x, other.y);
        }

        public void Subtract (float x, float y) {
            this.x -= x;
            this.y -= y;
        }

        public void Subtract (Vector2Float other) {
            Subtract (other.x, other.y);
        }

        public void ScalarMultBy (float scale) {
            x *= scale;
            y *= scale;
        }

        public void Normalize () {
            float mag = Magnitude ();
            ScalarMultBy (1f / mag);
        }

        #endregion

        #region Getter Methods

        public float SqrMagnitude () {
            return (x * x) + (y * y);
        }

        public float Magnitude () {
            return (float)Math.Sqrt (SqrMagnitude ());
        }

        public Vector2Float Normalized () {
            Vector2Float clone = (Vector2Float)Clone ();
            clone.Normalize ();
            return clone;
        }

        #endregion

        #region Abstract Methods

        public static Vector2Float Zero () {
            return new Vector2Float (0f, 0f);
        }

        public static float DotProduct (Vector2Float a, Vector2Float b) {
            return (a.x * b.x) + (a.y * b.y);
        }

        #endregion

        #endregion

        #region Implement IBitConvertion

        public int GetByteCount () {
            return sizeof (float) // X
                + sizeof (float) // Y
                ;
        }

        public bool NextBytesToParams (byte[] bytes, ref int currentByteIndex) {
            // X
            if (!BitConvertionUtils.NextBytesToFloat (bytes, ref currentByteIndex, out x))
                return false;
            // Y
            if (!BitConvertionUtils.NextBytesToFloat (bytes, ref currentByteIndex, out y))
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
            if (!(obj is Vector2Float other))
                return false;

            return this.x.Equals (other.x)
                && this.y.Equals (other.y);
        }

        #endregion

        #region Override Operators

        public static Vector2Float operator - (Vector2Float v) {
            return new Vector2Float (-v.x, -v.y);
        }

        public static Vector2Float operator + (Vector2Float a, Vector2Float b) {
            return new Vector2Float (a.x + b.x, a.y + b.y);
        }

        public static Vector2Float operator - (Vector2Float a, Vector2Float b) {
            return new Vector2Float (a.x - b.x, a.y - b.y);
        }

        public static Vector2Float operator * (Vector2Float v, int scale) {
            return new Vector2Float (v.x * scale, v.y * scale);
        }

        #endregion

    }
}
