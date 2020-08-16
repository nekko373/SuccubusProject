using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeForce : MonoBehaviour
{


    public Slider slider;
    public void SetMaxLF(float lifeForce)
    {
        slider.maxValue = lifeForce;
      

    }

    // Update is called once per frame
    public void SetLifeForce(float lifeForce)
    {
        slider.value = lifeForce;
    }
}
