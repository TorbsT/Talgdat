using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EndomorphicAlgorithm<Domain> : Algorithm<Domain, Domain>
{
    public EndomorphicAlgorithm(ProblemConfig config) : base(config) { }
}
