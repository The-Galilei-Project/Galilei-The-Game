using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSystem : MonoBehaviour
{
    public static LevelSystem current;
    private GameObject levelLoader;
    public TextMeshProUGUI text;
    //public string title;
    public Animator animator;

    private void Awake()
    {
        current = this;
        levelLoader = GameObject.Find("LevelLoader");
        DontDestroyOnLoad(levelLoader);
        //text = GameObject.Find("Text").GetComponent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        //animator = GameObject.Find("CrossFade").GetComponent(typeof(Animator)) as Animator;
    }

    public void ChangeScene(int buildIndex)
    {
        StopAllCoroutines();
        StartCoroutine(SwitchScene(buildIndex));
        StartCoroutine(StopPlayer());
    }

    private void PrintTitleByBuildIndex(int buildIndex)
    {
        string floorName = "";
        if (buildIndex == 0)
            floorName = "Atrio";
        else if (buildIndex == 1)
            floorName = "Primo Piano";
        else if (buildIndex == 2)
            floorName = "Secondo Piano";

        text.SetText(floorName);
        //this.text.SetText(SceneManager.GetSceneByBuildIndex(buildIndex).name);
        //Debug.Log(text);
    }

    private void HideTitle()
    {
        this.text.SetText("");
    }

    IEnumerator ShowCrossFade ()
    {
        animator.SetBool("Start", true);
        yield return new WaitForSeconds(1f);

        animator.SetBool("Start", false);
    }

    IEnumerator SwitchScene(int buildIndex)
    {
        StartCoroutine(ShowCrossFade());

        yield return new WaitForSeconds(0.8f);

        SceneManager.LoadScene(buildIndex);
        PrintTitleByBuildIndex(buildIndex);

        yield return new WaitForSeconds(0.8f);

        HideTitle();
    }

    IEnumerator StopPlayer()
    {
        PlayerState.SetSpeed(0f);

        yield return new WaitForSeconds(2f);

        PlayerState.SetSpeed(1f);
    }
}
