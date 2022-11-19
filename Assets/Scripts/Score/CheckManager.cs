using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private JSONManager jsonManager;
    [SerializeField] private ParticleManager particleManager;
    [SerializeField] private ScoreManager scoreManager;
    [Space]
    [SerializeField] private ScreenDimmer _correctDimmer;
    [SerializeField] private ScreenDimmer _incorrectDimmer;
    [Header("Settings")]
    [SerializeField] private int neutronMarginOfError = 2;
    
    void Start()
    {
        jsonManager = GetComponent<JSONManager>();
        particleManager = GetComponent<ParticleManager>();
        scoreManager = GetComponent<ScoreManager>();
    }

    public void Check()
    {
        if (particleManager.electronCount == jsonManager._rElement.atomicNumber && particleManager.protonCount == jsonManager._rElement.atomicNumber && particleManager.neutronCount > jsonManager._rElement.atomicNumber - neutronMarginOfError)
        {
            Debug.Log("User built correct atom.");
            _correctDimmer.Dim(0.2f, 0.5f);
            particleManager.HeadlessReset();
            scoreManager.Increase();
            jsonManager.RerollElement();
        }
        else
        {
            Debug.Log("User built incorrect atom.");
            _incorrectDimmer.Dim(0.2f, 0.5f);
            particleManager.HeadlessReset();
            scoreManager.Decrease();
        }
    }

    public void RevealSolution()
    {
        Debug.Log("Electron count: " + jsonManager._rElement.atomicNumber);
        Debug.Log("Proton count: " + jsonManager._rElement.atomicNumber);
        Debug.Log("Neutron count : " + "> " + (jsonManager._rElement.atomicNumber - neutronMarginOfError));
    }

    public void Solve()
    {
        Debug.Log("Solving...");
        RevealSolution();
        particleManager.electronCount = jsonManager._rElement.atomicNumber;
        particleManager.protonCount = jsonManager._rElement.atomicNumber;
        particleManager.neutronCount = jsonManager._rElement.atomicNumber;
        Check();
    }
}
