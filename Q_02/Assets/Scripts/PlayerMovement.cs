using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerStatus _status;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _status = GetComponent<PlayerStatus>();
    }

    private void Update()
    {
        MovePosition();
    }

    private void MovePosition()
    {
        Vector3 direction = Vector3.zero;
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.z = Input.GetAxisRaw("Vertical");

        if (direction == Vector3.zero) return;
        
        //normalized를 통해 정규화를 해주어, 방향벡터를 곱하게 된다면 이동속도는 오로지 MoveSpee에 의해 결정됨.
        transform.Translate(_status.MoveSpeed * Time.deltaTime * direction.normalized);
    }
}
