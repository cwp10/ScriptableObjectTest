using UnityEngine;
using System.Collections;
public class GameWorld : MonoBehaviour
{
    [SerializeField] private GameEvent spawnEvent_ = null;

    private Player _player = null;
    private int _count = 0;

    public void Start()
    {
        CreatePlayer();
        StartCoroutine(MakeMonster());
    }

    private void CreatePlayer()
    {
        GameObject prefab = Resources.Load<GameObject>("Player");
        GameObject clone  = Instantiate(prefab);
        _player = clone.GetComponent<Player>();
        _player.transform.SetParent(this.transform);
        _player.InitData("Player", 5, 100, 0);
    }

    public void OnCreateMonster(object sender, object[] args)
    {
        StartCoroutine(MakeMonster());
    }

    private IEnumerator MakeMonster()
    {
        yield return new WaitForSeconds(1.0f);

        GameObject prefab = Resources.Load<GameObject>("Monster");
        GameObject clone = Instantiate(prefab);

        float hp = 100 + (_count * 10);
        _count += 1;
        string name = "enemy" + _count;
        clone.GetComponent<Monster>().InitData(name, 0, hp, _count);
        clone.transform.SetParent(this.transform);

        spawnEvent_.Notify(null, name);
    }
}