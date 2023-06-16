using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    private Entity entity;
    private CharacterStats myStats;
    private RectTransform myTransform;
    private Slider slider;

    private void Start()
    {
        myTransform = GetComponent<RectTransform>();
        entity = GetComponentInParent<Entity>();
        slider = GetComponentInChildren<Slider>();
        myStats = GetComponentInParent<CharacterStats>();

        entity.onFlipped += FlipUi;
        myStats.onHealthChanged += UpdateHealthUi;

        UpdateHealthUi();
    }

  
    private void UpdateHealthUi()
    {
        slider.maxValue = myStats.GetMaxHealthValue();
        slider.value = myStats.currentHealth;
    }

    private void FlipUi() => myTransform.Rotate(0, 180, 0);


    private void OnDisable()
    {
        entity.onFlipped -= FlipUi;
        myStats.onHealthChanged -= UpdateHealthUi;
    }
}
