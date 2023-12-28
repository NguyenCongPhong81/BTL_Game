using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static MathRun.MathRunPoint;

namespace MathRun
{
    public class MathRunPointItem : MonoBehaviour
    {
        [SerializeField] private int pointLost = 0;
        [SerializeField] private TextMeshProUGUI txtValue;
        //[SerializeField] private TextMeshProUGUI txtBonus;
        [SerializeField] private BoxCollider boxCollider;
        //[SerializeField] private ParticleSystem effect;
        //[SerializeField] private Animator animBonus;

        public int PointLost => Math.Abs(pointLost);
        private CaculateType _caculate = CaculateType.PLUS;
        private int _value = 0;
        private Action _onTrigger;
        private bool _isBest = false;

        public void Init(PointData pointData, bool isBest, Action OnTriggerCollider)
        {
            _onTrigger = OnTriggerCollider;
            _caculate = pointData.type;
            _value = pointData.value;
            _isBest = isBest;
            boxCollider.enabled = true;
            //animBonus.gameObject.SetActive(false);
            SetTextBonus(pointData.x, pointData.y);
        }

        private void SetTextBonus(int x, int y)
        {
            if (_caculate == CaculateType.TIMES)
            {
                txtValue.text = string.Format("+({0}x{1})", x, y);
                return;
            }

            txtValue.text = string.Format("{0}{1}", "+", _value);
        }

        public void DisableCollider()
        {
            boxCollider.enabled = false;
        }

        private void UpdateScore()
        {
            //if (_isBest)
            //{
            //    MathRunDataManager.Instance.AddTotalBonusScore();
            //    if (MathRunDataManager.Instance.BonusScore != 0)
            //    {
            //        txtBonus.text = string.Format("+{0}", MathRunDataManager.Instance.BonusScore);
            //        animBonus.gameObject.SetActive(true);
            //        animBonus.SetTrigger(MathRunConfig.EFFECT_BONUS);
            //    }
            //}
            //else
            //{
            //    MathRunDataManager.Instance.ResetCountComboBonus();
            //}
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == MathRunConfig.LAYER_PLAYER)
            {
                _onTrigger?.Invoke();
                //SoundManager.Instance.PlaySfx(ESoundType.MathRun_Sfx_Trigger_Point);
                //effect?.Play();
                boxCollider.enabled = false;
                UpdateScore();
                MathRunData.Instance.AddWood(_caculate, _value);
            }
        }

        private void OnValidate()
        {
            boxCollider = GetComponent<BoxCollider>();
            //effect = GetComponentInChildren<ParticleSystem>();
            //animBonus = GetComponentInChildren<Animator>();
            //txtBonus = animBonus.gameObject.GetComponent<TextMeshProUGUI>();
        }

    }
}
