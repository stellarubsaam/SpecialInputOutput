using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchoredMotor : MonoBehaviour
{
    public int speed = 5;
    public Direction _direction = Direction.Clockwise;
    Transform _anchor;
    bool _isRunning = false;

    void Start() {
        _anchor = GameObject.FindGameObjectWithTag("Anchor").transform;
    }
    
    void Update() {
        if (_isRunning) {
            transform.RotateAround(_anchor.position, Vector3.forward, speed * Time.deltaTime * -(int)_direction);
        }      

        if (Input.GetKeyDown("space")) {
            if (!_isRunning) {
                _isRunning = true;
                return;
            }
            ChangeDirection();
        }
    }

    public void ChangeDirection() {
        switch (_direction) {
            case Direction.Clockwise:
                _direction = Direction.AntiClockwise;
                break;
            case Direction.AntiClockwise:
                _direction = Direction.Clockwise;
                break;
        }
    }
}

public enum Direction {
    Clockwise = 1,
    AntiClockwise = -1
}
