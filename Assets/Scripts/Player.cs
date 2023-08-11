using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player current;

    private void Awake()
    {
        if (current != null && current != this)
            Destroy(this.gameObject);
        else
        {
            current = this;
        }
    }

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        CameraMotor.lookAt = this.transform;
    }

    private void Update()
    {
        //this.gameObject.SetActive();
        //if(SceneManager.GetActiveScene().buildIndex >= LevelSystem.baseBuildIndex)
        //{
        //    Destroy(current);
        //    current = null;
        //}
    }
}
