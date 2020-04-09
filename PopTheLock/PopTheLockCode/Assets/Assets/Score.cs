using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int circlesLeft = 50;
    public Text circlesLeftText;
    
    void Update() {
        if(circlesLeft < 0) {
            circlesLeft = 0;
        }
        circlesLeftText.text = circlesLeft.ToString();
    }
}
