using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

    // [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;
    [SerializeField] Transform towerParentTransform;
    [SerializeField] private int towerPrice = 5;

    [SerializeField] private AudioClip towerSfx;
    [SerializeField] private AudioClip errorSfx;
    AudioSource _myAudioSource;

    private Coin _coin;
    // Queue<Tower> towerQueue = new Queue<Tower>();
    private void Start()
    {
     _coin = FindObjectOfType<Coin>().GetComponent<Coin>();
     _myAudioSource = GetComponent<AudioSource>();
    }

    public void AddTower(TowerBase baseBlock)
    {
      if (_coin.coin >= towerPrice)
      {
        _coin.SubtractCoin(towerPrice);
        InstantiateNewTower(baseBlock);
        _myAudioSource.PlayOneShot(towerSfx);
      }
      else
      {
        _myAudioSource.PlayOneShot(errorSfx);
      }

    }

    public void InstantiateNewTower(TowerBase baseBlock)
    {
        var newTower = Instantiate(towerPrefab, baseBlock.transform.position, Quaternion.identity);
        newTower.transform.parent = towerParentTransform;

        baseBlock.isPlaceable = false;

    }

}
