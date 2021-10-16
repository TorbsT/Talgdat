using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Controller
{
    public static Controller Instance { get; private set; }
    public AudioSource AudioSource { get => Talgdat.AudioSource; }
    
    private Core _core;
    private List<Bar> _bars = new List<Bar>();
    [SerializeField] private int _replayIndex;
    private float _lastDisplayTime;
    [SerializeField] private float _timeSinceLastDisplay;
    private Queue<Bar> _unmarkQueue = new Queue<Bar>();
    private int _activeMarks;
    private List<Command> _commands;
    private ProblemConfig _config;

    private SortView _sortView;
    private float _lastFrameTime;
    private float _timeSinceLastFrame;
    public Controller()
    {
        Instance = this;
    }
    public void StartButtonClicked()
    {
        _core = new Core();

        _config = new ProblemConfig
        {
            Algorithm = Talgdat.Instance.ChosenAlgorithm,
            Seed = Talgdat.Instance.ChosenSeed,
            Min = Talgdat.Instance.ChosenMin,
            Max = Talgdat.Instance.ChosenMax,
            Count = Talgdat.Instance.ChosenCount,

            VisualSortTime = Talgdat.Instance.ChosenVisualTime,
            UnmarkQueueSize = Talgdat.Instance.ChosenMarkSize
        };

        _core.Restart(_config);
        _core.Solve();



        if (_sortView != null) _sortView.Destroy();
        _sortView = new SortView(_core.list, _config);
        _sortView.Start();
    }
    public void Update()
    {
        if (_sortView != null) _sortView.Update();
    }

    public void FixedUpdate()
    {

    }
}
