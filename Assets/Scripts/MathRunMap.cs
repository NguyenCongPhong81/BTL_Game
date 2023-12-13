using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MathRun
{
    public class MathRunMap : MonoBehaviour
    {
        [SerializeField] private List<MathRunMapItem> mapItems;


        [Header("BG")]
        [SerializeField] private Transform transBG;

        private List<MathRunMapItem> _poolEasy = new();
        private List<MathRunMapItem> _poolNormal = new();
        private List<MathRunMapItem> _poolVeryHard = new();

        private int _countMapEasy = 0;
        private int _countMapNormal = 0;
        private int _countMapHard = 0;

        private int _currentIndex = 0;


        void Start()
        {
            _currentIndex = 0;
            InitFirstMap();
        }

        private void InitFirstMap()
        {
            var firstMapItem = mapItems.Where(x => x.Type == MapType.EASY).Take(3).ToList();
            _countMapEasy = 3;

            for (int i = 0; i < firstMapItem.Count(); i++)
            {
                var mapData = firstMapItem[i];
                var item = GetItemInPool(mapData.Type, mapData.ID);

                if (item == null)
                {
                    item = Instantiate(mapData, transform);
                    GetPool(mapData.Type).Add(item);
                }

                item.Init();
                item.name = (item.name + i).ToString();
                item.gameObject.transform.position = Vector3.forward * i * MathRunConfig.LENGHT_PER_MAP;
                item.gameObject.transform.SetSiblingIndex(i);
                _currentIndex = i;
            }
        }
        private MathRunMapItem GetItemInPool(MapType type, int id)
        {
            return GetPool(type).FirstOrDefault(x => x.ID == id && !x.gameObject.activeInHierarchy);
        }
        private List<MathRunMapItem> GetPool(MapType type)
        {
            return type switch
            {
                MapType.EASY => _poolEasy,
                MapType.NORMAL => _poolNormal,
                MapType.VERY_HARD => _poolVeryHard,
                _ => null,
            };
        }




    }

    public enum MapType
    {
        EASY = 0,
        NORMAL = 1,
        VERY_HARD = 2,
    }
}
