using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MathRun
{
    public class MathRunData : Singleton<MathRunData>
    {
        public int CountWood { get; private set; } = MathRunConfig.COUNT_WOOD_START;

        public int CountPointItem = 0;
        public int CountWoodUsed = 0;
        public int CountWoodReceived = MathRunConfig.COUNT_WOOD_START;


        public void AddWood(CaculateType type, int wood)
        {
            CountWood += wood;
            CountWoodReceived += wood;
            if (MathRunManager.Instance)
                MathRunManager.Instance.UpdateWood();
        }

    }
}
