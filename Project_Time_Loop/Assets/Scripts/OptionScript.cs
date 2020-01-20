using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionScript : MonoBehaviour
{
    public GameObject pausePanel;
    public static bool isPaused;

    public GameObject messagePanel;
    public GameObject timerPanel;
    public static bool showMessage;
    public static bool showTimer;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&!isPaused)
        {
            isPaused = true;
            Time.timeScale = 0;
            pausePanel.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            isPaused = false;
            Time.timeScale = 1;
            pausePanel.SetActive(false);

            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
        }

        if (showMessage) { messagePanel.GetComponent<Animator>().SetBool("Message", true); }
        else { messagePanel.GetComponent<Animator>().SetBool("Message", false); }
        if (showTimer) { timerPanel.GetComponent<Animator>().SetBool("Timer", true); }
        else { timerPanel.GetComponent<Animator>().SetBool("Timer", false); }
    }
}
