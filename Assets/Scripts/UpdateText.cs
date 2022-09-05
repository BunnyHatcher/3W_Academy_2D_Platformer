using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateText : MonoBehaviour
{
    [SerializeField] private IntVariable _beersCollected;
    
    private void Awake()
    {
        _label = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _label.text = _beersCollected.m_value.ToString();
    }



    private TextMeshProUGUI _label;
}
