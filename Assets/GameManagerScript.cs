using System.Collections;
using System.Collections.Generic;
using UnityEditor.Networking.PlayerConnection;
using UnityEditor.Timeline;
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
    //    //�ړ��悪�͈͊O�Ȃ�ړ��s��
    //    if (moveTo < 0 || moveTo >= map.Length) { return false; }
    //    //�ړ����2(��)��������
    //    if (map[moveTo] == 2)
    //    {
    //        //�ǂ̕����Ɉړ����邩
    //        int velocity = moveTo - moveFrom;
    //        //�v���C���[�̈ړ��悩��A����ɐ��2(��)���ړ�������
    //        bool success = MoveNumber(2, moveTo, moveTo + velocity);
    //        //���������ړ����s������A�v���C���[�̈ړ����s��
    //        if (!success) { return false; }
    //    }
    //    //�v���C���[�Ɣ��̈ړ�����
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
