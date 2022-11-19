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
    // [SerializeField] private LocalizationManager _localizationManager;
    [SerializeField] private CheckManager _checkManager;
    [SerializeField] private GuessManager _guessManager;

    void Start()
    {
        _jsonManager = GetComponent<JSONManager>();
        _particleManager = GetComponent<ParticleManager>();
        _scoreManager = GetComponent<ScoreManager>();
        // _localizationManager = GetComponent<LocalizationManager>();
        _checkManager = GetComponent<CheckManager>();
        _guessManager = GetComponent<GuessManager>();
    }
    
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

    [Command("reset", "Resets all particles")]
    private void Reset()
    {
        _particleManager.HeadlessReset();
    }
    
    // [Command("Change-Locale", "Changes the locale")]
    // private void ChangeLocale(int locale)
    // {
    //    _localizationManager.ChangeLocaleHeadless(locale);
    //}

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

    [Command("set-atom", "Sets the correct atom on Guess Mode.")]
    private void SetAtom()
    {
        _guessManager.SetAtom();
    }
}
