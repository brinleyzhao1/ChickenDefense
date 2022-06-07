using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{

  // public int coin { get; set; } = 100;
  private UIManager _uiManager;
  [SerializeField] public int coin = 20;

  [SerializeField] private AudioClip coinInSFX;
  AudioSource _myAudioSource;



  private void Start()
  {
    _uiManager = FindObjectOfType<UIManager>();
    _uiManager.UpdateCoinText(coin);
    _myAudioSource = GetComponent<AudioSource>();
  }

  // public int coin = 10;
  public void AddCoin(int income)
  {
    StartCoroutine(_uiManager.AddCoinTextPopUp(income));
    coin += income;
    _uiManager.UpdateCoinText(coin);
    _myAudioSource.PlayOneShot(coinInSFX);
  }



  /*IEnumerator CoinTextPopup(Vector3 position)
  {
    GameObject coinText = Instantiate(coinPopUpPrefab, position, Quaternion.identity);
    yield return new WaitForSeconds(1f);
    Destroy(coinText);
  }*/

  public void SubtractCoin(int expense)
  {
    coin -= expense;
    _uiManager.UpdateCoinText(coin);
  }


}
