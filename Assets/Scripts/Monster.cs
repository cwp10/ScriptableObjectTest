using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private Status status_ = null;
    [SerializeField] private GameEvent dieEvent_ = null;
    [SerializeField] private GameEvent shakeEffectEvent_ = null;
    [SerializeField] private GameEvent damageEvent_ = null;
    [SerializeField] private GameEvent damageEffectEvent_ = null;
    
    private float _originHp = 0.0f;

    public void InitData(string name, float attack, float hp, int coin)
    {
        this.status_.SetStatus(name, attack, hp, coin);

        this._originHp = hp;
        damageEvent_.Notify(this, this.status_.Hp, this._originHp);
    }

    public void OnDamage(object sender, object[] args)
    {
        float dmg = (float)args[0];
        status_.Hp -= dmg;
  
        damageEvent_.Notify(this, this.status_.Hp, this._originHp);
        damageEffectEvent_.Notify(this, dmg);

        if (status_.Hp <= 0)
        {
            status_.Hp = 0;
            dieEvent_.Notify(this, status_.Coin);
            shakeEffectEvent_.Notify(this, 0.2f, 0.1f);
            Destroy(this.gameObject);
        }
    }
}
