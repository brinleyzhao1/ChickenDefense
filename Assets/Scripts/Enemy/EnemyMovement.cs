using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] float movementPeriod = .5f;
    [SerializeField] ParticleSystem goalParticle;
     private Transform _body;


    // Use this for initialization
    void Start ()
    {
      Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        _body = transform.Find("Body");
        StartCoroutine(FollowPath(path));


    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position + new Vector3(0,2,0);
            TurnToRoadDirection(waypoint);
            yield return new WaitForSeconds(movementPeriod);

        }
        SelfDestruct();
    }

    private void TurnToRoadDirection(Waypoint waypoint)
    {
      if (waypoint.GetOrientation() == Orientation.Right)
      {
        _body.rotation = Quaternion.Euler(0,90,0);
      }
      else if (waypoint.GetOrientation() == Orientation.Left)
      {
        _body.rotation = Quaternion.Euler(0,-90,0);
      }
      else if (waypoint.GetOrientation() == Orientation.Down)
      {
        _body.rotation = Quaternion.Euler(0,180,0);
      }
      else if (waypoint.GetOrientation() == Orientation.Up)
      {
        _body.rotation = Quaternion.Euler(0,0,0);
      }
    }

    private void SelfDestruct()
    {
        var vfx = Instantiate(goalParticle, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(vfx.gameObject, vfx.main.duration);

        Destroy(gameObject); // the enemy
    }
}
