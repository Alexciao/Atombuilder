using System.Collections;
using System.Collections.Generic;
using QFSW.QC;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class GuessManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private ParticleManager _particleManager;
    [SerializeField] private JSONManager _jsonManager;
    [SerializeField] private ScoreManager _scoreManager;
    [Space]
    [SerializeField] private ScreenDimmer _correctDimmer;
    [SerializeField] private ScreenDimmer _incorrectDimmer;
    
    void Start()
    {
        _jsonManager = GetComponent<JSONManager>();
        _particleManager = GetComponent<ParticleManager>();
        _scoreManager = GetComponent<ScoreManager>();
    }
    
    public void SetAtom()
    {
        Debug.Log("Setting atom to " + _jsonManager._rElement.symbol);
        _particleManager.electronCount = _jsonManager._rElement.atomicNumber;
        _particleManager.protonCount = _jsonManager._rElement.atomicNumber;
        _particleManager.neutronCount = _jsonManager._rElement.atomicNumber;
    }
}
