
[System.Serializable]
public class ProblemConfig
{
    public int min = 1;
    public int max = 10;
    public int count = 10;
    public int seed = 69;
    public string algorithm = "undefined";

    public float uiDelay = 1f/256f;
    public int unmarkQueueSize = 10;
}
