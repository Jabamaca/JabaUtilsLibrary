using JabaUtilsLibrary.Data.BitConvertion;
using System;

namespace JabaUtilsLibrary.Data.DataStructs {
    public class Vector2Float : IBitConvertion, ICloneable {

        #region Properties

        public float x = 0f;
        public float y = 0f;

        #endregion

        #region Constructors

        public Vector2Float () {
            x = 0f;
            y = 0f;
        }

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

        public void ScalarMultBy (float mult) {
            x *= mult;
            y *= mult;
        }

        #region Abstract Methods

        public static Vector2Float Zero () {
            return new Vector2Float (0, 0);
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
            if (obj is not Vector2Float other)
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

        public static Vector2Float operator * (Vector2Float v, int mult) {
            return new Vector2Float (v.x * mult, v.y * mult);
        }

        #endregion

    }
}
