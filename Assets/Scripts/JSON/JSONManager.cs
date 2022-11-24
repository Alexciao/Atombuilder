using System.Collections;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using TMPro;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class JSONManager : MonoBehaviour
{
    public PeriodicTable table;
    public Splashes _splashes;

    public Element _rElement;
    [HideInInspector] public string _rSplash;

    [Header("References")]
    // Should have put this in a separate script, but I'm lazy
    [SerializeField] private TextMeshProUGUI _elementName;
    [SerializeField] private TextMeshProUGUI _splashText;
    [Space]
    [SerializeField] private GuessManager _guessManager;
    [Header("Settings")] 
    [SerializeField] private bool doPeriodicTable = true;
    [Space]
    [SerializeField] private bool showElement;
    [SerializeField] private bool downloadFromUrl = true;
    [Header("URLs")]
    [SerializeField] private string _tableUrl;
    [Space]
    [SerializeField] private string _splashesUrlLocalization0;
    [SerializeField] private string _splashesUrlLocalization1;
    
    void Start()
    {
        if (doPeriodicTable) InitializePeriodicTable();
        // Splash initialization gets done through LocalizationManager
    }

    void InitializePeriodicTable()
    {
        table = LoadTable(_tableUrl);
        RerollElement();
        if (showElement) _elementName.text = _rElement.symbol;
    }
    
    void InitializeSplashText()
    {
        _splashes = LoadSplashes(_splashesUrlLocalization0); // Fallback
        FixSplashLocale();
        RerollSplash();
    }

    void FixSplashLocale()
    {
        if (PlayerPrefs.GetInt("LocaleKey", 0) == 0) _splashes = LoadSplashes(_splashesUrlLocalization0);
        if (PlayerPrefs.GetInt("LocaleKey", 0) == 1) _splashes = LoadSplashes(_splashesUrlLocalization1);
    }
    
    #region Periodic Table
    
    public Element ChooseRandomElement(PeriodicTable table)
    {
        int elements = table.elements.Count;
        int randomElement = Random.Range(0, elements);
        Debug.Log("Random element: " + table.elements[randomElement].symbol);
        return table.elements[randomElement];
    }
    public void RerollElement()
    {
        _rElement = ChooseRandomElement(table);
        if (_guessManager != null) _guessManager.SetAtom();
        SetElementText();
    }

    PeriodicTable LoadTable(string jsonDir)
    {
        if (!downloadFromUrl)
        {
            string json = File.ReadAllText(jsonDir);
            PeriodicTable data = JsonConvert.DeserializeObject<PeriodicTable>(json);
            return data;
        }
        else
        {
            string json = new WebClient().DownloadString(jsonDir);
            PeriodicTable data = JsonConvert.DeserializeObject<PeriodicTable>(json);
            return data;
        }
    }

    void SetElementText()
    {
        if (showElement) _elementName.text = _rElement.symbol;
    }
    
    #endregion

    #region Splash Text

    public string ChooseRandomSplash(Splashes splashes)
    {
        int splashesCount = splashes.splashes.Count;
        int randomSplash = Random.Range(0, splashesCount);
        Debug.Log("Random splash: " + splashes.splashes[randomSplash]);
        return splashes.splashes[randomSplash];    
    }
    
    public void RerollSplash()
    {
        FixSplashLocale();
        _rSplash = ChooseRandomSplash(_splashes);
        SetSplashText();
    }
    
    Splashes LoadSplashes(string jsonDir)
    {
        if (!downloadFromUrl)
        {
            string json = File.ReadAllText(jsonDir);
            Splashes data = JsonConvert.DeserializeObject<Splashes>(json);
            return data;
        }
        else
        {
            string json = new WebClient().DownloadString(jsonDir);
            Splashes data = JsonConvert.DeserializeObject<Splashes>(json);
            return data;
        }
    }
    
    void SetSplashText()
    {
        _splashText.text = _rSplash;
    }
    
    #endregion
}
