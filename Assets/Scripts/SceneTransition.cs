using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    //public Animator transition;
    public VectorValue initialPosition;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            int indexFloor = SceneManager.GetActiveScene().buildIndex;
            if (name.Contains("up"))
                indexFloor++;
            else if (name.Contains("down"))
                indexFloor--;

            PlayerState.setPosition(initialPosition);
            LevelSystem.current.ChangeScene(indexFloor);
        }
    }
}