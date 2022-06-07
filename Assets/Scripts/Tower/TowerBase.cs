using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerBase : MonoBehaviour
{
    [HideInInspector] public bool isPlaceable = true;
    // Start is called before the first frame update


    private void OnMouseDown()
    {
      if (EventSystem.current.IsPointerOverGameObject())
      {
        
        //It means clicked on panel. So we do not consider this as click on game Object. Hence returning.
        return;
      }
      else{
        if (Input.GetMouseButtonDown(0)) // left click
        {
          // print("clicked");
          if (isPlaceable)
          {
            // FindObjectOfType<TowerFactory>().AddTower(this);
            FindObjectOfType<TowerFactory>().AddTower(this);
            // print("tower placed");
          }
          else
          {
            print("Can't place here");
          }
        }
        //clicked directly on game object.
      }
    }

    void OnMouseOver()
    {

    }
}
