using MathRun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace MathRun
{
    public class MathRunUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text txtCountWood;
        [SerializeField] private TMP_Text txtDistance;

        public void SetCountWood()
        {
            txtCountWood.text = MathRunData.Instance.CountWood.ToString();
        }

        public void SetDistance()
        {
            txtDistance.text = MathRunData.Instance.DistanceMove.ToString() + "m";
        }

    }
}
