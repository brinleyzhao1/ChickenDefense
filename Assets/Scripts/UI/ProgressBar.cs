using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
  public class ProgressBar : MonoBehaviour
  {
    [SerializeField] private Image progressBarFill;

    private void Start()
    {
      UpdateProgressBar(1f, 1f);
    }

    public void UpdateProgressBar(float currentSpawnInterval, float maxSpawnInterval)
    {
      progressBarFill.fillAmount = 1-(currentSpawnInterval / maxSpawnInterval);
    }
  }
}
