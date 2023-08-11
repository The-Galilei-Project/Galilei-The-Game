using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSystem : MonoBehaviour
{
    public static LevelSystem current;
    public static int baseBuildIndex = 3;
    private GameObject levelLoader;
    private Canvas crossFade;
    public TextMeshProUGUI text;
    public Animator animator;

    private void Awake()
    {
        if (current != null && current != this)
        {
            Destroy(this.gameObject);
            return;
        }

        current = this;
        levelLoader = GameObject.Find("LevelLoader");
        DontDestroyOnLoad(levelLoader);
        crossFade = GetComponentInChildren<Canvas>();
    }

    public void ChangeScene(int buildIndex)
    {
        StopAllCoroutines();
        StartCoroutine(SwitchScene(buildIndex));
        StartCoroutine(StopPlayer());
    }

    private void HideTitle()
    {
        this.text.SetText("");
    }

    IEnumerator ShowCrossFade()
    {
        crossFade.sortingOrder = 1;
        animator.SetBool("Start", true);
        yield return new WaitForSeconds(2f);

        animator.SetBool("Start", false);
        crossFade.sortingOrder = -1;
    }

    IEnumerator SwitchScene(int buildIndex)
    {
        StartCoroutine(ShowCrossFade());

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(buildIndex);
        PrintTitleByBuildIndex(buildIndex);

        yield return new WaitForSeconds(1.5f);

        HideTitle();
    }

    IEnumerator StopPlayer()
    {
        PlayerState.speed = 0f;

        yield return new WaitForSeconds(2f);

        PlayerState.speed = 1f;
    }

    private void PrintTitleByBuildIndex(int buildIndex)
    {
        string floorName = "";
        if (buildIndex == baseBuildIndex)
            floorName = "Atrio";
        else if (buildIndex == baseBuildIndex + 1)
            floorName = "Primo Piano";
        else if (buildIndex == baseBuildIndex + 2)
            floorName = "Secondo Piano";

        StartCoroutine(TypeWriterEffect(floorName));
    }

    IEnumerator TypeWriterEffect(string str)
    {
        foreach (char c in str.ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(1f / 25f);
        }
    }
}
