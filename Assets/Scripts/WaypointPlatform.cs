using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointPlatform : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoint;

    [SerializeField] private float _speed = 10;

    private void Start()
    {
        _targetPlatform = 0;
        transform.position = _waypoint[0].position;
    }

    private void Update()
    {
        Vector3 position = Vector3.MoveTowards(transform.position, _waypoint[_targetPlatform + 1].position, _speed * Time.deltaTime );
        
        transform.position = position;
    }

    private int _targetPlatform;
}
