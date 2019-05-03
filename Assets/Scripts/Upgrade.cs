using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    [SerializeField] private Status status_ = null;
    [SerializeField] private Text textCoin_ = null;

    public int coin = 5;

    private void Start()
    {
        textCoin_.text = "Upgrade Coin " + coin;
    }

    public void OnClickButton()
    {
        if(status_.Coin >= coin)
        {
            status_.Coin -= coin;
            status_.Attack += 5.0f;
            coin += 10;
            textCoin_.text = "Upgrade Coin " + coin;
        }
    }
}
