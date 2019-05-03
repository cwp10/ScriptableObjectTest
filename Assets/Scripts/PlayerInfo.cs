using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] private Text textHp_ = null;
    [SerializeField] private Text textAttack_ = null;
    [SerializeField] private Text textCoin_ = null;
    [SerializeField] private Status playerStatus_ = null;

    private float prevAttack = 0;
    private float prevHp = 0;

    private void Update()
    {
        textHp_.text = "" + playerStatus_.Hp;
        textAttack_.text = "" + playerStatus_.Attack;
        textCoin_.text = "" + playerStatus_.Coin;
    }
}
