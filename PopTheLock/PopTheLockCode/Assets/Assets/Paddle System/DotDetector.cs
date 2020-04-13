using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class DotDetector : MonoBehaviour
{
    GameObject _currentDot;
    bool _isRunning = false;
    public GameObject winOrLoss;
    public GameObject dotSpawner;
    public GameObject circlesLeft;
    //public SerialPort sp = new SerialPort("COM3", 9600);

    void Start() {
        //sp.Open();
        //sp.ReadTimeout = 20;
    }

    void OnTriggerEnter2D(Collider2D other) {
        _currentDot = other.gameObject;
    }

    void OnTriggerExit2D(Collider2D collision) {
        _currentDot = null;
        if (!Input.GetKeyDown("space")) {
            GetComponent<AnchoredMotor>().speed = 0;
            winOrLoss.GetComponent<WinOrLoss>().gameOver = true;
        }
    }

    void Update() {

        if (Input.GetKeyDown("space")) {
            if (!_isRunning) {
                _isRunning = true;
                return;
            }
            if(_currentDot != null) {
                Destroy(_currentDot);
                dotSpawner.GetComponent<DotSpawner>().Spawn();
                GetComponent<AnchoredMotor>().speed += 2;
                circlesLeft.GetComponent<Score>().circlesLeft -= 1;
            }
            else {
                GetComponent<AnchoredMotor>().speed = 0;
                winOrLoss.GetComponent<WinOrLoss>().gameOver = true;
            }
        }
    }
}
