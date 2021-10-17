
using UnityEngine;

public class EnemyFactory : MonoBehaviour, IFactory
{
    [SerializeField] public GameObject[] enemyPrefab;
    GameObject player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public GameObject FactoryMethod(int tag)
    {
        //ambil pos player
        Vector3 pos = player.transform.position;

        //acak jarak pos.x agar ketika spawn tidak mengenai enemy
        float space = Random.Range(5, 10);
        pos.x = player.transform.position.x - space;

        //spawn dengan set pos dan rotasi player
        GameObject enemy = Instantiate(enemyPrefab[tag], pos, player.transform.rotation);
        return enemy;
    }
}
