using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization;

public class LocalizationManager : MonoBehaviour
{
    private bool active = false;
    [SerializeField, ReadOnly] private ScreenDimmer dimmer;
    [SerializeField] private bool updateSplashText;
    [SerializeField] private JSONManager jsonManager;

    void Start()
    {
        dimmer = GetComponent<ScreenDimmer>();
        int playerLanguage = PlayerPrefs.GetInt("LocaleKey", 0);
        ChangeLocaleHeadless(playerLanguage);
    }
    
    public void ChangeLocaleHeadless(int localeId)
    {
        if (active) return;
        StartCoroutine(SetLocale(localeId));
    }
    
    public void ChangeLocale(int localeId)
    {
        if (active) return;
        if (dimmer) dimmer.Dim(0.2f, 0.5f);
        StartCoroutine(SetLocale(localeId));
    }

    IEnumerator SetLocale(int localeId)
    {
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeId];
        PlayerPrefs.SetInt("LocaleKey", localeId);
        active = false;
        if (updateSplashText) jsonManager.RerollSplash();
    }
}
