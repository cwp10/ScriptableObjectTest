using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private GameEvent dieEvent_ = null;
    [SerializeField] private GameEvent shakeEffectEvent_ = null;
    [SerializeField] private GameEvent damageEvent_ = null;
    [SerializeField] private GameEvent damageEffectEvent_ = null;
    
    private Status _status = null;
    private float _originHp = 0.0f;

    public void InitData(Status status)
    {
        this._status = status;
        this._originHp = this._status.Hp;
        UpdateHealth(this._status.Hp, this._originHp);
    }

    public void OnDamage(object sender, object[] args)
    {
        float dmg = (float)args[0];
        _status.Hp -= dmg;
        UpdateHealth(this._status.Hp, this._originHp);

        damageEffectEvent_.Notify(this, dmg);
        
        if (_status.Hp <= 0)
        {
            _status.Hp = 0;
            dieEvent_.Notify(this, _status.Coin);
            shakeEffectEvent_.Notify(this, 0.2f, 0.1f);
            Destroy(this.gameObject);
        }
    }

    private void UpdateHealth(float currentValue, float originValue)
    {
        damageEvent_.Notify(this, currentValue, originValue);
    }
}
