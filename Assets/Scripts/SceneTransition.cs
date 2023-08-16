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
            // mi memorizzo Index della scena
            int indexFloor = SceneManager.GetActiveScene().buildIndex;

            //Debug.Log(name);

            // se l'oggetto contiene liceo, vado a selezionare il piano per quanto riguarda il liceo
            // in caso contrario spostarsi sul piano dell'itis
            if (!name.Contains("Liceo")) // ramo non liceo
            {
                if (name.Contains("up"))
                    indexFloor++;
                else if (name.Contains("down"))
                    indexFloor--;
                else if (name.Contains("dSP"))
                    indexFloor = 6; // secret room
                else if (name.Contains("uSP"))
                    indexFloor = 3;
                else if (name.Contains("menu"))
                    indexFloor = 0;
            }

            else // ramo liceo
            {
                if (name.Contains("pianoTerra"))
                    indexFloor = 7;
                else if (name.Contains("pianoMenoUno"))
                    indexFloor = 8;
            }

            if (name.Contains("ITI"))
                indexFloor = 3;

            Debug.Log(indexFloor);

            PlayerState.setPosition(initialPosition);
            LevelSystem.current.ChangeScene(indexFloor);
        }
    }
}
// Sessione remota test 15-04-2022 
// ciao David 
// ciao Marcheselli