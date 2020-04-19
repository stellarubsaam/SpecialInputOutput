using UnityEngine;
using System.IO.Ports;

public class DotDetector : MonoBehaviour
{
    GameObject _currentDot;
    bool _isRunning = false;
    public GameObject winOrLoss;
    public GameObject dotSpawner;
    public GameObject circlesLeft;
    public SerialPort sp = new SerialPort();
    public int onButtonClick;

    void Start() {
        sp.PortName = "COM3";
        sp.BaudRate = 9600;
        sp.Open();
        sp.ReadTimeout = 1;
    }

    void OnTriggerEnter2D(Collider2D other) {
        _currentDot = other.gameObject;
    }

    void OnTriggerExit2D(Collider2D collision) {
        _currentDot = null;
        if (onButtonClick != 1) {
            GetComponent<AnchoredMotor>().speed = 0;
            winOrLoss.GetComponent<WinOrLoss>().gameOver = true;
        }
    }

    void Update() {

        try {
            onButtonClick = sp.ReadByte();
        }
        catch (System.Exception) {
        }

        Debug.Log(onButtonClick);

        if (onButtonClick == 1) {
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
