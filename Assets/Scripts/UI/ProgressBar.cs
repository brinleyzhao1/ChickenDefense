using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
  [SerializeField] private Image progressBarFill;

    public void UpdateProgressBar(float currentSpawnInterval, float maxSpawnInterval)
    {
      progressBarFill.fillAmount = currentSpawnInterval / maxSpawnInterval;
    }
}
