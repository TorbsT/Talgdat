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
    private float _value;
    private float _index;

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
        float barWidth = camWidth / Talgdat.ProblemConfig.Count;
        float barHeight = _value*camHeight / Talgdat.ProblemConfig.Max;
        transform.localPosition = new Vector3(_index*barWidth, barHeight/2f, 0f);
        transform.localScale = new Vector3(barWidth, barHeight, 1f);
    }
}
