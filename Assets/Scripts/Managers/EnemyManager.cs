using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 6f;
    public Transform[] spawnPoints;

    [SerializeField]
    MonoBehaviour factory;
    IFactory Factory { get { return factory as IFactory; } }
    void Start ()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn ()
    {
        //Jika player mati, berhenti spawn
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        //int spawnPointIndex = Random.Range (0, spawnPoints.Length);
        //Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

        //Gunakan Template factory
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        int spawnEnemy = Random.Range(0, 3);

        Factory.FactoryMethod(spawnEnemy);
    }
}
