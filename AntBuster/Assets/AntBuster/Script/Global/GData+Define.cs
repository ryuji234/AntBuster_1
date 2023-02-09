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
}       // PuzzleType ���ڿ� 1��1 ������ ���� �G�� ������ ������ ������ ù �κ��� 0���� �����Ѵ�.
        // ���α׷����� -1�� ���������� ��Ȳ �̱� ������ NONE = -1�� ���ִ� ��