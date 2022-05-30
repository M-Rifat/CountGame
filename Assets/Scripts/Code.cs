using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Code : MonoBehaviour
{
    public Button clickButton,exitButton,startButton;
    public int count = 0;
    public Text scoreText,timerText,gameOverText,resetText;
    public int check = -1;
    public float timeCheck;
    // Start is called before the first frame update
    void Start()
    {
        clickButton.onClick.AddListener(TaskOnClick);
        exitButton.onClick.AddListener(TaskOnExit);
        startButton.onClick.AddListener(TaskOnStart);
        clickButton.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(timer(4));
    }

    void TaskOnClick()
    {
        count++;
        scoreText.text = "Score : "+count.ToString();
        Debug.Log("Red Clicked " + count + " times");
    }
    void TaskOnExit()
    {
        Application.Quit();
    }
    void TaskOnStart()
    {
        gameOverText.text = "";
        clickButton.enabled = true;
        resetText.text="Restart";
         check = 1;
        timeCheck = Time.time;
    }
    IEnumerator timer(int seconds)
    {
        Debug.Log(seconds - Time.time);
        if (check == 1)
        {
            float checker = Time.time - timeCheck;
            if (checker > 4)
            {
                gameOverText.text = "Game over!";
                clickButton.enabled = false;
            }
            else
            {
                timerText.text = checker.ToString();
            }
        }
        yield return null;
    }
}