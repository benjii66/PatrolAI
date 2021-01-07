using UnityEngine;
using System;

public class IA_IdleState : StateMachineBehaviour
{
    public event Action<Vector3> OnInitPosition = null;


    Vector3 initPosition = Vector3.zero;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        initPosition = animator.transform.position;
        OnInitPosition?.Invoke(initPosition);
    }

}
