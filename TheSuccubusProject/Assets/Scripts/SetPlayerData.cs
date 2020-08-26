using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerData : MonoBehaviour
{
    
    void Start()
    {
        //Set player health, life force
        PlayerPrefs.SetFloat("PlayerHP", 100);
        PlayerPrefs.SetFloat("PlayerLF", 0);

    }

}
