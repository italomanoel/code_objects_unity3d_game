using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    public static int misses = 0;
    public Text gameOverText; // game over text
    private void Start()
    {
        gameOverText.enabled = false; //set false when start
    }
    void OnMouseDown() {
        Background.misses++;
        /*misses = misses + 1;*/
        print("MISSES: " + Background.misses);
        if (Background.misses >= 10)
        {
            GameOver();
        }
    }
    private void GameOver()
    {
        gameOverText.enabled = true;
    }
    private void OnGUI()
    {
        GUI.contentColor = Color.red; //put collor on letters.
        GUI.Label(new Rect(300, 30, 200, 25), "Pontos fora " + misses); //xy scale xy        
    }

}
