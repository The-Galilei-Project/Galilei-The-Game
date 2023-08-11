using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class MainMenu : MonoBehaviour
{
    private Canvas canvas;

    private void Awake()
    {
        canvas = this.GetComponent<Canvas>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null){
            Destroy(player);
        }

    }

    public void InsertName()
    {
        if (PlayerState.name == null || PlayerState.name == "")
            SceneManager.LoadScene(1);
        else
            LevelSystem.current.ChangeScene(LevelSystem.baseBuildIndex);
    }

    public void Credits()
    {
        SceneManager.LoadScene(2);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
