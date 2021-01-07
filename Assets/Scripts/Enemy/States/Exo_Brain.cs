using UnityEngine;
using System;

public class Exo_Brain : StateMachineBehaviour
{

    #region params

    [SerializeField] string patrolParam = "patrol_move";
    [SerializeField] string chaseParam = "chase_move";

    #endregion

    [SerializeField, Header("Think state")] Exo_Think thinkState = null;
    [SerializeField] Exo_Patrol patrolState = null;
    [SerializeField] Exo_Chase chaseState = null;
    [SerializeField] Exo_enemyVisualDebug visualDebug= null;
    [SerializeField, Range(1, 75)] float visibiltyRange = 5;

    bool isInit = false;

    bool IsValidParams => patrolState && chaseState;

    public Exo_enemyVisualDebug VisualDebug => visualDebug;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        InitBrain(animator);
    }


    void InitBrain(Animator _animator)
    {
        if (!isInit) return;
        Debug.Log($"Init brain : {_animator.name}");
        thinkState = _animator.GetBehaviour<Exo_Think>();
        patrolState = _animator.GetBehaviour<Exo_Patrol>();
        visualDebug = _animator.GetComponent<Exo_enemyVisualDebug>();
        if (!IsValidParams) return;
        ////chaseState = _animator.GetBehaviour<Exo_Chase>();
        //chaseState.OnChase+= () =>
        //{
        //    _animator.SetBool(patrolParam, false);
        //    _animator.SetBool(chaseParam, true);
        //};
        thinkState.OnPositionFound += (position) =>
        {
            patrolState.SetTarget(position);
            _animator.SetBool(patrolParam, true);
        };

        isInit = true;
        thinkState.Init(this);
        //event action of everyparams

        //create an event OnChase, an event OnPatrol ? 

    }

   
}
