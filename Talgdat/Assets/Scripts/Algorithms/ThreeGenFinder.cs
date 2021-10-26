using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Domain: complete graph
 */
public class ThreeGenFinder
{
    private Graph graph;
    private int[] resultIds;
    private float circumference = Mathf.Infinity;
    public void Solve(Graph graph)
    {
        this.graph = graph;
        resultIds = new int[3];
        Node[] nodes = graph.Nodes;
        for (int i = 0; i < nodes.Length; i++)
        {
            for (int j = i; j < nodes.Length; j++)
            {
                for (int k = j; k < nodes.Length; k++)
                {
                    float temp = getCircumference(i, j, k);
                    if (temp < circumference)
                    {
                        circumference = temp;
                        resultIds[0] = i;
                        resultIds[1] = j;
                        resultIds[2] = k;
                    }
                }
            }
        }
    }
    private float getCircumference(int a, int b, int c)
    {
        return graph.GetCircumference(a, b, c);
    }
}
