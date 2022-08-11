using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FillStatusBar : MonoBehaviour
{
    public Health health;
    public Image fillImage;
    public TMP_Text currentHealthText;
    private Slider slider;


    private void Awake() {
        slider = GetComponent<Slider>();       
    }
    private void Update() {
        float fillValue = (float)health.currentHealth / (float)health.maxHealth;     
        slider.value = fillValue;
        currentHealthText.text = health.currentHealth.ToString();
        
        if(slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }
        if(slider.value > slider.minValue && !fillImage.enabled)
        {
            fillImage.enabled = true;
        }
        if(fillValue <= slider.maxValue/3)
        {
            fillImage.color = Color.red;
            //currentHealthText.text = "I'm dying.....";
        }
        //ANNA's WUNSCH...Ich bin zu müde...sorry...
        // if(fillValue <= slider.maxValue/1)
        // {
        //     currentHealthText.text = "I need to move faster...";
        // }
        else if(fillValue > slider.maxValue/3)
        {
            //default color 
        }
    }
}
