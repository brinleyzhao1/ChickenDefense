using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
  private UIManager _uiManager;
  private EnemySpawner enemyContainer;

  private void Start()
  {
    _uiManager = FindObjectOfType<UIManager>();
    enemyContainer = FindObjectOfType<EnemySpawner>();
  }

  public void PlayerDead()
  {
    _uiManager.BringUpDeadScreen();
  }

  IEnumerator CheckingIfPlayerWon()
  {
    while (true)
    {
      // print("checkin...");
      // print(enemyContainer.transform.childCount);
      if (enemyContainer.transform.childCount == 1) //todo another condition: if health is >0
      {
        _uiManager.BringUpWonScreen();
        yield break;
      }
      yield return new WaitForSeconds(1f);
    }


  }


  public void ReloadFirstLvl()
  {
    SceneManager.LoadScene(0);
  }

  public void LoadLevel(int num)
  {
    SceneManager.LoadScene(num);
  }

  public void QuitGame()
  {
    // Debug.Log("quitting");
    Application.Quit();
  }
}
