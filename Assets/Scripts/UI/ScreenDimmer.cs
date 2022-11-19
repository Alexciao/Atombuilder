using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenDimmer : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject screenDimmer;
    [SerializeField] private CanvasGroup screenDimmerCanvasGroup;

    private void Start()
    {
        if (!screenDimmerCanvasGroup) screenDimmerCanvasGroup = screenDimmer.GetComponent<CanvasGroup>();
        screenDimmer.SetActive(false);
        screenDimmerCanvasGroup.alpha = 0;
    }
    
    public void Dim(float time, float delay)
    {
        StartCoroutine(DimCoroutine(time, delay));
    }

    private IEnumerator DimCoroutine(float time, float delay)
    {
        screenDimmer.SetActive(true);
        screenDimmerCanvasGroup.LeanAlpha(1, time).setOnComplete(() =>
        {
            screenDimmerCanvasGroup.LeanAlpha(0, time).setDelay(delay * 2).setOnComplete(() =>
            {
                screenDimmer.SetActive(false);
            });
        });
        yield return null;
    }
}
