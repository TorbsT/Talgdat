using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public int value { set { _value = value; } }
    public float pos { set { _pos = value; } }
    private int _value;
    private float _pos;

    private float _currentValue;
    private float _currentPos;

    private void Start()
    {
        _currentPos = 0f;
        _currentValue = 0f;
        UpdateTransform();
    }
    private void Update()
    {
        _currentValue = Mathf.Lerp(_currentValue, _value, 0.2f);
        _currentPos = Mathf.Lerp(_currentPos, _pos, 0.2f);
        UpdateTransform();
    }

    private void UpdateTransform()
    {
        transform.localPosition = new Vector3(_currentPos, _currentValue/2f, 0f);
        transform.localScale = new Vector3(1f, _currentValue, 1f);
    }
}
