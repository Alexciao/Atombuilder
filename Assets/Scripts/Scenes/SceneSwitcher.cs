using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void Switch(int buildIndex)
    {
        StartCoroutine(LoadScene(buildIndex));
    }

    public void Reload()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex));
    }
    
    IEnumerator LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
        yield return null;
    }
}
