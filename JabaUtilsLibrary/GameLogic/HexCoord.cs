using System;
using System.Collections.Generic;
using JabaUtilsLibrary.Data.DataStructs;

namespace JabaUtilsLibrary.GameLogic {
    public static class HexCoord {

        #region Constants

        public static readonly Vector2Int HexUL = new Vector2Int (-1, 0);
        public static readonly Vector2Int HexUR = new Vector2Int (0, 1);
        public static readonly Vector2Int HexDL = new Vector2Int (0, -1);
        public static readonly Vector2Int HexDR = new Vector2Int (1, 0);
        public static readonly Vector2Int HexLeft = new Vector2Int (-1, -1);
        public static readonly Vector2Int HexRight = new Vector2Int (1, 1);
        public static readonly Vector2Int HexCenter = Vector2Int.Zero ();

        private static readonly Vector2Double HRotationX = new Vector2Double (0.5f, 0.5f);
        private static readonly Vector2Double HRotationY = new Vector2Double (-1f, 1f);
        private static readonly Vector2Double VRotationX = new Vector2Double (1f, -1f);
        private static readonly Vector2Double VRotationY = new Vector2Double (0.5f, 0.5f);
        private static readonly Vector2Double[] HRotateMatrix = { HRotationX, HRotationY, };
        private static readonly Vector2Double[] VRotateMatrix = { VRotationX, VRotationY, };

        #endregion

        #region Methods

        public static int DistanceFromCenter (Vector2Int hexC) {
            Vector2Int hexRef = hexC;
            int axialD = 0;

            if (hexC.x < 0 && hexC.y < 0) {
                axialD = hexC.x > hexC.y ? -hexC.x : -hexC.y;
                hexRef.Add (axialD, axialD);
            } else if (hexC.x > 0 && hexC.y > 0) {
                axialD = hexC.x < hexC.y ? hexC.x : hexC.y;
                hexRef.Add (axialD, axialD);
            }

            return axialD + Math.Abs (hexRef.x) + Math.Abs (hexRef.y);
        }

        public static Vector2Int FromToDifference (Vector2Int hexFrom, Vector2Int hexTo) {
            return hexTo - hexFrom;
        }

        public static int FromToDistance (Vector2Int hexFrom, Vector2Int hexTo) {
            return DistanceFromCenter (FromToDifference (hexFrom, hexTo));
        }

        public static IReadOnlyList<Vector2Int> HexCoordsInRangeFromHexCoord (Vector2Int hexFrom, int r) {
            if (r < 0) {
                return new List<Vector2Int> ();
            }

            if (r == 0) {
                Vector2Int[] center = { HexCenter };
                return center;
            }

            int rangeCap = 3 * (r * r + r) + 1;

            Vector2Int[] returnArray = new Vector2Int[rangeCap];

            // Origin
            returnArray[0] = HexCenter;
            int ci = 1; // Current Index

            for (int i = 1; i <= r; i++) {
                // Hex Diagonal Regions
                returnArray[ci] = HexUL * i + hexFrom;
                returnArray[ci + 1] = HexUR * i + hexFrom;
                returnArray[ci + 2] = HexDL * i + hexFrom;
                returnArray[ci + 3] = HexDR * i + hexFrom;
                returnArray[ci + 4] = HexLeft * i + hexFrom;
                returnArray[ci + 5] = HexRight * i + hexFrom;
                ci += 6; // New index entries.

                for (int j = 1; i + j <= r; j++) {
                    // Outskirt Triangle Regions
                    returnArray[ci] = HexLeft * i + HexUL * j + hexFrom;
                    returnArray[ci + 1] = HexLeft * i + HexDL * j + hexFrom;
                    returnArray[ci + 2] = HexRight * i + HexUR * j + hexFrom;
                    returnArray[ci + 3] = HexRight * i + HexDR * j + hexFrom;
                    returnArray[ci + 4] = new Vector2Int (hexFrom.x + i, hexFrom.y - j);
                    returnArray[ci + 5] = new Vector2Int (hexFrom.x - i, hexFrom.y + j);
                    ci += 6; // New index entries.
                }
            }

            return returnArray;
        }

        public static IReadOnlyList<Vector2Int> HexCoordsInRangeFromCenter (int r) {
            return HexCoordsInRangeFromHexCoord (HexCenter, r);
        }

        public static Vector2Double HexCoordHorizontalRenderPosition (Vector2Int hexPos, Vector2Double unitSize) {
            return HexCoordRenderPosition (hexPos, unitSize, HRotateMatrix);
        }

        public static Vector2Double HexCoordVerticalRenderPosition (Vector2Int hexPos, Vector2Double unitSize) {
            return HexCoordRenderPosition (hexPos, unitSize, VRotateMatrix);
        }

        private static Vector2Double HexCoordRenderPosition (Vector2Int hexPos, Vector2Double unitSize, Vector2Double[] rotationMatrix) {
            Vector2Double xR = rotationMatrix[0];
            Vector2Double yR = rotationMatrix[1];
            double xRPos = (xR.x * hexPos.x + xR.y * hexPos.y) * unitSize.x;
            double yRPos = (yR.x * hexPos.x + yR.y * hexPos.y) * unitSize.y;

            return new Vector2Double (xRPos, yRPos);
        }

        #endregion

    }
}