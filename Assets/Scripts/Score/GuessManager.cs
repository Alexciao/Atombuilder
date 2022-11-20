using System.Collections;
using System.Collections.Generic;
using System.Linq;
using QFSW.QC;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using TMPro;

public class GuessManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private ParticleManager _particleManager;
    [SerializeField] private JSONManager _jsonManager;
    [SerializeField] private ScoreManager _scoreManager;
    [Space]
    [SerializeField] private GameObject[] _guessButtons;
    [Space]
    [SerializeField] private ScreenDimmer _correctDimmer;
    [SerializeField] private ScreenDimmer _incorrectDimmer;

    [Header("Public Variables")] [ReadOnly]
    public int rightGuess;
    
    void Start()
    {
        _jsonManager = GetComponent<JSONManager>();
        _particleManager = GetComponent<ParticleManager>();
        _scoreManager = GetComponent<ScoreManager>();
    }
    
    public void SetAtom()
    {
        // Debug.Log("Setting atom to " + _jsonManager._rElement.symbol);
        _particleManager.electronCount = _jsonManager._rElement.atomicNumber;
        _particleManager.protonCount = _jsonManager._rElement.atomicNumber;
        if (_jsonManager._rElement.atomicNumber > 1)
        {
            _particleManager.neutronCount = _jsonManager._rElement.atomicNumber + Random.Range(-1, 2);
        }
        else
        {
            _particleManager.neutronCount = _jsonManager._rElement.atomicNumber;
        }
        
        UpdateGuesses();
    }

    public void UpdateGuesses()
    {
        rightGuess = Random.Range(0, _guessButtons.Length);

        for (int i = 0; i < _guessButtons.Length; i++)
        {
            if (i == rightGuess)
            {
                _guessButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = _jsonManager._rElement.symbol;
            }
            else
            {
                _guessButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = _jsonManager.table.elements[Random.Range(0, _jsonManager.table.elements.Count)].symbol;
            }
        }
    }

    public void Check(int guess)
    {
        if (guess == rightGuess)
        {
            _correctDimmer.Dim(0.2f, 0.5f);
            _jsonManager.RerollElement();
            SetAtom();
            _scoreManager.Increase();
        }
        else
        {
            _incorrectDimmer.Dim(0.2f, 0.5f);
            _scoreManager.Decrease();
        }
    }

    public void RevealSolution()
    {
        Debug.Log("The correct answer is " + _jsonManager._rElement.symbol);
    }

    public void Solve()
    {
        Check(rightGuess);
    }
}
