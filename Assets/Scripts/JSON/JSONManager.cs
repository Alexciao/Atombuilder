using System.Collections;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using TMPro;
using UnityEngine.Networking;
using UnityEngine;

public class JSONManager : MonoBehaviour
{
    public PeriodicTable table;
    public Splashes _splashes;

    public Element _rElement;
    public string _rSplash;

    [Header("References")]
    [SerializeField] private TextMeshProUGUI _elementName;
    [SerializeField] private GuessManager _guessManager;
    [Header("Settings")]
    [SerializeField] private bool showElement;
    [SerializeField] private bool downloadFromUrl;
    [Header("URLs")]
    [SerializeField] private string _tableUrl;
    [SerializeField] private string _splashesUrl;
    
    void Start()
    {
        table = LoadTable(_tableUrl);
        
        RerollElement();
        if (showElement) _elementName.text = _rElement.symbol;
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
        if (showElement) _elementName.text = _rElement.symbol;
        if (_guessManager != null) _guessManager.SetAtom();
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
        _rSplash = ChooseRandomSplash(_splashes);
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
    
    #endregion
}
