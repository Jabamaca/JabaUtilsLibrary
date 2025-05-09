using JabaUtilsLibrary.Data;
using JabaUtilsLibrary.Data.DataStructs;
using JabaUtilsLibrary.GameLogic;
using JabaUtilsLibrary.GameLogic.Defines;
using System.Collections.Generic;
using Xunit;

namespace JabaUtilsLibrary_UnitTest.Tests.GameLogicTest {
    public class GameLogicTest_HexCoord {

        #region Test Methods

        private void TestMethod_TestPositionRotation (Vector2Int startPos, int faceCount, RotationModeEnum rotateMode, 
            Vector2Int centerPos, Vector2Int expectedResult) {

            Vector2Int actualResult = HexCoord.Rotate (startPos, faceCount, rotateMode, centerPos);
            Assert.True (expectedResult.Equals (actualResult));
        }

        private void TestMethod_TestDistanceFromCenter (Vector2Int hexPos, int expectedDist) {
            int dist = HexCoord.DistanceFromCenter (hexPos);
            Assert.Equal (expectedDist, dist);
        }

        #endregion

        #region Main Tests

        [Fact]
        public void GameLogicTest_HexCoord_DistanceFromCenter () {
            int size = 10; // Determine size of array.

            // Test positive-quadrant distances.
            /*
             * POSITIVE-QUADRANT DISTANCE SAMPLE (origin at bottom-left, Quadrant-1)
             * 3 3 3 3
             * 2 2 2 3
             * 1 1 2 3
             * 0 1 2 3
             */
            for (int dist = 0; dist < size; dist++) {
                for (int i = 0; i < dist; i++) {
                    TestMethod_TestDistanceFromCenter (new Vector2Int (i, dist), dist); // Test (45 < x < 90) Degree coords.
                    TestMethod_TestDistanceFromCenter (new Vector2Int (dist, i), dist); // Test (0 < x < 45) Degree coords.
                    TestMethod_TestDistanceFromCenter (new Vector2Int (-i, -dist), dist); // Test (225 < x < 270) Degree coords.
                    TestMethod_TestDistanceFromCenter (new Vector2Int (-dist, -i), dist); // Test (180 < x < 225) Degree coords.
                }
                TestMethod_TestDistanceFromCenter (new Vector2Int (dist, dist), dist); // Test (x == 45) Degree coords.
                TestMethod_TestDistanceFromCenter (new Vector2Int (-dist, -dist), dist); // Test (x == 225) Degree coords.
            }
            // Test positive-quadrant distances

            /*
             * NEGATIVE-QUADRANT DISTANCE SAMPLE (origin at bottom-right, Quadrant-2)
             * 6 5 4 3
             * 5 4 3 2
             * 4 3 2 1
             * 3 2 1 0
             */
            // Generate negative-quadrant distances.
            for (int x = 0; x < size; x++) {
                for (int y = 0; y < size; y++) {
                    int dist = x + y;
                    TestMethod_TestDistanceFromCenter (new Vector2Int (-x, y), dist); // Test Quadrant-2 coords.
                    TestMethod_TestDistanceFromCenter (new Vector2Int (x, -y), dist); // Test Quadrant-4 coords.
                }
            }
        }

        [Fact]
        public void GameLogicTest_HexCoord_DiffAndDistance () {
            Vector2Int fromCoord = new Vector2Int (-5, 8);
            Vector2Int toCoord = new Vector2Int (3, -6);
            Vector2Int expectedDiff = new Vector2Int (8, -14);
            int expectedDistance = 22;

            Vector2Int actualDiff = HexCoord.FromToDifference (fromCoord, toCoord);
            Assert.True (expectedDiff.Equals (actualDiff));
            Assert.Equal (expectedDistance, HexCoord.FromToDistance (fromCoord, toCoord));
            Assert.Equal (expectedDistance, HexCoord.DistanceFromCenter (actualDiff));
        }

        [Fact]
        public void GameLogicTest_HexCoord_GetCoordsInRange_UniqueResults () {
            int range = 1, expectedCount = 7;

            // From Dictated Origin.
            Vector2Int nonZeroOrigin = new Vector2Int (-820, 17);
            List<Vector2Int> nonZeroExpectedUnique = new List<Vector2Int> {
                new Vector2Int (-820, 17),
                new Vector2Int (-819, 17),
                new Vector2Int (-821, 17),
                new Vector2Int (-820, 16),
                new Vector2Int (-820, 18),
                new Vector2Int (-819, 18),
                new Vector2Int (-821, 16),
            };

            List<Vector2Int> nonZeroActualUnique = new List<Vector2Int> ();
            nonZeroActualUnique.AddRange (HexCoord.HexCoordsInRange (nonZeroOrigin, range));

            Assert.Equal (expectedCount, nonZeroActualUnique.Count);
            Assert.True (ListUtils.CheckUnorderedEquals (nonZeroExpectedUnique, nonZeroActualUnique));

            List<Vector2Int> zeroExpectedUnique = new List<Vector2Int> {
                new Vector2Int (0, 0),
                new Vector2Int (0, 1),
                new Vector2Int (0, -1),
                new Vector2Int (1, 1),
                new Vector2Int (-1, -1),
                new Vector2Int (1, 0),
                new Vector2Int (-1, 0),
            };

            List<Vector2Int> zeroActualUnique = new List<Vector2Int> ();
            zeroActualUnique.AddRange (HexCoord.HexCoordsInRange (range));

            Assert.Equal (expectedCount, zeroActualUnique.Count);
            Assert.True (ListUtils.CheckUnorderedEquals (zeroExpectedUnique, zeroActualUnique));
        }

        [Fact]
        public void GameLogicTest_HexCoord_RotationTest_Fail () {
            TestMethod_TestPositionRotation (
                startPos: new Vector2Int (-1, -1),
                faceCount: 1,
                rotateMode: RotationModeEnum.NULL,
                centerPos: new Vector2Int (0, 0),
                expectedResult: new Vector2Int (-1, -1)
            );
        }

        [Fact]
        public void GameLogicTest_HexCoord_RotationTests () {
            // Basic Rotation Test (Single)
            TestMethod_TestPositionRotation (
                startPos: new Vector2Int (-1, -1),
                faceCount: 1,
                rotateMode: RotationModeEnum.ANTI_CLOCKWISE,
                centerPos: new Vector2Int (0, 0),
                expectedResult: new Vector2Int (0, -1)
            );

            // Post Half-Revolution Test
            TestMethod_TestPositionRotation (
                startPos: new Vector2Int (0, -1),
                faceCount: 4,
                rotateMode: RotationModeEnum.ANTI_CLOCKWISE,
                centerPos: new Vector2Int (0, 0),
                expectedResult: new Vector2Int (-1, 0)
            );

            // Post Full-Revolution Test
            TestMethod_TestPositionRotation (
                startPos: new Vector2Int (4, 0),
                faceCount: 20,
                rotateMode: RotationModeEnum.CLOCKWISE,
                centerPos: new Vector2Int (0, 0),
                expectedResult: new Vector2Int (-4, -4)
            );

            // Non-Zero Center Reference Test
            TestMethod_TestPositionRotation (
                startPos: new Vector2Int (54, 25),
                faceCount: 65,
                rotateMode: RotationModeEnum.ANTI_CLOCKWISE,
                centerPos: new Vector2Int (50, 25),
                expectedResult: new Vector2Int (50, 21)
            );

            // Distant Non-Axial Position Test
            TestMethod_TestPositionRotation (
                startPos: new Vector2Int (143, 78),
                faceCount: 2,
                rotateMode: RotationModeEnum.CLOCKWISE,
                centerPos: new Vector2Int (128, 67),
                expectedResult: new Vector2Int (124, 52)
            );

            // Similar Result Counter-Rotation Test
            TestMethod_TestPositionRotation (
                startPos: new Vector2Int (143, 78),
                faceCount: 124,
                rotateMode: RotationModeEnum.ANTI_CLOCKWISE,
                centerPos: new Vector2Int (128, 67),
                expectedResult: new Vector2Int (124, 52)
            );

            // Half-Revolution Test
            TestMethod_TestPositionRotation (
                startPos: new Vector2Int (79, -88),
                faceCount: 69,
                rotateMode: RotationModeEnum.ANTI_CLOCKWISE,
                centerPos: new Vector2Int (-11, -37),
                expectedResult: new Vector2Int (-101, 14)
            );
        }

        #endregion

    }
}
