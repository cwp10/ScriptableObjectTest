using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Status status_ = null;
    [SerializeField] private GameEvent damage_ = null;

    public void InitData(string name, float attack, float hp, int coin)
    {
        this.status_.SetStatus(name, attack, hp, coin);
    }

    public void OnUpdateCoin(object sender, object[] args)
    {
        int coin = (int)args[0];
        this.status_.Coin += coin;
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            damage_.Notify(this, status_.Attack);
        }
    }
}
