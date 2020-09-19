using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public Text scoreText;
    public Text pauseButton;
    
    // Start is called before the first frame update
    public void Pause()
    {
        if(Time.timeScale > 0)
        {
            Time.timeScale = 0;
            pauseButton.text = "Resume";
        }
        else
        {
            Time.timeScale = 1;
            pauseButton.text = "Pause";
        }
    }

}
