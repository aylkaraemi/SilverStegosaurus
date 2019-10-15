using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public static float timeLeft = 180.0f; // time left in seconds
    public Text countdown;
    private static float minLeft = Mathf.Floor(timeLeft / 60); // minutes left
    private static float secLeft = Mathf.Floor(timeLeft%60); // seconds left

    // Start is called before the first frame update
    void Start()
    {
        countdown.text = string.Format("{0}:{1:00}", minLeft, secLeft);
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        minLeft = Mathf.Floor(timeLeft / 60);
        secLeft = Mathf.Floor(timeLeft % 60);
        countdown.text = string.Format("{0}:{1:00}", minLeft, secLeft);
        if (timeLeft <= 0)
        {
            SceneManager.LoadScene("LoseScreen", LoadSceneMode.Single);
        }
    }
}
