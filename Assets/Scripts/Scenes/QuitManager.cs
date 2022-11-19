using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitManager : MonoBehaviour
{
    public void Quit()
    {
        Debug.Log("Goodbye");
        Application.Quit();
    }
}
