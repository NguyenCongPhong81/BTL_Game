using MathRun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MathRunUI : MonoBehaviour
{
    [SerializeField] private TMP_Text txtCountWood;

    public void SetCountWood()
    {
        txtCountWood.text = MathRunData.Instance.CountWood.ToString();
    }
}
