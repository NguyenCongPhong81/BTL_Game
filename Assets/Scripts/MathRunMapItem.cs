using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MathRun
{
    public class MathRunMapItem : MonoBehaviour
    {
        [SerializeField] private int id = 0;
        [SerializeField] private MapType type = MapType.EASY;
        [SerializeField] private List<MathRunPoint> points;

        public MapType Type =>type;

        public int ID =>id;

        public void Init()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    
    }
}
