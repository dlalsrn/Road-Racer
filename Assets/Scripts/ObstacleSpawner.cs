using UnityEngine;
using System.Collections;
using System;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private Obstacle[] obstaclePrefabs;
    [SerializeField] private float interval = 1.5f;
    private float[] spawnPosX = {-2.12f, -0.75f, 0.75f, 2.12f};
    private Coroutine spawnRoutine;

    void Start() {
        StartSpawn();
    }

    void StartSpawn() {
        spawnRoutine = StartCoroutine(ObstacleSpawn());
    }

    public void StopSpawn() {
        StopCoroutine(spawnRoutine);
    }

    IEnumerator ObstacleSpawn() {
        yield return new WaitForSeconds(1f);

        while (true) {
            int index = UnityEngine.Random.Range(0, obstaclePrefabs.Length);
            int posX = UnityEngine.Random.Range(0, spawnPosX.Length);
            Vector3 pos = new Vector3(spawnPosX[posX], transform.position.y, transform.position.z);
            Instantiate<Obstacle>(obstaclePrefabs[index], pos, Quaternion.identity);
            yield return new WaitForSeconds(interval);
        }
    }

    public void DereaseInterval() {
        if (interval > 0.5f) {
            interval -= 0.2f;
        }
    }
}
