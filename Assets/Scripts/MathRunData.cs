using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MathRun
{
    public class MathRunData : Singleton<MathRunData>
    {
        public int CountWood { get; private set; } = MathRunConfig.COUNT_WOOD_START;

    }
}
