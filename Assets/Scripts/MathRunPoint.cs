using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MathRun
{
    public class MathRunPoint : MonoBehaviour
    {
        [SerializeField] List<MathRunPointItem> pointItems;

        private Dictionary<int, PointData> pointChanges = new();

        public void Init()
        {
            pointChanges = new();

            for (int i = 0; i < pointItems.Count; i++)
            {
                var caculateRandom = Random.Range(0, 2); // 0 là + , 1 là -
                var numberRandom = Random.Range(-5, 11);
                if (numberRandom == 0) numberRandom = Random.Range(1, 11);
                var valueAdd = pointItems[i].PointLost + numberRandom;
                if (valueAdd <= 0) valueAdd = Random.Range(1, 3);

                //check duplicate value
                if (pointChanges != null)
                {
                    foreach (var data in pointChanges.Values)
                    {
                        if ((valueAdd == data.value && pointItems[i].PointLost == data.pointLost) || (data.pointBonus == valueAdd - pointItems[i].PointLost))
                        {
                            var random = Random.Range(1, 4);
                            valueAdd += random;
                        }
                    }
                }

                var numberDivided = GetNumberDivided(valueAdd);

                var x = 0;
                var y = 0;
                var caculateType = CaculateType.PLUS;
                if (numberDivided != 0 && (valueAdd / numberDivided != 1))
                {
                    caculateType = CaculateType.TIMES;
                    x = valueAdd / numberDivided;
                    y = numberDivided;
                }

                pointChanges[i] = new PointData
                {
                    value = valueAdd,
                    pointBonus = valueAdd - pointItems[i].PointLost,
                    pointLost = pointItems[i].PointLost,
                    type = caculateType,
                    x = x,
                    y = y,
                };


            }

            var indexBest = GetIndexBonus();

            for (int i = 0; i < pointItems.Count; i++)
            {
                pointItems[i].Init(pointChanges[i], i == indexBest, DisableCollider);
            }
        }

        public int GetNumberDivided(int value)
        {
            for (int i = 5; i > 1; i--)
            {
                if (value % i == 0)
                {
                    return i;
                }
            }
            return 0;
        }

        private int GetIndexBonus()
        {
            var dicAcsending = pointChanges.OrderBy(x => x.Value.pointBonus).ToDictionary(x => x.Key, x => x.Value);

            return dicAcsending.Last().Key;
        }

        public void DisableCollider()
        {
            pointItems.ForEach(x => x.DisableCollider());
        }

        private void OnTriggerEnter(Collider other)
        {
            //if (other.gameObject.layer == LayerConst.LAYER_PLAYER)
            //{
            //    MathRunDataManager.Instance.AddCountPointItem();
            //}
        }
        
    }
    public class PointData
    {
        public int value;
        public int pointBonus;
        public int pointLost;
        public CaculateType type;
        public int x;
        public int y;
    }

    public enum CaculateType
    {
        PLUS = 0,
        TIMES = 1,
    }
}
