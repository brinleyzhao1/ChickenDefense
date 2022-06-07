using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
  [SerializeField] private TextMeshProUGUI _coinText;
  [SerializeField] private TextMeshProUGUI _heartText;

  [Header("Menus")]
  [SerializeField] private GameObject deathScreen;
  [SerializeField] private GameObject wonScreen;
  [SerializeField] private GameObject pauseScreen;
  [SerializeField] private GameObject instructionScreen;
  [SerializeField] public float timeBeforeGame = 5f;
  // private bool _isPaused = false;

  [Header("Coin")]
  [SerializeField] private TextMeshProUGUI addCoinText;
  [SerializeField] private float addCoinTextStayTime = 1f;
  // Start is called before the first frame update


  private void Start()
  {
    if (SceneManager.GetActiveScene().buildIndex == 1)
    {
      StartCoroutine(nameof(InstructionComeAndGo));
    }

    deathScreen.SetActive(false);
    wonScreen.SetActive(false);
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      Pause();
    }
  }

  private void Pause()
  {
    pauseScreen.SetActive(true);
    Time.timeScale = 0f;


  }

  public void Resume()
  {
    pauseScreen.SetActive(false);
    Time.timeScale = 1;
  }

  IEnumerator InstructionComeAndGo()
  {
    instructionScreen.SetActive(true);
    yield return new WaitForSeconds(timeBeforeGame);
    instructionScreen.SetActive(false);
  }

  public void LoadNextLevel()
  {
    int currentIndex = SceneManager.GetActiveScene().buildIndex;
    if (currentIndex < SceneManager.sceneCountInBuildSettings)
    {
      SceneManager.LoadScene(currentIndex += 1);
      Time.timeScale = 1;
    }
  }
  public void GoToMainMenu()
  {
    SceneManager.LoadScene(0);
  }

  public void ReloadThisLevel()
  {
    int currentIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(currentIndex);
    Time.timeScale = 1;
  }
  public void UpdateCoinText(int coin)
    {
      _coinText.text = coin.ToString();
    }

    public void UpdateHeartText(int heart)
    {
      _heartText.text = heart.ToString();
    }

    public void BringUpDeadScreen()
    {
      Time.timeScale = 0;
      deathScreen.SetActive(true);
    }
    public void BringUpWonScreen()
    {
      //todo play winning SFX
      wonScreen.SetActive(true);
    }

    public IEnumerator AddCoinTextPopUp (int income)
    {
      addCoinText.SetText("+" + income);
      yield return new WaitForSeconds(addCoinTextStayTime);
      addCoinText.SetText("" );
      // addCoinText.enabled = false;
    }
}
