using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

    // ������Ƽ�� �������� private ���� �߰�.
    private float _moveSpeed;

    //������Ƽ ���ο� private������ ����. 
    public float MoveSpeed
    {
        get { return _moveSpeed; }
        private set { }
    }

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        //private ������ ��ü.
        _moveSpeed = 5f;
    }
}
