using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CanvasGroup mainMenu;
    [SerializeField] private GameObject popupMenu;

    [Header("Settings")]
    [SerializeField] private float openAnimationTime = 0.5f;
    [SerializeField] private float closeAnimationTime = 0.5f;
    
    [Space]
    [SerializeField] private float mainMenuAlpha = 0.3f;
    
    [Space]
    [SerializeField] private bool hideMainMenu = true;

    [Space]
    [SerializeField] private LeanTweenType openAnimationType = LeanTweenType.easeSpring;
    [SerializeField] private LeanTweenType closeAnimationType = LeanTweenType.easeInOutQuad;
    
    private void Start()
    {
        popupMenu.transform.localScale = Vector2.zero;
    }

    public void Open()
    {
        popupMenu.transform.LeanScale(Vector2.one, openAnimationTime).setEase(openAnimationType);
        if (hideMainMenu) mainMenu.LeanAlpha(mainMenuAlpha, openAnimationTime);
    }

    public void Close()
    {
        popupMenu.transform.LeanScale(Vector2.zero, closeAnimationTime).setEase(closeAnimationType);
        if (hideMainMenu) mainMenu.LeanAlpha(1, closeAnimationTime);
    }
}
