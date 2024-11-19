using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateAttack : PlayerState
{
    private float _delay = 2;
    private WaitForSeconds _wait;

    // ���ݿ��� �Һ��� �߰�
    private bool _isFinishAttack;
    
    public StateAttack(PlayerController controller) : base(controller)
    {
        
    }

    public override void Init()
    {
        _wait = new WaitForSeconds(_delay);
        ThisType = StateType.Attack;
    }

    // ���ݻ����̹Ƿ� bool ���� true
    public override void Enter()
    {
        _isFinishAttack = true;
        Controller.StartCoroutine(DelayRoutine(Attack));
    }

    public override void OnUpdate()
    {
        Debug.Log("Attack On Update");

        // ������ ������ Idle���·� ��ȯ.
        if(_isFinishAttack == false)
        {
            Machine.ChangeState(StateType.Idle);
        }
    }

    public override void Exit()
    {
        //Machine.ChangeState(StateType.Idle);
    }

    private void Attack()
    {
        Collider[] cols = Physics.OverlapSphere(
            Controller.transform.position,
            Controller.AttackRadius
            );

        IDamagable damagable;

        //IDamagable�� ������ ���͸� TakeHit�ϵ��� ����.
        foreach (Collider col in cols)
        {
            damagable = col.GetComponent<IDamagable>();
            if(damagable != null)
            {
                damagable.TakeHit(Controller.AttackValue);
            }
        }

        //������ ������ false
        _isFinishAttack = false;
    }

    public IEnumerator DelayRoutine(Action action)
    {
        yield return _wait;

        Attack();
        //Exit();

    }

}
