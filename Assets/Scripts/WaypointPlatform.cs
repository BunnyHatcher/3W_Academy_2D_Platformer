using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointPlatform : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoint;

    [SerializeField] private float _speed = 10;

    [SerializeField] private float _reachTolerance = 0.1f;

    private void Start()
    {
        
        transform.position = _waypoint[0].position;
        _targetWayPointIndex = 1;

    }

    private void Update()
    {
        Vector3 currentWaypointPosition = _waypoint[_targetWayPointIndex].position;

        Vector3 position = Vector3.MoveTowards(transform.position, currentWaypointPosition, _speed * Time.deltaTime);

        transform.position = position;

        // if platform gets close enough to the next waypont position,
        // the method switches to the next waypoint position

        if (Vector3.Distance(transform.position, currentWaypointPosition) <= _reachTolerance)
        {



            /* Loop
          
            _targetWayPointIndex++;

            if (_targetWayPointIndex >= _waypoint.Length)
            {
             _targetWayPointIndex = 0;
            }
           */

            // Ping-Pong
            
            if (_isForward)
            {
                _targetWayPointIndex++;

                if (_targetWayPointIndex >= _waypoint.Length - 1)
                {
                    _isForward = false;
                }
            }

            else
            {
                _targetWayPointIndex--;
                if (_targetWayPointIndex <= 0)
                {
                    _isForward = true;
                }
            }

        }

    }
       


    private int _targetWayPointIndex;

    private bool _isForward = true;
}
