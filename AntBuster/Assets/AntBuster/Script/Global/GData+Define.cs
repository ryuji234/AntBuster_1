using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class GData 
{
    public const string SCENE_NAME_TITLE = "TitleScene";
    public const string SCENE_NAME_PLAY = "PlayScene";

    public const string OBJ_NAME_CURRENT_LEVEL = "Level_1";
}
public enum PuzzleType
{
    NONE = -1, PUZZLE_BIG_TRIANGLE, PUZZLE_MIDDLE_TRIANGLE, PUZZLE_PARALLELOGRAM, PUZZLE_SMALL_TRIANGLE, PUZZLE_SQUARE
}       // PuzzleType 숫자와 1대1 맵핑을 해줌 숮자 지정을 해주지 않으면 첫 부분은 0으로 시작한다.
        // 프로그램에서 -1은 비정상적인 상황 이기 때문에 NONE = -1을 해주는 것