using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talgdat : MonoBehaviour
{
    public static ProblemConfig ProblemConfig { get => Instance._problemConfig; }
    public static Talgdat Instance { get; private set; }
    public static GameObject BarPrefab { get => Instance._barPrefab; }
    public static AudioSource AudioSource { get => Instance._audioSource; }

    [SerializeReference] private Controller _controller;
    [SerializeField] GameObject _barPrefab;
    [SerializeField] private ProblemConfig _problemConfig;
    private AudioSource _audioSource;
    private void Start()
    {
        Instance = this;
        _audioSource = GetComponent<AudioSource>();
        _controller = new Controller();
    }
    private void Update()
    {
        _controller.Update();
    }
    private void FixedUpdate()
    {
        
    }
}
