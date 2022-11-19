using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedButton : MonoBehaviour
{
    [SerializeField] private float scaleMultiplier;
    Vector3 scaleOnStart;

    void Start() => scaleOnStart = transform.localScale;

    public void Hover()
    {
        transform.LeanScale(scaleOnStart * scaleMultiplier, 0.2f).setEase(LeanTweenType.easeInOutQuad);
    }

    public void DeHover()
    {
        transform.LeanScale(scaleOnStart, 0.2f).setEase(LeanTweenType.easeInOutQuad);
    }
}
