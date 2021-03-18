using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StarBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxStars(int stars)
    {
        slider.maxValue = stars;
       
    }

    public void SetStar(int stars)
    {
        slider.value = stars;
    }
}
