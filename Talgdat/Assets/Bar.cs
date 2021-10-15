using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    private const float camWidth = 16f;
    private const float camHeight = 9f;
    public AudioSource AudioSource { get => _audioSource; }
    public float value { set { _value = value; UpdateTransform(); } }
    public float index { set { _index = value; UpdateTransform(); } }
    public int ActiveWrites { get => _activeWrites; }
    private float _value;
    private float _index;
    private int _activeWrites;

    private float _currentValue;
    private float _currentPos;
    private AudioSource _audioSource;
    [SerializeField] private Material _initialMat;
    [SerializeField] private Material _readMat;
    [SerializeField] private Material _writeMat;
    [SerializeField] private MeshRenderer _renderer;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _currentPos = 0f;
        _currentValue = 0f;
        UpdateTransform();
    }

    public void Mark(string tag)
    {
        if (tag == "read") SetMaterial(_readMat);
        if (tag == "write") SetMaterial(_writeMat);
        _activeWrites++;
    }
    public void Unmark()
    {
        if (_activeWrites > 0) _activeWrites--;
        if (_activeWrites <= 0) SetMaterial(_initialMat);
    }
    private void SetMaterial(Material mat)
    {
        _renderer.material = mat;
    }
    private void UpdateTransform()
    {
        float barWidth = camWidth / ProblemConfig.Instance.Count;
        float barHeight = _value*camHeight / ProblemConfig.Instance.Max;
        transform.localPosition = new Vector3(_index*barWidth, barHeight/2f, 0f);
        transform.localScale = new Vector3(barWidth, barHeight, 1f);
    }
}
