using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        // if there is more than one music player destroy the last one created.
        if(FindObjectsOfType<MusicPlayer>().Length > 1)
        {
            Destroy(gameObject);
        }
        else // only one music player is found
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
