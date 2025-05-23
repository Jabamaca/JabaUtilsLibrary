using JabaUtilsLibrary.Data.BitConvertion;
using JabaUtilsLibrary.Data.Interfaces;
using System;

namespace JabaUtilsLibrary.Data.DataStructs {
    public struct Vector2Int : IBitConvertion, ICopyable<Vector2Int> {

        #region Properties

        public int x;
        public int y;

        #endregion

        #region Constructors

        public Vector2Int (int x, int y) {
            this.x = x;
            this.y = y;
        }

        #endregion

        #region Methods

        #region Modifier Methods

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

        public void ScalarMultBy (int scale) {
            x *= scale;
            y *= scale;
        }

        #endregion

        #region Getter Methods

        public int SqrMagnitude () {
            return (x * x) + (y * y);
        }

        public double Magnitude () {
            return Math.Sqrt (SqrMagnitude ());
        }

        #endregion

        #region Abstract Methods

        public static Vector2Int Zero () {
            return new Vector2Int (0, 0);
        }

        public static bool NextBytesToVector2Int (byte[] bytes, ref int currentByteIndex, out Vector2Int value) {
            value = new Vector2Int ();

            if (!value.NextBytesToParams (bytes, ref currentByteIndex))
                return false;

            return true;
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

        #region Implement ICopyable

        public Vector2Int Copy () {
            return (Vector2Int)Clone ();
        }

        public object Clone () {
            return MemberwiseClone ();
        }

        #endregion

        #region Internal Methods

        public override int GetHashCode () {
            return base.GetHashCode ();
        }

        public override bool Equals (object obj) {
            if (!(obj is Vector2Int other))
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

        public static Vector2Int operator * (Vector2Int v, int scale) {
            return new Vector2Int (v.x * scale, v.y * scale);
        }

        #endregion

    }
}
