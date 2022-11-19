using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleShower : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] electrons;
    [SerializeField] private GameObject[] protons;
    [SerializeField] private GameObject[] neutrons;
    [SerializeField] private ParticleManager particleManager;

    void UpdateElectrons()
    {
        HideElectrons();
        for (int i = 0; i < particleManager.electronCount; i++)
        { 
            if (i < electrons.Length) electrons[i].SetActive(true);
        }
    }
    
    void UpdateProtons()
    {
        HideProtons();
        for (int i = 0; i < particleManager.protonCount; i++)
        {
            if (i < protons.Length) protons[i].SetActive(true);
        }
    }

    void UpdateNeutrons()
    {
        HideNeutrons();
        for (int i = 0; i < particleManager.neutronCount; i++)
        {
            if (i < neutrons.Length) neutrons[i].SetActive(true);
        }
    }

    void HideElectrons()
    {
        foreach (GameObject electron in electrons)
        {
            electron.SetActive(false);
        }
    }

    void HideProtons()
    {
        foreach (GameObject proton in protons)
        {
            proton.SetActive(false);
        }
    }
    
    void HideNeutrons()
    {
        foreach (GameObject neutron in neutrons)
        {
            neutron.SetActive(false);
        }
    }

    public void UpdateParticles()
    {
        UpdateElectrons();
        UpdateNeutrons();
        UpdateProtons();
    }

    void Update() => UpdateParticles();

    
    void Start()
    {
        HideElectrons();
        HideNeutrons();
        HideProtons();
    }
}
