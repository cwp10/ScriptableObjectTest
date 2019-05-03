using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageEffect : MonoBehaviour
{
    [SerializeField] private GameObject effect_ = null;

    public void OnShowDamage(object sender, object[] args)
    {
        float damage = (float)args[0];
        StartCoroutine(ShowDamage(damage));
    }

    private IEnumerator ShowDamage(float damage)
    {
        GameObject eff = Instantiate<GameObject>(effect_);
        eff.transform.SetParent(this.transform);
        eff.transform.localScale = Vector3.one;
        eff.transform.localPosition = Vector3.zero;
        eff.GetComponent<Text>().text = "" + damage;
        
        float t = 0;
        while(t < 1f)
        {
            eff.transform.localPosition = Vector3.Lerp(eff.transform.localPosition, new Vector3(0.0f, eff.transform.localPosition.y + 2, 0.0f), 1f);
            t += Time.deltaTime;
            yield return null;
        }
        Destroy(eff);
        yield break;
    }
}
