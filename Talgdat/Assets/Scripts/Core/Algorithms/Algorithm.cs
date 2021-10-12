using System;
public abstract class Algorithm<Domain, Codomain>
{
    public bool solved { get => _solved; }
    public bool done { get => _done; }
    public ProblemConfig config { get => _config; }
    protected Domain input { get => _input; set { if (_done) throw new InvalidOperationException("Can't change input of " + this + ", it is done"); _input = value; } }
    protected Codomain output { get => _output; set { _output = value; } }

    private bool _solved;
    private bool _done;
    private ProblemConfig _config;
    private Domain _input;
    private Codomain _output;

    public Algorithm(ProblemConfig config)
    {
        _config = config;
    }
    public bool Solve()
    {
        if (_input == null) throw new InvalidOperationException("Tried solving " + this + ", but it has no input. Use algorithm.input = value");
        if (_done) throw new InvalidOperationException("Tried solving " + this + ", but it has already begun/finished");
        _done = true;
        _solved = _Solve();
        return _solved;
    }

    // ABSTRACTS
    public abstract Domain CopyInput();
    public abstract Codomain CopyOutput();
    protected abstract bool _Solve();
}
