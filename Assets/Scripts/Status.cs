using UnityEngine;
using UnityEngine.Events;
using System;

[CreateAssetMenu]
public class Status : ScriptableObject
{
    [SerializeField] private float attack_ = 0;
    [SerializeField] private float hp_ = 0;
    [SerializeField] private int coin_ = 0;

    public event Action OnChanged = delegate { };

    public float Attack
    {
        get { return attack_; }
        set { this.attack_ = value; OnChanged(); }
    }

    public float Hp
    {
        get { return hp_; }
        set { this.hp_ = value; OnChanged(); }
    }

    public int Coin
    {
        get { return coin_; }
        set { this.coin_ = value; OnChanged(); }
    }

    public void SetStatus(float attack, float hp, int coin)
    {
        this.attack_ = attack;
        this.hp_ = hp;
        this.coin_ = coin;

        OnChanged();
    }
}
