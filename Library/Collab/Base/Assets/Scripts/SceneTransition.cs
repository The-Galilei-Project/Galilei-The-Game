using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    //public Animator transition;
    public float transitionTime = 1f;
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
            //SceneManager.LoadScene(indexFloor);
            LevelSystem.current.ChangeScene(indexFloor);
        }
    }
}