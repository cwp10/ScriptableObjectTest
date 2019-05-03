using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class Status : ScriptableObject
{
    [SerializeField] private float attack_ = 0;
    [SerializeField] private float hp_ = 0;
    [SerializeField] private int coin_ = 0;

    public float Attack
    {
        get { return attack_; }
        set { this.attack_ = value; }
    }

    public float Hp
    {
        get { return hp_; }
        set { this.hp_ = value; }
    }

    public int Coin
    {
        get { return coin_; }
        set { this.coin_ = value; }
    }
}
