using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFx : MonoBehaviour
{
    private SpriteRenderer sr;

    [Header("FlashFx")]
    [SerializeField] private Material hitMat;
    [SerializeField] private float hitFxDuration;
    private Material originalMat;

    [Header("Ailment colors")]
    [SerializeField] private Color[] igniteColor;
    [SerializeField] private Color[] chillColor;
    [SerializeField] private Color[] shockColor;
    

    private void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        originalMat = sr.material;
    }

    public void MakeTransparent(bool _transparent)
    {
        if (_transparent)
        {
            sr.color = Color.clear;
        }
        else
        {
            sr.color = Color.white;
        }
    }

    private IEnumerator FlashFx()
    {
        sr.material = hitMat;
        Color currentColor = sr.color;
        sr.color = Color.white;

        yield return new WaitForSeconds(hitFxDuration);

        sr.color = currentColor;
        sr.material = originalMat;
    }

    private void RedColorBlink()
    {
        if ( sr.color != Color.white )
        {
            sr.color = Color.white;
        }
        else
        {
            sr.color = Color.red;
        }
    }

    public void CancelColorChange()
    {
        CancelInvoke();
        sr.color = Color.white;
    }

    public void IgniteFxFor(float _seconds)
    {
        InvokeRepeating("IgniteColorFx", 0, .3f);
        Invoke("CancelColorChange", _seconds);
    }

    public void ChillFxFor(float _seconds)
    {
        InvokeRepeating("ChillColorFx", 0, .3f);
        Invoke("CancelColorChange", _seconds);
    }
   

    public void ShockFxFor(float _seconds)
    {
        InvokeRepeating("ShockColorFx", 0, .3f);
        Invoke("CancelColorChange", _seconds);
    }

    private void IgniteColorFx()
    {
        if (sr.color != igniteColor[0])
        {
            sr.color = igniteColor[0];
        }
        else
        {
            sr.color = igniteColor[1];
        }
    }

    private void ChillColorFx()
    {
        if (sr.color != chillColor[0])
        {
            sr.color = chillColor[0];
        }
        else
        {
            sr.color = chillColor[1];
        }
    }

    private void ShockColorFx()
    {
        if (sr.color != shockColor[0])
        {
            sr.color = shockColor[0];
        }
        else
        {
            sr.color = shockColor[1];
        }
    }
}
