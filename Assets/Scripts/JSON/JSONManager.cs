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
    
    [Header("References")]
    [SerializeField] private string _jsonUrl;
    [SerializeField] private TextMeshProUGUI _elementName;
    [ReadOnly] public Element _rElement;
    [SerializeField] private GuessManager _guessManager;
    [Header("Settings")]
    [SerializeField] private bool showElement;
    [SerializeField] private bool downloadFromUrl;
    
    void Start()
    {
        table = LoadJson(_jsonUrl);
        RerollElement();
        if (showElement) _elementName.text = _rElement.symbol;
    }

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
    
    PeriodicTable LoadJson(string jsonDir)
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

}
