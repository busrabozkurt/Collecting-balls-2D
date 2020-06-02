using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Timer sets up.
public class Timer : MonoBehaviour
{ 
    private float currentTime = 0f;
    private float startingTime = 10.0f;
    public Text label;
    public int capsuleCount;
    public static bool isGameOver;
   
    [SerializeField]Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        capsuleCount = 0;
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        timerText.text = currentTime.ToString("0");
        timerText.color = Color.white;
        if (currentTime <= 0 || isGameOver)
        {
            currentTime = 0;
            timerText.text = "Game Over!!";
        }

        label.text = "Capsule: " + capsuleCount;
    }
}
