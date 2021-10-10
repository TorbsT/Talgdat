using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talgdat : MonoBehaviour
{
    public static Talgdat Instance { get; private set; }
    public static GameObject BarPrefab { get => Instance._barPrefab; }
    private Controller _controller;
    [SerializeField] GameObject _barPrefab;
    private void Start()
    {
        Instance = this;
        _controller = new Controller();
    }
    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        
    }
}
