using UnityEngine;

public class IA_Brain : StateMachineBehaviour
{

    #region brain_params

    [SerializeField] string moveToParam = "move_to"; 

    #endregion


    [SerializeField, Header("Think state")] IA_ThinkState thinkState= null;
    [SerializeField] IA_MoveToTarget moveToState= null;
    [SerializeField] IA_IdleState idleState= null;
    [SerializeField] IA_VisualDebug visualDebug = null;

    bool IsInit = false;

    public IA_VisualDebug VisualDebug => visualDebug;
    public bool IsValid => thinkState && moveToState && idleState && visualDebug;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        InitBrain(animator);
       
    }

    

    void InitBrain(Animator _animator)
    {
        if (IsInit) return;
        IA_State[] _states = _animator.GetBehaviours<IA_State>();
        for (int i = 0; i < _states.Length; i++)
            _states[i].InitState(this);

        //Debug.Log($"Init brain : {_animator.name}");
        //thinkState = _animator.GetBehaviour<IA_ThinkState>();
        //moveToState = _animator.GetBehaviour<IA_MoveToTarget>();
        //idleState = _animator.GetBehaviour<IA_IdleState>();
        //visualDebug = _animator.GetComponent<IA_VisualDebug>();
        //if (!IsValid) return;
        //idleState.OnInitPosition += thinkState.SetReferenceIdle;
        //thinkState.OnPositionFound += (position)=>
        //{
        //    moveToState.SetTarget(position);
        //    _animator.SetBool(moveToParam, true);
        //};
        //moveToState.OnTargetReached += () => _animator.SetBool(moveToParam, false);
        //IsInit = true;
        thinkState.Init(this);
    }
}


