using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SortPanel : MonoBehaviour
{
    public string ChosenAlgorithm { get { string v = _algorithmChoices[_algorithmDropdown.value]; Debug.Log(_algorithmDropdown.value); Debug.Log(v); return v; } }
    public int ChosenSeed { get { if (_seedField.text == "") return Random.Range(0, 99999); return int.Parse(_seedField.text); } }
    public int ChosenMin { get => int.Parse(_minField.text); }
    public int ChosenMax { get => int.Parse(_maxField.text); }
    public int ChosenCount { get => int.Parse(_countField.text); }
    public int ChosenVisualTime { get => int.Parse(_visualTimeField.text); }
    public int ChosenMarkSize { get => int.Parse(_markSizeField.text); }
    public bool Active { get => _active; }

    [Header("Problem config objects")]
    [SerializeField] private Dropdown _algorithmDropdown;
    [SerializeField] private Text _seedField;
    [SerializeField] private Text _minField;
    [SerializeField] private Text _maxField;
    [SerializeField] private Text _countField;
    [SerializeField] private Text _visualTimeField;
    [SerializeField] private Text _markSizeField;
    [SerializeField] private Button _startButton;
    private ProblemConfig _config;
    private bool _active;

    private List<string> _algorithmChoices = new List<string>
    {
        HeapSort.Name,
        QuickSort.Name,
        OptimizedBogoSort.Name,
        BogoSort.Name,
    };

    private void Awake()
    {
        List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();
        foreach (string s in _algorithmChoices) options.Add(new Dropdown.OptionData(s));
        _algorithmDropdown.ClearOptions();
        _algorithmDropdown.AddOptions(options);
    }

    public void Clicked()
    {
        _config = new ProblemConfig
        {
            Algorithm = ChosenAlgorithm,
            Seed = ChosenSeed,
            Min = ChosenMin,
            Max = ChosenMax,
            Count = ChosenCount,

            VisualSortTime = ChosenVisualTime,
            UnmarkQueueSize = ChosenMarkSize
        };
        Controller.Instance.StartSortView(_config);
    }
    public void Hide()
    {
        _active = false;
        gameObject.SetActive(false);
    }
    public void Show()
    {
        _active = true;
        gameObject.SetActive(true);
    }
    public void Toggle()
    {
        if (_active) Hide();
        else Show();
    }
}
