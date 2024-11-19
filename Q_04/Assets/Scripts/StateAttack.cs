using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateAttack : PlayerState
{
    private float _delay = 2;
    private WaitForSeconds _wait;

    // 공격여부 불변수 추가
    private bool _isFinishAttack;
    
    public StateAttack(PlayerController controller) : base(controller)
    {
        
    }

    public override void Init()
    {
        _wait = new WaitForSeconds(_delay);
        ThisType = StateType.Attack;
    }

    // 공격상태이므로 bool 변수 true
    public override void Enter()
    {
        _isFinishAttack = true;
        Controller.StartCoroutine(DelayRoutine(Attack));
    }

    public override void OnUpdate()
    {
        Debug.Log("Attack On Update");

        // 공격이 끝나면 Idle상태로 전환.
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

        //IDamagable을 보유한 몬스터만 TakeHit하도록 수정.
        foreach (Collider col in cols)
        {
            damagable = col.GetComponent<IDamagable>();
            if(damagable != null)
            {
                damagable.TakeHit(Controller.AttackValue);
            }
        }

        //공격이 끝나면 false
        _isFinishAttack = false;
    }

    public IEnumerator DelayRoutine(Action action)
    {
        yield return _wait;

        Attack();
        //Exit();

    }

}
