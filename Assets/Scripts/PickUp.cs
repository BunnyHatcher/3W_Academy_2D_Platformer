using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    [SerializeField] private IntVariable _beersCollected;

    [SerializeField] private int _score = 1;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag("Player") )
        {
            _beersCollected.m_value += _score;
            //Debug.Log(_beersCollected.m_value);
            Destroy(gameObject);

        }
    }
}
