using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathBar : MonoBehaviour
{
    [SerializeField] private Slider sliderHp_ = null;
    [SerializeField] private Text textHp_ = null;

    public void OnResetHealthBar(object[] args)
    {
        float currentHp = (float)args[0];
        float origintHp = (float)args[1];
        sliderHp_.value = currentHp / origintHp;
        textHp_.text = "" + currentHp;
    }
}
