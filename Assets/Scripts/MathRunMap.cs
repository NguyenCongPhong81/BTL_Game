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
            //InitBackGround();
        }

        public void Init(MathRunPlayer player)
        {
            InitBackGround(player);
            if (player.transform.position.z > transform.GetChild(1).position.z + 5f)
            {
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(0).gameObject.transform.SetAsLastSibling();
                _currentIndex++;

                var mapData = GetMapData(GetTypeMap());

                var poolItem = GetItemInPool(mapData.Type, mapData.ID);

                if (poolItem == null)
                {
                    poolItem = Instantiate(mapData, transform);
                    GetPool(mapData.Type).Add(poolItem);
                }

                poolItem.Init();
                poolItem.name = (poolItem.name + _currentIndex).ToString();
                poolItem.gameObject.transform.position = Vector3.forward * _currentIndex * MathRunConfig.LENGHT_PER_MAP;
                poolItem.gameObject.transform.SetSiblingIndex(2);
            }
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

        private void InitBackGround()
        {
            for (int i = 0; i < transBG.childCount; i++)
            {
                var bgItem = transBG.GetChild(i);
                bgItem.position = new Vector3(
                                    bgItem.position.x,
                                    bgItem.position.y,
                                    i * MathRunConfig.DISTANCE_PER_BACKGROUND + 200f);
                bgItem.gameObject.SetActive(true);
            }
        }

        public void InitBackGround(MathRunPlayer player)
        {
            if (player.transform.position.z > transBG.GetChild(1).position.z + MathRunConfig.DELTA_DISTANCE_BACKGROUND_PLAYER)
            {
                var firstBackground = transBG.GetChild(0);

                firstBackground.position =
                    new Vector3(
                        firstBackground.position.x,
                        firstBackground.position.y,
                        firstBackground.position.z + MathRunConfig.DISTANCE_PER_BACKGROUND);
                firstBackground.SetAsLastSibling();
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

        private MapType GetTypeMap()
        {
            if (++_countMapEasy <= 6)
                return MapType.EASY;
            if (++_countMapNormal <= 8)
                return MapType.NORMAL;
            if (++_countMapHard <= 4)
                return MapType.VERY_HARD;
            return MapType.VERY_HARD;
        }

        private MathRunMapItem GetMapData(MapType type = MapType.EASY)
        {
            var mapData = mapItems.Where(x => x.Type == type).ToList();
            return mapData[Random.Range(0, mapData.Count())];
        }

        private List<MathRunMapItem> GetAllMap()
        {
            var map = new List<MathRunMapItem>(_poolEasy);
            map.AddRange(_poolNormal);
            map.AddRange(_poolVeryHard);
            return map;
        }




    }

    public enum MapType
    {
        EASY = 0,
        NORMAL = 1,
        VERY_HARD = 2,
    }
}
