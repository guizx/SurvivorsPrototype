using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    //health
    public Slider healthSlider;
    //xp
    public Slider xpSlider;
    public TextMeshProUGUI levelText;
    //timer
    Character character;

    // Start is called before the first frame update
    public void Start()
    {
        character = FindObjectOfType<Character>();
        //health
        healthSlider.minValue = 0;
        healthSlider.maxValue = character.currentHp;   
    }
    // Update is called once per frame
    void Update()
    {
        xpSlider.maxValue = (float)character.GetComponent<Level>().TO_LEVEL_UP;
        xpSlider.value = (float)character.GetComponent<Level>().experience;

        healthSlider.value = character.currentHp;
    }
}
