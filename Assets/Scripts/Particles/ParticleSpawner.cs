using UnityEngine;
using System.Collections;
using DentedPixel;
using Unity.VisualScripting;
using UnityEngine.UI;

public class ParticleSpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject electronPrefab;
    [SerializeField] private GameObject protonPrefab;
    [SerializeField] private GameObject neutronPrefab;
    [ReadOnly, SerializeField] private ParticleManager particleManager;
    [ReadOnly, SerializeField] private ParticleShower particleShower;
    [Header("General Settings")]
    [SerializeField] private bool animate;
    [Space]
    [SerializeField] private Vector2 startSize;
    [SerializeField] private Vector2 endSize;
    [Space]
    [SerializeField] private float animTime;
    [SerializeField] private LeanTweenType tweenType = LeanTweenType.easeInOutQuad;
    [Header("Electron Settings")] 
    [SerializeField] private Vector2 electronStartPos;
    [SerializeField] private Vector2 electronEndPos;
    [Header("Proton Settings")]
    [SerializeField] private Vector2 protonStartPos;
    [SerializeField] private Vector2 protonEndPos;
    [Header("Neutron Settings")]
    [SerializeField] private Vector2 neutronStartPos;
    [SerializeField] private Vector2 neutronEndPos;

    void Start()
    {
        particleManager = GetComponent<ParticleManager>();
        particleShower = GetComponent<ParticleShower>();
    }

    void Spawn(GameObject particlePrefab, Vector2 startPos, Vector2 endPos)
    {
        GameObject particleObj = Instantiate(particlePrefab);
        particleObj.transform.position = startPos;
        particleObj.transform.localScale = startSize;
        particleObj.transform.LeanMoveLocal(endPos, animTime).setEase(tweenType);
        particleObj.transform.LeanScale(endSize, animTime).setEase(tweenType).setOnComplete(() =>
        {
            particleObj.transform.LeanScale(startSize, animTime).setEase(tweenType).setOnComplete(() =>
            {
                Destroy(particleObj, animTime);
            });
        });
    }

    void Remove(GameObject particlePrefab, Vector2 startPos, Vector2 endPos)
    {
        GameObject particleObj = Instantiate(particlePrefab);
        particleObj.transform.position = endPos;
        particleObj.transform.localScale = endSize;
        particleObj.transform.LeanMoveLocal(startPos, animTime).setEase(tweenType);
        particleObj.transform.LeanScale(startSize, animTime).setEase(tweenType);
        Destroy(particleObj, animTime);
    }
    
    public void SpawnElectron()
    {
        particleManager.AddElectron();
        if (animate) Spawn(electronPrefab, electronStartPos, electronEndPos);
    }

    public void RemoveElectron()
    {
        if (particleManager.electronCount > 0)
        {
            particleManager.RemoveElectron();
            if (animate) Remove(electronPrefab, electronStartPos, electronEndPos);
        } 

    }
    
    public void SpawnProton()
    {
        particleManager.AddProton();
        if (animate) Spawn(protonPrefab, protonStartPos, protonEndPos);
    }
    
    public void RemoveProton()
    {
        if (particleManager.protonCount > 0)
        {
            particleManager.RemoveProton();
            if (animate) Remove(protonPrefab, protonStartPos, protonEndPos);
        } 
    }
    
    public void SpawnNeutron()
    {
        particleManager.AddNeutron();
        if (animate) Spawn(neutronPrefab, neutronStartPos, neutronEndPos);
    }
    
    public void RemoveNeutron()
    {
        if (particleManager.neutronCount > 0)
        {
            particleManager.RemoveNeutron();
            if (animate) Remove(neutronPrefab, neutronStartPos, neutronEndPos);
        } 
    }
}