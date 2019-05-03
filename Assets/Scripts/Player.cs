using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameEvent damage_ = null;

    private Status _status = null;

    public void InitData(Status status)
    {
        _status = status;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            damage_.Notify(_status.Attack);
        }
    }
}
