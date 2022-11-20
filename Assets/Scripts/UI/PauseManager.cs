using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private KeyCode pauseKey = KeyCode.Escape;
    public static bool isPaused = false;
    [SerializeField] private bool stopTime = true;
    [Header("References")]
    [SerializeField] private GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(pauseKey)) {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        if (stopTime) Time.timeScale = 1f;
        isPaused = false;
    }
    
    public void Pause()
    {   
        pauseMenuUI.SetActive(true);
        if (stopTime) Time.timeScale = 0f;
        isPaused = true;
    }
}
