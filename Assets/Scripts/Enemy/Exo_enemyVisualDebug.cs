using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exo_enemyVisualDebug : MonoBehaviour
{
    [SerializeField] Exo_Player player = null;

    Vector3 thinkCirclePosition = Vector3.zero, thinkTarget = Vector3.zero;

    Vector3 playerPosition => player.transform.position;


    float radiusDebug = 5;
    float visionRange = 10;
    public void SetThinkCircleTarget(Vector3 _target) => thinkCirclePosition = _target;
    public void SetThinkCirclePosition(Vector3 _position) => thinkCirclePosition = _position;
    public void SetThinkCircleRadius(float _radius) => radiusDebug = _radius;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, thinkTarget);
        Gizmos.DrawWireCube(thinkTarget, Vector3.one);
        Gizmos.DrawWireSphere(thinkCirclePosition, .5f);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, visionRange);
        Gizmos.DrawLine(transform.position, playerPosition);
   
#if UNITY_EDITOR
        UnityEditor.Handles.color = Color.yellow;
        UnityEditor.Handles.CircleHandleCap(0, thinkCirclePosition, Quaternion.Euler(90, 0, 0), radiusDebug, EventType.Repaint);
#endif
    }

}
