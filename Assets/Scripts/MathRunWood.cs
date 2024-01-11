using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MathRun
{
    public class MathRunWood : MonoBehaviour
    {
        [SerializeField] private MathRunWoodItem woodItem;

        private MathRunWoodItem _currentWoodItem = null;
        private List<MathRunWoodItem> _woodItems = new List<MathRunWoodItem>();

        private int _indexWood = 0;

        public GameObject Init(Vector3 posPlayer)
        {
            var wood = GetItem(_indexWood++);
            var posYWood = 0f;
            var posZWood = posPlayer.z;
            if (_currentWoodItem != null)
            {
                var curPosWood = _currentWoodItem.transform.position;
                posZWood = curPosWood.z + 0.5f;
                //posYWood = curPosWood.y + MathRunConfig.DISTANCE_HEIGHT_WOOD;
            }

            wood.gameObject.transform.position = new Vector3(posPlayer.x, posYWood, posZWood);

            _currentWoodItem = wood;
            //SoundManager.Instance.PlaySfx(ESoundType.MathRun_Sfx_Use_Wood);
            MathRunData.Instance.MinusWood(1);

            return wood.gameObject;
        }

        private MathRunWoodItem GetItem(int index = 0)
        {
            if (_woodItems.Count <= MathRunConfig.MAX_WOOD_APPEAR)
            {
                var item = Instantiate(woodItem, transform);
                item.Index = index;
                item.gameObject.SetActive(true);
                _woodItems.Add(item);
                return item;
            }
            else
            {
                var item = _woodItems.OrderBy(x => x.Index).FirstOrDefault();
                item.Index = index;
                item.gameObject.SetActive(true);
                return item;
            }
        }

        public void SetCurrentItem(MathRunWoodItem data)
        {
            _currentWoodItem = data;
        }

        public void Reset()
        {
            _woodItems.ForEach(x =>
            {
                x.gameObject.SetActive(false);
                x.Index = 0;
            });
            _indexWood = 0;
        }
    }
}
