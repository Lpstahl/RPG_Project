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
    

    private void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        originalMat = sr.material;
    }

    private IEnumerator FlashFx()
    {
        sr.material = hitMat;
        yield return new WaitForSeconds(hitFxDuration);

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

    private void CancelRedBlink()
    {
        CancelInvoke();
        sr.color = Color.white;
    }
}
