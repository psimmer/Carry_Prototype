using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Menu Music keeps playing even if scene changes to OptionsMenu. To stop the Menu Music in Main Scene, the GameManager destroys it anyway.
public class MenuMusic : MonoBehaviour
{
    private void Awake()
    {
        // In case the Menu Music is already playing. Possible when you go from OptionsMenu back to MainMenu.
        if (GameObject.FindGameObjectsWithTag("MenuMusic").Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}