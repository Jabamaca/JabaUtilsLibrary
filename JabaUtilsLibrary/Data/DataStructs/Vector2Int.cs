using System;
using JabaUtilsLibrary.Data.BitConvertion;

namespace JabaUtilsLibrary.Data.DataStructs {
    public class Vector2Int : IBitConvertion, ICloneable {

        #region Properties

        public int x = 0;
        public int y = 0;

        #endregion

        #region Constructors

        public Vector2Int () {
            x = 0;
            y = 0;
        }

        public Vector2Int (int x, int y) {
            this.x = x;
            this.y = y;
        }

        #endregion

        #region Methods

        public void Add (int x, int y) {
            this.x += x;
            this.y += y;
        }

        public void Add (Vector2Int other) {
            Add (other.x, other.y);
        }

        public void Subtract (int x, int y) {
            this.x -= x;
            this.y -= y;
        }

        public void Subtract (Vector2Int other) {
            Subtract (other.x, other.y);
        }

        public void ScalarMultBy (int mult) {
            x *= mult;
            y *= mult;
        }

        #region Abstract Methods

        public static Vector2Int Zero () {
            return new Vector2Int (0, 0);
        }

        #endregion

        #endregion

        #region Implement IBitConvertion

        public int GetByteCount () {
            return sizeof (int) // X
                + sizeof (int) // Y
                ;
        }

        public bool NextBytesToParams (byte[] bytes, ref int currentByteIndex) {
            // X
            if (!BitConvertionUtils.NextBytesToInt (bytes, ref currentByteIndex, out x))
                return false;
            // Y
            if (!BitConvertionUtils.NextBytesToInt (bytes, ref currentByteIndex, out y))
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
            if (obj is not Vector2Int other)
                return false;

            return this.x.Equals (other.x)
                && this.y.Equals (other.y);
        }

        #endregion

        #region Override Operators

        public static Vector2Int operator - (Vector2Int v) {
            return new Vector2Int (-v.x, -v.y);
        }

        public static Vector2Int operator + (Vector2Int a, Vector2Int b) {
            return new Vector2Int (a.x + b.x, a.y + b.y);
        }

        public static Vector2Int operator - (Vector2Int a, Vector2Int b) {
            return new Vector2Int (a.x - b.x, a.y - b.y);
        }

        public static Vector2Int operator * (Vector2Int v, int mult) {
            return new Vector2Int (v.x * mult, v.y * mult);
        }

        #endregion

    }
}
