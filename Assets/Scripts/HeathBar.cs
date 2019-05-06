using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathBar : MonoBehaviour
{
    [SerializeField] private Slider sliderHp_ = null;
    [SerializeField] private Text textHp_ = null;
    [SerializeField] private Text textName_ = null;

    public void OnChangeMonster(object sender, object[] args)
    {
        string name = (string)args[0];
        textName_.text = name;
    }

    public void OnResetHealthBar(object sender, object[] args)
    {
        float currentHp = (float)args[0];
        float origintHp = (float)args[1];
        sliderHp_.value = currentHp / origintHp;
        textHp_.text = string.Format("{0}/{1}", currentHp, origintHp);
    }
}
