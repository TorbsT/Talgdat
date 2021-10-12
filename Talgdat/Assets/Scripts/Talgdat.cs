using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talgdat : MonoBehaviour
{
    public static ProblemConfig ProblemConfig { get => Instance._problemConfig; }
    public static Talgdat Instance { get; private set; }
    public static GameObject BarPrefab { get => Instance._barPrefab; }
    [SerializeReference] private Controller _controller;
    [SerializeField] GameObject _barPrefab;
    [SerializeField] ProblemConfig _problemConfig;
    private void Start()
    {
        Instance = this;
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
