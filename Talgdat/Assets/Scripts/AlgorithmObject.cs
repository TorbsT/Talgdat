using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Algorithm")]
public class AlgorithmObject : ScriptableObject
{
    [field: SerializeField] public string Name { get; set; }
    [field: SerializeField, TextArea] public string Instructions { get; set; }
}
