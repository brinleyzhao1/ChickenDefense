using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    [SerializeField] int health = 10;
    [SerializeField] int healthDecrease = 1;
    // [SerializeField] Text healthText;
    [SerializeField] AudioClip playerDamageSFX;
    private UIManager _uiManager;

    private void Start()
    {
      _uiManager = FindObjectOfType<UIManager>();
      _uiManager.UpdateHeartText(health);
    }


    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().PlayOneShot(playerDamageSFX);
        health -= healthDecrease;
        _uiManager.UpdateHeartText(health);

        if (health <= 0)
        {
          FindObjectOfType<LevelManager>().PlayerDead();
        }
    }

}
