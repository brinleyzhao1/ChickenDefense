using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
  [Range(0.1f, 60f)] [SerializeField] public float maxSpawnInterval = 10f;

  private float spawnInterval;
  [SerializeField] public float secondsIncreaseDifficulty = 0.5f;
  [SerializeField] private float enemyHealth = 5;
  [SerializeField] private float enemyHealthIncrease = 2f;

  [SerializeField] EnemyMovement enemyPrefab;
  [SerializeField] Transform enemyParentTransform;

  private ProgressBar _progressBar;


  [SerializeField] private float timeBeforeSpawn = 6f;
  [SerializeField] private float timeBeforeStopSpawning = 2f;

  // Use this for initialization
  void Start()
  {
    _progressBar = FindObjectOfType<ProgressBar>();
    spawnInterval = maxSpawnInterval;

    StartCoroutine(RepeatedlySpawnEnemies());
  }

  IEnumerator RepeatedlySpawnEnemies()
  {
    yield return new WaitForSeconds(timeBeforeSpawn); //time in

    while (true)
    {
      var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
      newEnemy.transform.parent = enemyParentTransform;
      newEnemy.GetComponent<EnemyDamage>().SetEnemyHealth(enemyHealth);

      //increase difficulty
      enemyHealth += enemyHealthIncrease;
      spawnInterval -= secondsIncreaseDifficulty;
      _progressBar.UpdateProgressBar(spawnInterval - timeBeforeStopSpawning, maxSpawnInterval - timeBeforeStopSpawning);

      if (spawnInterval <= timeBeforeStopSpawning)
      {
        FindObjectOfType<LevelManager>().StartCoroutine("CheckingIfPlayerWon");
        break;
      }

      yield return new WaitForSeconds(spawnInterval);
    }
  }
}
