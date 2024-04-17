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

    int[,] map; // ���x���f�U�C���p�̔z��
    GameObject[,] field; //�@�Q�[���Ǘ��p�̔z��

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
        //�ړ��悪�͈͊O�Ȃ�ړ��s��
        if (moveTo.y < 0 || moveTo.y >= field.GetLength(0)) { return false; }
        if (moveTo.x < 0 || moveTo.x >= field.GetLength(1)) { return false; }
        //�ړ����2(��)��������
        if (field[moveTo.y, moveTo.x] != null && field[moveTo.y,moveTo.x].tag=="Box" )
        {
            //�ǂ̕����Ɉړ����邩
            Vector2Int velocity = moveTo - moveFrom;
            //�v���C���[�̈ړ��悩��A����ɐ��2(��)���ړ�������
            bool success = MoveNumber(tag, moveTo, moveTo + velocity);
            //���������ړ����s������A�v���C���[�̈ړ����s��
            if (!success) { return false; }
        }
        //�v���C���[�Ɣ��̈ړ�����
        field[moveFrom.y, moveTo.x].transform.position =
            new Vector3(moveTo.x, field.GetLength(0) - moveTo.y, 0);
        field[moveTo.y, moveTo.x] = field[moveTo.y,moveTo.x];
        field[moveFrom.y, moveFrom.x] = null;
        return true;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    //�\���L�[�E�ŉE�Ɉ�����
    //    if (Input.GetKeyDown(KeyCode.RightArrow))
    //    {
    //        //1,1���i�[����Ă���C���f�b�N�X���m�F����
    //        //������Ȃ��������̂��߂�-1�ŏ�����
    //        int playerIndex = GetPlayerIndex();

    //        MoveNumber(1, playerIndex, playerIndex + 1);
    //        PrintArray();
    //    }
    //    //�\���L�[���ō��Ɉ�����
    //    if (Input.GetKeyDown(KeyCode.LeftArrow))
    //    {
    //        int playerIndex = GetPlayerIndex();

    //        MoveNumber(1, playerIndex, playerIndex - 1);
    //        PrintArray();
    //    }
    //}
}
