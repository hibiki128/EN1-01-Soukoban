using System.Collections;
using System.Collections.Generic;
using UnityEditor.Networking.PlayerConnection;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{

    public GameObject playerPrefab;

    int[,] map; // レベルデザイン用の配列
    GameObject[,] field; //　ゲーム管理用の配列

    void Start()
    {

        map = new int[,] {
     {0,0,0,0,0 },
     {0,0,1,0,0 },
     {0,0,0,0,0 },
     };
        string debugText = "";
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (map[y, x] == 1)
                {
                    field[y, x] = Instantiate(
                        playerPrefab,
                        new Vector3(x, map.GetLength(0) - y, 0),
                        Quaternion.identity
                        );
                }
                debugText += map[y, x].ToString() + ",";
            }
            debugText += "\n";
        }
        Debug.Log(debugText);
    }

    //void PrintArray()
    //{
    //    string debugText = "";
    //    for (int i = 0; i < map.Length; i++)
    //    {
    //        debugText += map[i].ToString() + ",";
    //    }
    //    Debug.Log(debugText);
    //}

    //Vector2Int GetPlayerIndex()
    //{
    //    for (int y = 0; y < field.GetLength(0); y++)
    //    {
    //        for (int x = 0; x < field.GetLength(1); x++)
    //        {
    //            if (map[y, x] == 1)
    //            {
    //                return 
    //            }

    //        }
    //    }
    //   return 
    //}

    //bool MoveNumber(int number, int moveFrom, int moveTo)
    //{
    //    //移動先が範囲外なら移動不可
    //    if (moveTo < 0 || moveTo >= map.Length) { return false; }
    //    //移動先に2(箱)がいたら
    //    if (map[moveTo] == 2)
    //    {
    //        //どの方向に移動するか
    //        int velocity = moveTo - moveFrom;
    //        //プレイヤーの移動先から、さらに先へ2(箱)を移動させる
    //        bool success = MoveNumber(2, moveTo, moveTo + velocity);
    //        //もし箱が移動失敗したら、プレイヤーの移動も不可
    //        if (!success) { return false; }
    //    }
    //    //プレイヤーと箱の移動処理
    //    map[moveTo] = number;
    //    map[moveFrom] = 0;
    //    return true;
    //}

    //// Start is called before the first frame update
    //void Start()
    //{
    //    map = new int[] { 0, 2, 0, 1, 0, 2, 0, 2, 0 };
    //    PrintArray();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    //十字キー右で右に一個ずれる
    //    if (Input.GetKeyDown(KeyCode.RightArrow))
    //    {
    //        //1,1が格納されているインデックスを確認する
    //        //見つからなかった時のために-1で初期化
    //        int playerIndex = GetPlayerIndex();

    //        MoveNumber(1, playerIndex, playerIndex + 1);
    //        PrintArray();
    //    }
    //    //十字キー左で左に一個ずれる
    //    if (Input.GetKeyDown(KeyCode.LeftArrow))
    //    {
    //        int playerIndex = GetPlayerIndex();

    //        MoveNumber(1, playerIndex, playerIndex - 1);
    //        PrintArray();
    //    }
    //}
}
