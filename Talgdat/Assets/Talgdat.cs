using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talgdat : MonoBehaviour
{
    public static Talgdat Instance { get; private set; }
    public static float uiDelay { get => Instance._uiDelay; }
    public static GameObject BarPrefab { get => Instance._barPrefab; }
    [SerializeReference] private Controller _controller;
    [SerializeField] GameObject _barPrefab;
    [SerializeField] float _uiDelay = 0f;
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
