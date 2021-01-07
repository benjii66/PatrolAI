using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Exo_Patrol : StateMachineBehaviour
{
    public event Action OnPatrol = null;

    [SerializeField] Vector3 pointTarget = Vector3.zero;
    [SerializeField, Range(0.1f, 10)] float minimalRange = 1;
    [SerializeField, Range(1, 100)] float speedMovement = 1;

    public void SetTarget(Vector3 _target) => pointTarget = _target;
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        MoveTo(animator);
    }


    void MoveTo(Animator _animator)
    {
        Vector3 _currentPosition = _animator.transform.position;
        bool _isAtPos = Vector3.Distance(_currentPosition, pointTarget) < minimalRange;

        if (_isAtPos)
        {
            Debug.Log("Patrol à la bien");
            OnPatrol?.Invoke();
            return;
        }

        _animator.transform.position = Vector3.MoveTowards(_currentPosition, pointTarget, speedMovement * Time.deltaTime);
    }
}
