using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinOrLoss : MonoBehaviour
{
    public Text winOrLossText;
    public bool gameOver = false;
    public GameObject paddle;
    public GameObject circlesLeft;

    void Update()
    {
        if (circlesLeft.GetComponent<Score>().circlesLeft == 0) {
            paddle.GetComponent<AnchoredMotor>().speed = 0;
            winOrLossText.text = "JACKPOT!";
        }

        if (gameOver) {
            paddle.GetComponent<DotDetector>().sp.Close();
            winOrLossText.text = "GAME OVER";
            if (Input.GetKeyDown("space")) {
                SceneManager.LoadScene("Game");
            }
        }
    }
}
