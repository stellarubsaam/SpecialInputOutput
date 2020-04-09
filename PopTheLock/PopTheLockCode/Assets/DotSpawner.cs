using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotSpawner : MonoBehaviour {
    public AnchoredMotor Motor;
    public GameObject DotPrefab;

    public void Spawn() {
        var angle = Random.Range(20,120);
        var go = Instantiate(DotPrefab, Motor.transform.position, Quaternion.identity, Motor.transform.parent);
        go.transform.RotateAround(transform.position, Vector3.forward, -angle * (int)Motor._direction);
    }
}