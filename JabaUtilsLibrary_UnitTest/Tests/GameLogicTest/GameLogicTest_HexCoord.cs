using JabaUtilsLibrary.Data.DataStructs;
using JabaUtilsLibrary.GameLogic;
using JabaUtilsLibrary.GameLogic.Defines;
using Xunit;

namespace JabaUtilsLibrary_UnitTest.Tests.GameLogicTest {
    public class GameLogicTest_HexCoord {

        #region Test Methods

        private void TestMethod_TestPositionRotation (Vector2Int startPos, int faceCount, RotationModeEnum rotateMode, 
            Vector2Int centerPos, Vector2Int expectedResult) {

            Vector2Int actualResult = HexCoord.Rotate (startPos, faceCount, rotateMode, centerPos);
            Assert.True (actualResult.Equals (expectedResult));
        }

        #endregion

        #region Main Tests

        [Fact]
        public void GameLogicTest_RotationTests () {
            TestMethod_TestPositionRotation (
                startPos: new Vector2Int (-1, -1),
                faceCount: 1,
                rotateMode: RotationModeEnum.ANTI_CLOCKWISE,
                centerPos: new Vector2Int (0, 0),
                expectedResult: new Vector2Int (0, -1)
            );

            TestMethod_TestPositionRotation (
                startPos: new Vector2Int (0, -1),
                faceCount: 4,
                rotateMode: RotationModeEnum.ANTI_CLOCKWISE,
                centerPos: new Vector2Int (0, 0),
                expectedResult: new Vector2Int (-1, 0)
            );

            TestMethod_TestPositionRotation (
                startPos: new Vector2Int (4, 0),
                faceCount: 2,
                rotateMode: RotationModeEnum.CLOCKWISE,
                centerPos: new Vector2Int (0, 0),
                expectedResult: new Vector2Int (-4, -4)
            );

            TestMethod_TestPositionRotation (
                startPos: new Vector2Int (54, 25),
                faceCount: 5,
                rotateMode: RotationModeEnum.ANTI_CLOCKWISE,
                centerPos: new Vector2Int (50, 25),
                expectedResult: new Vector2Int (50, 21)
            );

            TestMethod_TestPositionRotation (
                startPos: new Vector2Int (143, 78),
                faceCount: 2,
                rotateMode: RotationModeEnum.CLOCKWISE,
                centerPos: new Vector2Int (128, 67),
                expectedResult: new Vector2Int (124, 52)
            );
        }

        #endregion

    }
}
