using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public enum LevelsIndex {
    MENU,
    NOME_GIOCATORE,
    CREDITI,
    ATRIO,
    IISS_UNO,
    IISS_DUE,
    IISS_SECRET,
    LICEO_TERRA,
    LICEO_MENO_UNO,
    LICEO_UNO,
    LICEO_DUE
}

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
        StartCoroutine(StopPlayer());
        StartCoroutine(SwitchScene(buildIndex));
    }

    public void ChangeScene(string path)
    {
        StopAllCoroutines();
        StartCoroutine(StopPlayer());
        StartCoroutine(SwitchScene(path));
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

    IEnumerator SwitchScene(string path)
    {
        StartCoroutine(ShowCrossFade());

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(path);
        PrintTitleByBuildIndex(SceneUtility.GetBuildIndexByScenePath(path));

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

        if (buildIndex == (int)LevelsIndex.ATRIO)
            floorName = "Atrio";
        else if (buildIndex == (int)LevelsIndex.IISS_UNO)
            floorName = "Primo Piano";
        else if (buildIndex == (int)LevelsIndex.IISS_DUE)
            floorName = "Secondo Piano";
        else if (buildIndex == (int)LevelsIndex.IISS_SECRET)
            floorName = "Camera dei segreti";
        else if (buildIndex == (int)LevelsIndex.LICEO_MENO_UNO)
            floorName = "Piano -1 Liceo";
        else if (buildIndex == (int)LevelsIndex.LICEO_TERRA)
            floorName = "Piano Terra Liceo";
        else if (buildIndex == (int)LevelsIndex.LICEO_UNO)
            floorName = "Piano Uno Liceo";
        else if (buildIndex == (int)LevelsIndex.LICEO_DUE)
            floorName = "Piano Due Liceo";
        else return;
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