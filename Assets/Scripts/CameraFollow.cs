using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;

    [SerializeField] private float _cameraOffset = -10f;

    [SerializeField] private float _cameraSpeed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void LateUpdate()
    {
        //Vector3 playerPosition_zOffset = new Vector3(_target.position.x, _target.position.y, _cameraOffset);

        Vector3 newPosition = Vector3.Lerp(transform.position, _target.position, _cameraSpeed * Time.deltaTime);

        newPosition.z = _cameraOffset;

        transform.position = newPosition;
    }
}
