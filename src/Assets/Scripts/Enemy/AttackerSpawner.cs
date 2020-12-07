using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {
    [SerializeField] bool autoSpawn = true;
    [SerializeField] Attacker[] EnemiesPrefabs;
    [SerializeField] int minSpawnDelay = 1;
    [SerializeField] int maxSpawnDelay = 11;
    LevelController LevelController;
    /*[SerializeField] int yPosMin = 2;
    [SerializeField] int yPosMax = 4;*/

    void Update () {
        //StartCoroutine(AutoSpawnEnemies(EnemyPrefab));
        LevelController = FindObjectOfType<LevelController>();

    }

    IEnumerator Start()
    {
        while (autoSpawn)
        {
            int spawnDelay = UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay);
            int randomEnemyIndex = UnityEngine.Random.Range(0, EnemiesPrefabs.Length);
            yield return new WaitForSeconds(spawnDelay);
            SpawnOneEnemy(EnemiesPrefabs[randomEnemyIndex]);
        }
    }
    public void stopAutoSpawn()
    {
        autoSpawn = false;
    }
    private void SpawnOneEnemy(Attacker enemy)
    {
        //int yPos = UnityEngine.Random.Range(yPosMin, yPosMax);
        float yPos = transform.position.y;
        Vector2 SpawnPostion = new Vector2(transform.position.x, yPos);
        Attacker OneEnemy = Instantiate(enemy, SpawnPostion, Quaternion.identity) as Attacker;
        OneEnemy.transform.parent = transform;
        LevelController.addAttacker();
    }
}
