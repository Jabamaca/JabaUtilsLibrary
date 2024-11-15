using UnityEngine;
using System;
using System.Collections.Generic;

namespace JabaUtilsLibrary.Unity.GameLogic {
    public static class HexCoord {

        #region Constants

        public static readonly Vector2Int HexUL = new (-1, 0);
        public static readonly Vector2Int HexUR = new (0, 1);
        public static readonly Vector2Int HexDL = new (0, -1);
        public static readonly Vector2Int HexDR = new (1, 0);
        public static readonly Vector2Int HexLeft = new (-1, -1);
        public static readonly Vector2Int HexRight = new (1, 1);
        public static readonly Vector2Int HexCenter = Vector2Int.zero;

        private static readonly Vector2 HRotationX = new (0.5f, 0.5f);
        private static readonly Vector2 HRotationY = new (-1f, 1f);
        private static readonly Vector2 VRotationX = new (1f, -1f);
        private static readonly Vector2 VRotationY = new (0.5f, 0.5f);
        private static readonly Vector2[] HRotateMatrix = [HRotationX, HRotationY];
        private static readonly Vector2[] VRotateMatrix = [VRotationX, VRotationY];

        #endregion

        #region Methods

        public static int DistanceFromCenter (Vector2Int hexC) {
            Vector2Int hexRef = hexC;
            int axialD = 0;

            if (hexC.x < 0 && hexC.y < 0) {
                axialD = hexC.x > hexC.y ? -hexC.x : -hexC.y;
                hexRef += new Vector2Int (axialD, axialD);
            } else if (hexC.x > 0 && hexC.y > 0) {
                axialD = hexC.x < hexC.y ? hexC.x : hexC.y;
                hexRef -= new Vector2Int (axialD, axialD);
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
                return [];
            }

            if (r == 0) {
                Vector2Int[] center = [HexCenter];
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

        public static Vector2 HexCoordHorizontalRenderPosition (Vector2Int hexPos, Vector2 unitSize) {
            return HexCoordRenderPosition (hexPos, unitSize, HRotateMatrix);
        }

        public static Vector2 HexCoordVerticalRenderPosition (Vector2Int hexPos, Vector2 unitSize) {
            return HexCoordRenderPosition (hexPos, unitSize, VRotateMatrix);
        }

        private static Vector2 HexCoordRenderPosition (Vector2Int hexPos, Vector2 unitSize, Vector2[] rotationMatrix) {
            Vector2 xR = rotationMatrix[0];
            Vector2 yR = rotationMatrix[1];
            float xRPos = (xR.x * hexPos.x + xR.y * hexPos.y) * unitSize.x;
            float yRPos = (yR.x * hexPos.x + yR.y * hexPos.y) * unitSize.y;

            return new Vector2 (xRPos, yRPos);
        }

        #endregion

    }
}