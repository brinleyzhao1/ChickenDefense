using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour {

    private float maxHitPoints = 10;
    private float _currentHitPoints;

    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] AudioClip enemyHitSfx;
    [SerializeField] AudioClip enemyDeathSfx;

    AudioSource _myAudioSource;

    private Coin _coin;
    [SerializeField] private int value = 10;

    [SerializeField] private Image healthBar;

    // private CoinPopUp coinPopUp;
    private void Start()
    {
      _currentHitPoints = maxHitPoints;

      _coin = FindObjectOfType<Coin>().GetComponent<Coin>();
      _myAudioSource = GetComponent<AudioSource>();

    }

    public void SetEnemyHealth(float health)
    {
      maxHitPoints = health;
      _currentHitPoints = health;
    }

    private void OnParticleCollision(GameObject other)
    {
      // print("enemy been hit");
        ProcessHit();
        if (_currentHitPoints <= 0)
        {
            KillEnemy();
        }
    }

    void ProcessHit()
    {
        _currentHitPoints = _currentHitPoints - 1;

        healthBar.fillAmount = _currentHitPoints / (float)maxHitPoints;
        hitParticlePrefab.Play();
        _myAudioSource.PlayOneShot(enemyHitSfx);

    }

    private void KillEnemy()
    {
        // important to instantiate before destroying this object
        var vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(vfx.gameObject, vfx.main.duration);
        AudioSource.PlayClipAtPoint(enemyDeathSfx, Camera.main.transform.position);

        _coin.AddCoin(value);
        // _coin.StartCoroutine("CoinTextPopup", transform.position);
        // coinPopUp.GetComponent<TextMeshPro>().SetText(value.ToString());
        // coinPopUp.enabled = true;

        Destroy(gameObject); // the enemy
    }
}
