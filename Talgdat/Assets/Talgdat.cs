using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Talgdat : MonoBehaviour
{
    public static ProblemConfig ProblemConfig { get => Instance._problemConfig; }
    public static Talgdat Instance { get; private set; }
    public static GameObject BarPrefab { get => Instance._barPrefab; }
    public static AudioSource AudioSource { get => Instance._audioSource; }

    public int ChosenAlgorithm { get => _algorithmDropdown.value; }
    public string ChosenSeed { get => _seedField.text; }
    public string ChosenMin { get => _minField.text; }
    public string ChosenMax { get => _maxField.text; }
    public string ChosenCount { get => _maxField.text; }
    public string ChosenVisualTime { get => _maxField.text; }
    public string ChosenMarkSize { get => _maxField.text; }

    [SerializeReference] private Controller _controller;
    [SerializeField] GameObject _barPrefab;
    [SerializeField] private ProblemConfig _problemConfig;

    [Header("Problem config objects")]
    [SerializeField] private Dropdown _algorithmDropdown;
    [SerializeField] private Text _seedField;
    [SerializeField] private Text _minField;
    [SerializeField] private Text _maxField;
    [SerializeField] private Text _countField;
    [SerializeField] private Text _visualTimeField;
    [SerializeField] private Text _markSizeField;
    [SerializeField] private Button _startButton;


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
    public void StartButtonClicked()
    {
        _controller.StartButtonClicked();
    }
}
