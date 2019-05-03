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

    public void OnDamage(object[] args)
    {
        float dmg = (float)args[0];
        _status.Hp -= dmg;
        UpdateHealth(this._status.Hp, this._originHp);

        damageEffectEvent_.Notify(dmg);
        
        if (_status.Hp <= 0)
        {
            _status.Hp = 0;
            dieEvent_.Notify(_status.Coin);
            shakeEffectEvent_.Notify(0.2f, 0.1f);
            Destroy(this.gameObject);
        }
    }

    private void UpdateHealth(float currentValue, float originValue)
    {
        damageEvent_.Notify(currentValue, originValue);
    }
}
