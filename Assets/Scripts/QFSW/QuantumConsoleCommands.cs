using System.Collections;
using System.Collections.Generic;
using QFSW.QC;
using UnityEngine;

public class QuantumConsoleCommands : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private JSONManager _jsonManager;
    [SerializeField] private ParticleManager _particleManager;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private CheckManager _checkManager;
    [SerializeField] private GuessManager _guessManager;

    void Start()
    {
        _jsonManager = GetComponent<JSONManager>();
        _particleManager = GetComponent<ParticleManager>();
        _scoreManager = GetComponent<ScoreManager>();
        _checkManager = GetComponent<CheckManager>();
        _guessManager = GetComponent<GuessManager>();
    }
    
    #region General
    
    [Command("reroll-element", "Rerolls the current element")]
    private void Reroll()
    {
        _jsonManager.RerollElement();
    }

    [Command("score-increase", "Increases score")]
    private void IncreaseScore()
    {
        _scoreManager.Increase();
    }

    [Command("score-decrease", "Decreases score")]
    private void DecreaseScore()
    {
        _scoreManager.Decrease();
    }
    
    [Command("die", "Triggers death screen")]
    private void Die()
    {
        _scoreManager.Die();
    }

    #endregion
    
    #region Build Mode
    
    [Command("reset", "Resets all particles")]
    private void Reset()
    {
        _particleManager.HeadlessReset();
    }
    
    [Command("reveal-solution-build", "Reveals solution on Build Mode.")]
    private void RevealSolutionBuild()
    {
        if (_checkManager != null) _checkManager.RevealSolution();
        else Debug.LogWarning("No CheckManager was found, you are probably in the wrong mode.");
    }

    [Command("solve-build", "Automatically solves the puzzle on Build Mode.")]
    private void SolveBuild()
    {
        if (_checkManager != null) _checkManager.Solve();
        else Debug.LogWarning("No CheckManager was found, you are probably in the wrong mode.");
    }

    #endregion
    
    #region Guess Mode

    [Command("set-atom", "Sets the correct atom on Guess Mode.")]
    private void SetAtom()
    {
        _guessManager.SetAtom();
    }

    [Command("reveal-solution-guess", "Reveals solution on Guess Mode.")]
    private void RevealSolutionGuess()
    {
        if (_guessManager != null) _guessManager.RevealSolution();
        else Debug.LogWarning("No GuessManager was found, you are probably in the wrong mode.");
    }

    [Command("solve-guess", "Automatically solves the puzzle on Guess Mode.")]
    private void SolveGuess()
    {
        if (_guessManager != null) _guessManager.Solve();
        else Debug.LogWarning("No GuessManager was found, you are probably in the wrong mode.");
    }
    
    #endregion
    

}
