using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool GiocoInPausa = false;
    public GameObject PauseMenuUI;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GiocoInPausa)
                Riprendi();
            else
                Pausa();
        }
    }

    public void Riprendi()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GiocoInPausa = false;
        Cursor.visible = false;
    }

    void Pausa()
    {
        Cursor.visible = true;
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GiocoInPausa = true;
    }

    public void MainMenu()
    {
        DialogueManager.current.HideCanvas();
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void Esci()
    {
        Application.Quit();
    }
}
