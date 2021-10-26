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
    private List<ICommand> _commands;
    private ProblemConfig _config;

    private SortPanel _sortPanel;

    private SortView _sortView;
    private float _lastFrameTime;
    private float _timeSinceLastFrame;
    public Controller()
    {
        Instance = this;
        _sortPanel = Talgdat.Instance.SortPanel;
        Graph<int> graph = new Graph<int>(10, false, false);
    }

    public void StartSortView(ProblemConfig config)
    {
        _config = config;
        _sortPanel.Hide();

        _core = new Core();



        _core.Restart(_config);
        _core.Solve();



        if (_sortView != null) _sortView.Destroy();
        _sortView = new SortView(_core.list, _config);
        _sortView.Start();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) _sortPanel.Toggle();
        if (_sortView != null) _sortView.Update();
    }

    public void FixedUpdate()
    {

    }
}
