using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    public static AudioSource singleton;

    void Awake()
    {
        if(singleton)
            Destroy(gameObject);
        singleton = GetComponent<AudioSource>();
        DontDestroyOnLoad(this);
    }
}
