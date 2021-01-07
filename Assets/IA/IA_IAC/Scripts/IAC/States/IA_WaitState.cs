using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_WaitState : StateMachineBehaviour
{
    [SerializeField] string waitParam = "wait_time";
    [SerializeField,Header("Min wait value")] float minValue = .1f;
    [SerializeField, Header("Max wait value")] float maxValue = 2;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (minValue > maxValue) minValue = maxValue;
        animator.SetFloat(waitParam, Random.Range(minValue, maxValue));

    }

}
