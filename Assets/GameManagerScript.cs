using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Networking.PlayerConnection;
using UnityEditor.Timeline;
using UnityEditor.UIElements;
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


    Vector2Int GetPlayerIndex()
    {
        for (int y = 0; y < field.GetLength(0); y++)
        {
            for (int x = 0; x < field.GetLength(1); x++)
            {
                if (field[y, x] == null) { continue; }
                if (field[y, x].tag == "Player")
                {
                    return new Vector2Int(x, y);
                }

            }
        }
        return new Vector2Int(-1, -1);
    }

    bool MoveNumber(string tag, Vector2Int moveFrom, Vector2Int moveTo)
    {
        //移動先が範囲外なら移動不可
        if (moveTo.y < 0 || moveTo.y >= field.GetLength(0)) { return false; }
        if (moveTo.x < 0 || moveTo.x >= field.GetLength(1)) { return false; }
        //移動先に2(箱)がいたら
        if (field[moveTo.y, moveTo.x] != null && field[moveTo.y,moveTo.x].tag=="Box" )
        {
            //どの方向に移動するか
            Vector2Int velocity = moveTo - moveFrom;
            //プレイヤーの移動先から、さらに先へ2(箱)を移動させる
            bool success = MoveNumber(tag, moveTo, moveTo + velocity);
            //もし箱が移動失敗したら、プレイヤーの移動も不可
            if (!success) { return false; }
        }
        //プレイヤーと箱の移動処理
        field[moveFrom.y, moveTo.x].transform.position =
            new Vector3(moveTo.x, field.GetLength(0) - moveTo.y, 0);
        field[moveTo.y, moveTo.x] = field[moveTo.y,moveTo.x];
        field[moveFrom.y, moveFrom.x] = null;
        return true;
    }

    // Update is called once per frame
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
