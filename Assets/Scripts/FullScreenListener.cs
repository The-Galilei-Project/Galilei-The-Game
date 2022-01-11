using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenListener : MonoBehaviour
{
    public static FullScreenListener current;

    private void Awake()
    {
        if (current != null && current != this)
        {
            Destroy(this.gameObject);
            return;
        };

        current = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F4))
        {
            Screen.fullScreen = !Screen.fullScreen;
        }
    }
}
