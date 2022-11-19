using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI electronText;
    [SerializeField] private TextMeshProUGUI protonText;
    [SerializeField] private TextMeshProUGUI neutronText;
    [Space, SerializeField, ReadOnly] private ScreenDimmer dimmer;
    [Header("Public Variables")]
    [ReadOnly] public int electronCount;
    [ReadOnly] public int protonCount;
    [ReadOnly] public int neutronCount;
    
    
    private void Start()
    { 
        dimmer = GetComponent<ScreenDimmer>();
        HeadlessReset();
    }

    public void Reset()
    {
        if (dimmer != null) dimmer.Dim(0.2f, 0.6f);
        HeadlessReset();
    }
    
    public void HeadlessReset()
    {
        electronCount = 0;
        protonCount = 0;
        neutronCount = 0;
    }

    private void UpdateText()
    {
        electronText.text = electronCount.ToString();
        protonText.text = protonCount.ToString();
        neutronText.text = neutronCount.ToString();
    }

    private void Update()
    {
        UpdateText();
    }
}
