using System;
using UnityEngine;

public class IA_MoveToTarget : IA_State
{

    public override void InitState(IA_Brain _brain)
    {
        base.InitState(_brain);

        OnUpdate += debug;
    }

    void debug()
    {
        Debug.Log("oui");
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
    }
    //public event Action OnTargetReached = null;

    //[SerializeField] Vector3 target = Vector3.zero;
    //[SerializeField, Range(0.1f, 10)] float minimalRange = 1;
    //[SerializeField, Range(1, 100)] float speed = 1;

    //public void SetTarget(Vector3 _target) => target = _target;
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{

    //    MoveTo(animator);

    //}
    //void MoveTo(Animator _animator)
    //{
    //    Vector3 _currentPosition = _animator.transform.position;
    //    bool _isAtPos = Vector3.Distance(_currentPosition, target) < minimalRange;

    //    if (_isAtPos)
    //    {
    //        OnTargetReached?.Invoke();
    //        return;
    //    }

    //    _animator.transform.position = Vector3.MoveTowards(_currentPosition, target, speed * Time.deltaTime);
    //}
}
