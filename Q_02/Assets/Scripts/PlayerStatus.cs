using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

    // 프로퍼티와 연동해줄 private 변수 추가.
    private float _moveSpeed;

    //프로퍼티 내부에 private변수와 연동. 
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
        //private 변수로 대체.
        _moveSpeed = 5f;
    }
}
