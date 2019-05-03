using UnityEngine;
using System.Collections;
public class GameWorld : MonoBehaviour
{
    [SerializeField] private Status playerStatus_ = null;
    [SerializeField] private Status monsterStatus_ = null;

    private Player _player = null;
    private int _count = 0;

    public void Start()
    {
        CreatePlayer();
        StartCoroutine(MakeMonster());
    }

    private void CreatePlayer()
    {
        GameObject go = Resources.Load<GameObject>("Player");
        GameObject clone  = Instantiate<GameObject>(go);
        _player = clone.GetComponent<Player>();
        _player.transform.SetParent(this.transform);
        playerStatus_.Hp = 100;
        playerStatus_.Attack = 5;
        playerStatus_.Coin = 0;
        _player.InitData(playerStatus_);
    }

    public void OnCreateMonster(object[] args)
    {
        int coin = (int)args[0];
        playerStatus_.Coin += coin;
        StartCoroutine(MakeMonster());
    }

    private IEnumerator MakeMonster()
    {
        yield return new WaitForSeconds(1.0f);

        GameObject prefab = Resources.Load<GameObject>("Monster");
        GameObject clone = Instantiate<GameObject>(prefab);

        float hp = 100 + (_count * 10);
        _count += 1;

        monsterStatus_.Hp = hp;
        monsterStatus_.Coin = _count;
        clone.GetComponent<Monster>().InitData(monsterStatus_); 
    }
}