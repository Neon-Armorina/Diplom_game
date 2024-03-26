using FSM.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMStateMove : FSMState
{
    protected readonly Transform Transform;
    protected readonly float _speed;

    public FSMStateMove(Fsm fsm, Transform transform, float speed) : base(fsm) 
    {
        Transform = transform;
        _speed = speed;
    }

    public override void Enter()
    {
        Debug.Log($"Move ({this.GetType().Name}) state [ENTER]");
    }

    public override void Exit()
    {
        Debug.Log($"Move ({this.GetType().Name}) state [EXIT]");
    }

    public override void Update()
    {
        Debug.Log($"Move ({this.GetType().Name}) state [UPDATE]");

        if (Input.GetAxis(Horizontal) == 0)
        {
            Fsm.SetState<FSMStateIdle>();
        }

        Move();
    }

    protected virtual void Move()
    {
       Transform.Translate(Input.GetAxis(Horizontal) * Vector3.right * Time.deltaTime * _speed);
    }


}
