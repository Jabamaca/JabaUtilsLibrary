using JabaUtilsLibrary.Data.DataStructs;
using JabaUtilsLibrary.GameLogic.Defines;
using System;
using System.Collections.Generic;

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

        private const int HEXAGON_SIDE_COUNT = 6;
        private static readonly Vector2Int PosRotateX = new Vector2Int (1, 1);
        private static readonly Vector2Int PosRotateY = new Vector2Int (-1, 1);
        private static readonly Vector2Double HRotationX = new Vector2Double (0.5f, 0.5f);
        private static readonly Vector2Double HRotationY = new Vector2Double (-1f, 1f);
        private static readonly Vector2Double VRotationX = new Vector2Double (1f, -1f);
        private static readonly Vector2Double VRotationY = new Vector2Double (0.5f, 0.5f);
        private static readonly Vector2Double[] HRotateMatrix = { HRotationX, HRotationY, };
        private static readonly Vector2Double[] VRotateMatrix = { VRotationX, VRotationY, };

        #endregion

        #region Methods

        #region Positional Methods

        public static int DistanceFromCenter (Vector2Int hexC) {
            int absX = Math.Abs (hexC.x);
            int absY = Math.Abs (hexC.y);

            if (hexC.x * hexC.y > 0) {
                return absX >= absY ? absX : absY;
            } else {
                return absX + absY;
            }
        }

        public static Vector2Int FromToDifference (Vector2Int hexFrom, Vector2Int hexTo) {
            return hexTo - hexFrom;
        }

        public static int FromToDistance (Vector2Int hexFrom, Vector2Int hexTo) {
            return DistanceFromCenter (FromToDifference (hexFrom, hexTo));
        }

        public static IReadOnlyList<Vector2Int> HexCoordsInRangeFromHexCoord (Vector2Int origin, int r) {
            // Range is less than or equal 0, return only Origin.
            if (r <= 0) {
                Vector2Int[] onlyCenter = { origin.Copy () };
                return onlyCenter;
            }

            // Determine coords count.
            int rangeCap = 3 * (r * r + r) + 1;
            Vector2Int[] returnArray = new Vector2Int[rangeCap];

            returnArray[0] = origin.Copy (); // Add Origin.
            int ci = 1, oX = origin.x, oY = origin.y; // Current Index, Origin-X, Origin-Y

            for (int cr = 1; cr <= r; cr++) {
                // Add Axis Coords.
                returnArray[ci] = new Vector2Int (oX + cr, oY); // Add Positive-X Axis Coord. (cr as x)
                returnArray[ci + 1] = new Vector2Int (oX - cr, oY); // Add Negative-X Axis Coord. (cr as x)
                returnArray[ci + 2] = new Vector2Int (oX, oY + cr); // Add Positive-Y Axis Coord. (cr as y)
                returnArray[ci + 3] = new Vector2Int (oX, oY - cr); // Add Negative-Y Axis Coord. (cr as y)
                ci += 4;

                // Add Positive-Quadrant Coords. (cr as x)
                for (int y = 1; y <= r; y++) {
                    returnArray[ci] = new Vector2Int (oX + cr, oY + y); // Add Quadrant-1 Coords.
                    returnArray[ci + 1] = new Vector2Int (oX - cr, oY - y); // Add Quadrant-3 Coords.
                    ci += 2;
                }

                // Add Negative-Quadrant Coords. (cr as x)
                for (int y = 1; cr + y <= r; y++) {
                    returnArray[ci] = new Vector2Int (oX - cr, oY + y); // Add Quadrant-2 Coords.
                    returnArray[ci + 1] = new Vector2Int (oX + cr, oY - y); // Add Quadrant-4 Coords.
                    ci += 2;
                }
            }

            return returnArray;
        }

        public static IReadOnlyList<Vector2Int> HexCoordsInRange (int r) {
            return HexCoordsInRangeFromHexCoord (HexCenter, r);
        }

        public static Vector2Int Rotate (Vector2Int startPos, int faceCount, RotationModeEnum rotateMode, Vector2Int centerPos) {
            faceCount %= HEXAGON_SIDE_COUNT; // Remove full revolutions.

            // If no face-rotation count, or start-position is center.
            if (faceCount == 0
                || startPos.Equals (centerPos)) {
                return startPos.Copy (); // Return as is.
            }

            switch (rotateMode) {
                case RotationModeEnum.CLOCKWISE:
                    // Keep rotation as is.
                    break;
                case RotationModeEnum.ANTI_CLOCKWISE:
                    faceCount = HEXAGON_SIDE_COUNT - faceCount; // Convert to equivalent clockwise rotation.
                    break;
                default:
                    return startPos.Copy (); // ERROR: Return as is.
            }

            Vector2Int diffPos = startPos - centerPos;

            // Shortcut for >= half-revolution.
            if (faceCount >= 3) {
                diffPos *= -1; // Make half-revolution.
                faceCount %= 3;
            }

            for (int i = 0; i < faceCount; i++) {
                diffPos = CenterRotateSingleClockwise (diffPos);
            }

            return centerPos + diffPos;
        }

        private static Vector2Int CenterRotateSingleClockwise (Vector2Int hexPos) {
            Vector2Int xR = PosRotateX;
            Vector2Int yR = PosRotateY;
            int xRPos = (xR.x * hexPos.x) + (xR.y * hexPos.y) - hexPos.x;
            int yRPos = (yR.x * hexPos.x) + (yR.y * hexPos.y);

            return new Vector2Int (xRPos, yRPos);
        }

        #endregion

        #region Displaying Methods

        public static Vector2Double HexCoordHorizontalRenderPosition (Vector2Int hexPos, Vector2Double unitSize) {
            return HexCoordRenderPosition (hexPos, unitSize, HRotateMatrix);
        }

        public static Vector2Double HexCoordVerticalRenderPosition (Vector2Int hexPos, Vector2Double unitSize) {
            return HexCoordRenderPosition (hexPos, unitSize, VRotateMatrix);
        }

        private static Vector2Double HexCoordRenderPosition (Vector2Int hexPos, Vector2Double unitSize, Vector2Double[] rotationMatrix) {
            Vector2Double xR = rotationMatrix[0];
            Vector2Double yR = rotationMatrix[1];
            double xRPos = ((xR.x * hexPos.x) + (xR.y * hexPos.y)) * unitSize.x;
            double yRPos = ((yR.x * hexPos.x) + (yR.y * hexPos.y)) * unitSize.y;

            return new Vector2Double (xRPos, yRPos);
        }

        #endregion

        #endregion

    }
}