using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MathRun
{
    public class MathRunData : Singleton<MathRunData>
    {
        public float DistanceMove { get; private set; } = 0;

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

        public void MinusWood(int wood)
        {
            if (CountWood <= 0) return;
            CountWood -= wood;
            CountWoodUsed += wood;
            if (MathRunManager.Instance)
                MathRunManager.Instance.UpdateWood();
        }

        public void AddDistance(float distance)
        {
            DistanceMove = (int)distance;
            if (MathRunManager.Instance)
                MathRunManager.Instance.UpdateDistance();

        }

    }
}
