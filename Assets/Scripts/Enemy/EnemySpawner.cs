using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    Vector2 bounds = new Vector2(10f, 15f);
    public Vector2 spawnValues;
    public GameObject enemies;

    public int maxDistance = 3;

    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    private int startWait = 2;

    public float increment = 0.3f;

    public Transform myTransform;

    public bool stop;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        myTransform = transform;
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        spawnWait = Random.Range(spawnMostWait, spawnLeastWait);
    }

    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(startWait);

        while (!stop)
        {
            Vector2 spawnPosition = new Vector2(Random.Range(spawnValues.x, spawnValues.x + 5), Random.Range(spawnValues.y, spawnValues.y + 8));
            if (Vector3.Distance(spawnPosition, myTransform.position) > maxDistance)
            {
                Instantiate(enemies, spawnPosition, Quaternion.identity);
            }

            if (spawnMostWait <= spawnLeastWait)
            {
                spawnLeastWait -= increment;
            }

            yield return new WaitForSeconds(spawnWait);
        }

    }
}
