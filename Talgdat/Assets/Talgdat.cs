using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Talgdat : MonoBehaviour
{
    public static Talgdat Instance { get; private set; }
    public static GameObject BarPrefab { get => Instance._barPrefab; }
    public static AudioSource AudioSource { get => Instance._audioSource; }

    public string ChosenAlgorithm { get { string v = _algorithmChoices[_algorithmDropdown.value]; Debug.Log(_algorithmDropdown.value); Debug.Log(v); return v; } }
    public int ChosenSeed { get { if (_seedField.text == "") return Random.Range(0, 99999); return int.Parse(_seedField.text); } }
    public int ChosenMin { get => int.Parse(_minField.text); }
    public int ChosenMax { get => int.Parse(_maxField.text); }
    public int ChosenCount { get => int.Parse(_countField.text); }
    public int ChosenVisualTime { get => int.Parse(_visualTimeField.text); }
    public int ChosenMarkSize { get => int.Parse(_markSizeField.text); }

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
    private List<string> _algorithmChoices = new List<string>
    {
        QuickSort.Name,
        BogoSort.Name
    };


    private AudioSource _audioSource;
    private void Start()
    {
        Instance = this;
        _audioSource = GetComponent<AudioSource>();
        _controller = new Controller();

        List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();
        foreach (string s in _algorithmChoices) options.Add(new Dropdown.OptionData(s));
        _algorithmDropdown.ClearOptions();
        _algorithmDropdown.AddOptions(options);
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
