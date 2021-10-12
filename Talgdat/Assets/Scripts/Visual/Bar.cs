using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public AudioSource AudioSource { get => _audioSource; }
    public int value { set { _value = value; UpdateTransform(); } }
    public float index { set { _index = value; UpdateTransform(); } }
    private int _value;
    private float _index;

    private float _currentValue;
    private float _currentPos;
    private AudioSource _audioSource;
    private MeshRenderer _renderer;
    [SerializeField] private Material _initialMat;
    [SerializeField] private Material _readMat;
    [SerializeField] private Material _writeMat;
    private void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        _audioSource = GetComponent<AudioSource>();
        _currentPos = 0f;
        _currentValue = 0f;
        UpdateTransform();
    }

    public void Mark(string tag)
    {
        if (tag == "read") SetMaterial(_readMat);
        if (tag == "write") SetMaterial(_writeMat);
    }
    public void Unmark()
    {
        SetMaterial(_initialMat);
    }
    private void SetMaterial(Material mat)
    {
        _renderer.material = mat;
    }
    private void UpdateTransform()
    {
        transform.localPosition = new Vector3(_index, _value/2f, 0f);
        transform.localScale = new Vector3(1f, _value, 1f);
    }
}
