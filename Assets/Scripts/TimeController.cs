using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
  public void BtnPause()
  {
    Time.timeScale = 0;
  }
  public void BtnPlayNormalSpeed()
  {
    Time.timeScale = 1;
  }
  public void BtnPlayDoubleSpeed()
  {
    Time.timeScale = 2;
  }
}
