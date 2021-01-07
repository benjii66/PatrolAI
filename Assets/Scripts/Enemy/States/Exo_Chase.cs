using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Exo_Chase : StateMachineBehaviour
{
    public event Action OnChase = null;

    [SerializeField] Exo_Player player = null;
    [SerializeField, Range(1, 75)] float visibiltyRange = 5;
    [SerializeField, Range(1, 100)] float movementSpeed = 6;

    Vector3 playerPosition => player.transform.position;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.GetComponent<Exo_Player>();
        MoveToPlayer(animator, visibiltyRange);
    }

    void MoveToPlayer(Animator _animator, float _visibility)
    {
        //float _distance = Vector3.Distance(targetPos, transform.position);
        float _distance = Vector3.Distance(_animator.transform.position, playerPosition);

        //if _distance > visibiltyRange
        if(_distance < _visibility)
        {
            Debug.Log("Now he'll chase");
            OnChase?.Invoke();
            _animator.transform.position += _animator.transform.forward * movementSpeed * Time.deltaTime;
        }
       


    }


   

}
