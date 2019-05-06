using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] private Status playerStatus_ = null;
    [SerializeField] private Text textHp_ = null;
    [SerializeField] private Text textAttack_ = null;
    [SerializeField] private Text textCoin_ = null;
    
    private float prevAttack = 0;
    private float prevHp = 0;

    private void OnEnable()
    {
        playerStatus_.OnChanged += OnUpdate;
    }

    private void OnDisable()
    {
        playerStatus_.OnChanged -= OnUpdate;
    }

    private void OnUpdate()
    {
        textHp_.text = "HP: " + playerStatus_.Hp;
        textAttack_.text = "Attack: " + playerStatus_.Attack;
        textCoin_.text = "Coin: " + playerStatus_.Coin;
    }
}
