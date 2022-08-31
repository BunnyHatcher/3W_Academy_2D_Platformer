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



    private TextMeshProUGUI _label;
}
