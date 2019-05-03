using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    private Vector3 _originPos = Vector3.zero;

    void Start()
    {
        _originPos = transform.localPosition;
    }

    public void OnShake(object sender, object[] args)
    {
        float amount = (float)args[0];
        float duration = (float)args[1];

        StartCoroutine(Shake(amount, duration));
    }

    private IEnumerator Shake(float amount, float duration)
    {
        float timer = 0;
        while (timer <= duration)
        {
            transform.localPosition = (Vector3)Random.insideUnitCircle * amount + _originPos;

            timer += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = _originPos;
    }
}