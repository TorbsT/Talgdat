using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IntComparator : CompareFunction<IntElement>
{
    public class Ascending : IntComparator
    {
        public override int Compare(IntElement a, IntElement b)
        {
            return a.Compare(b);
        }
    }
}


