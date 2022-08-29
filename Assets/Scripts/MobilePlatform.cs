using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlatform : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private float _timeToReach = 5f;

    

    // Start is called before the first frame update
    void Start()
    {
        transform.position = _startPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 lerpPosition = Vector3.Lerp(_startPoint.position, _endPoint.position, _timerMovement / _timeToReach);

        transform.position = lerpPosition;

        if (_isForward)
        {
            _timerMovement += Time.deltaTime;

            if( _timerMovement >= _timeToReach)
            {
                _isForward = false;
            }
        }

        else
        {
            _timerMovement -= Time.deltaTime;

            if(_timerMovement <= 0f)
            {
                _isForward = true;
            }
        }
    }

    private float _timerMovement = 0f;
    private bool _isForward = true;
}
