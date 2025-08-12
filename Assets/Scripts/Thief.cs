using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour
{
    [SerializeField] private float _stepDistance = .5f;
    [SerializeField] private List<Transform> _targets;

    private int _currentTargetIndex = 0;

    private Transform CurrentTarget;

    private void Start()
    {
        if (_targets.Count < 1)
            return;

        CurrentTarget = _targets[_currentTargetIndex];
    }

    private void Update()
    {
        if (CurrentTarget == null)
            return;

        transform.position = Vector3.MoveTowards(transform.position, CurrentTarget.position, _stepDistance * Time.deltaTime);

        if (transform.position.x == CurrentTarget.position.x && transform.position.z == CurrentTarget.position.z)
            SwitchTarget();
    }

    private void SwitchTarget()
    {
        if (_targets.Count < 1)
            return;

        _currentTargetIndex = ++_currentTargetIndex % _targets.Count;
        CurrentTarget = _targets[_currentTargetIndex];

        var targetPosiotion = CurrentTarget.transform.position;
        transform.forward = targetPosiotion - transform.position;
    }
}
