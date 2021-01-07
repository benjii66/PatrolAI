using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class Exo_Think : StateMachineBehaviour
{
    public event Action<Vector3> OnPositionFound = null;

    Exo_Brain brain = null;

    Vector3 referencePosition = Vector3.zero;
    [SerializeField, Range(1, 10), Header("Range of the thinking sphere")] float thinkRadius = 5;

    public void Init(Exo_Brain _brain) => brain = _brain;
    public void SetReferenceIdle(Vector3 _ref) => referencePosition = _ref;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 _target = RandomPosition(referencePosition);
        brain?.VisualDebug.SetThinkCirclePosition(referencePosition);
        brain?.VisualDebug.SetThinkCircleRadius(thinkRadius);
        brain?.VisualDebug.SetThinkCircleTarget(_target);
        OnPositionFound?.Invoke(_target);
    }




    Vector3 RandomPosition(Vector3 _position)
    {
        int _angle = Random.Range(0, 360);

        Vector3 _finalPosition = Vector3.zero;

        float _x = Mathf.Cos(_angle) * thinkRadius;
        float _y = _position.y;
        float _z = Mathf.Sin(_angle) * thinkRadius;

        _finalPosition = _position + new Vector3(_x, _y, _z);

        return _finalPosition;
    }
}
