using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public static float timeLeft; // time left in seconds
    public Text countdown;
    private static float minLeft; // minutes left
    private static float secLeft; // seconds left
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = 180.0f;
        minLeft = Mathf.Floor(timeLeft / 60);
        secLeft = Mathf.Floor(timeLeft % 60);
        anim = GetComponent<Animator>();
        anim.SetTrigger("ReturnToBase");
        countdown.text = string.Format("{0}:{1:00}", minLeft, secLeft);
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        minLeft = Mathf.Floor(timeLeft / 60);
        secLeft = Mathf.Floor(timeLeft % 60);
        countdown.text = string.Format("{0}:{1:00}", minLeft, secLeft);
        if (timeLeft <= 20.0f)
        {
            //anim.enabled = true;
            anim.SetTrigger("ActivateFlash");
        }
        if (timeLeft < 3)
        {
            MusicManager.Instance.FadeCurrentTrackOut();
        }
        if (timeLeft < 0.5)
        {
            //anim.enabled = false;
            countdown.color = Color.red;
            GameManager.Instance.PlayerLoses();
        }
    }
}
