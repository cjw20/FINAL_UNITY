using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider HP;

    public void SetMaxHealth(int health)
    {
        HP.maxValue = health;
        HP.value = health;
    }

    public void SetHealth(int health)
    {
        HP.value = health; 
    }

    
}
