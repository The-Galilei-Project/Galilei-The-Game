using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsMenu : MonoBehaviour
{
    public void GoBack()
    {
        SceneManager.LoadScene(0);
    }
}
