using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Vector2 spanwValues;
    public GameObject enemies;

    public float spawnWait, spawnMostWait, spawnLeastWait;
    private int startWait = 2;

    public bool stop;

    void Start()
    {
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
            Vector2 spawnPosition = new Vector2(Random.Range(spanwValues.x, spanwValues.x + 5), Random.Range(spanwValues.y, spanwValues.y + 8));
            Instantiate(enemies, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnWait);
        }

    }
}
