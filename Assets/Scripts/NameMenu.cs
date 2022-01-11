using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NameMenu : MonoBehaviour
{
    private Canvas canvas;
    private TMP_InputField input;
    private bool canPlay;

    void Awake()
    {
        canvas = this.GetComponent<Canvas>();
        input = canvas.GetComponentInChildren<TMP_InputField>();
        canPlay = false;
    }

    public void SetName()
    {
        string name = input.text.Trim();
        PlayerState.name = name;
        canPlay = name != null && name != "";
    }

    //private byte Test(string str)
    //{
    //    string value = str;

    //    // Convert the string into a byte[].
    //    byte asciiBytes = Encoding.ASCII.GetBytes(value)[0];

    //    return asciiBytes;
    //}

    public void Play()
    {
        if (!canPlay)
            return;

        canvas.sortingOrder = 0;
        LevelSystem.current.ChangeScene(LevelSystem.baseBuildIndex);
        Cursor.visible = false;
    }

    public void GoBack()
    {
        SceneManager.LoadScene(0);
    }

}
