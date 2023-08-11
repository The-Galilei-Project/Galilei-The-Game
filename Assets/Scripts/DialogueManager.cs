using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    // istanza corrente che si può richiamare all'esterno
    public static DialogueManager current;

    // coda di stringhe che contengono il dialogo
    // negli index pari si trova chi sta parlando
    // negli index dispari si trova il discorso
    private Queue<string> sentences;

    public GameObject boxDialogue;
    // Testo dell'interlocutore
    public string speaker;
    // Testo del discorso
    public TextMeshProUGUI textDialogue;

    public Image speakerHead;

    // Variabile per sapere se è stata attivata la coroutine per animare il testo
    private bool isTyping;

    //public float charsForSeconds = 30f;
    //public float btnPressVelocity = 4f;
    //public bool isDefault = true;
    //public bool isPressed = false;
    private const int CHARSROW = 28;
    private int cntChars = CHARSROW;

    // Variabile che serve per tenere traccia del dialogo corrente
    private Dialogue playingDialogue;

    public Animator animator;

    public enum DirectionsNPC
    {
        UP = 0,
        DOWN = 1,
        LEFT = 2,
        RIGHT = 3
    }

    private void Awake()
    {
        // Serve per evitare la duplicazione del gameobject
        if (current != null && current != this)
        {
            Destroy(this.gameObject);
            return;
        };

        current = this;
        DontDestroyOnLoad(this.gameObject);
        HideCanvas();
    }

    void Update()
    {
        if (!isTyping && playingDialogue != null)
        {
            DisplayNextSentence();
        }

        //if (isTyping)
        //{
        //    if (Input.GetKeyDown(KeyCode.E) && !isPressed)
        //    {
        //        isPressed = true;
        //        charsForSeconds *= btnPressVelocity;
        //        isDefault = false;
        //    }
        //    else if (!Input.GetKeyDown(KeyCode.E) && !isDefault)
        //    {
        //        isPressed = false;
        //        charsForSeconds /= btnPressVelocity;
        //        isDefault = true;
        //    }
        //}
    }

    private string NextSentence() => sentences.Dequeue();

    public void StartDialogue(Dialogue dialogue)
    {
        playingDialogue = dialogue;
        playingDialogue.isPlaying = true;
        sentences = dialogue.GetQueue();
        //playingDialogue;

        PlayerState.speed = 0f;
        ShowCanvas();
    }

    private string[] splitDialogue(string sentence)
    {
        int startIndex = 0;
        List<string> splitSentence = new List<string>();
        string newSentence;
        while ((newSentence = getNextSplitSentence(sentence, startIndex)) != null)
        {
            splitSentence.Add(newSentence.TrimStart());
            startIndex += newSentence.Length;
        }

        return splitSentence.ToArray();
    }

    private string getNextSplitSentence(string sentence, int startIndex)
    {
        if (startIndex >= sentence.Length)
        {
            return null;
        }

        if (sentence.Length <= 84 + startIndex)
        {
            return sentence.Substring(startIndex, sentence.Length - startIndex);
        }

        int idxSpace = sentence.LastIndexOf(' ', startIndex + 84, 84);

        return sentence.Substring(startIndex, idxSpace - startIndex);

    }

    void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        // Interlocutore
        //speaker.text = NextSentence().Replace("NAME", PlayerState.name);
        if ((speaker = NextSentence()) == "NAME")
        {
            speakerHead.sprite = playingDialogue.playerSprite;
        }
        else
        {
            speakerHead.sprite = playingDialogue.NPCSprite;
        }

        StopAllCoroutines();
        isTyping = true;
        ClearText();

        cntChars = CHARSROW;
        // Discorso
        StartCoroutine(TypeWriterEffect(splitDialogue(NextSentence())));
    }

    void EndDialogue()
    {
        HideCanvas();
        //playingDialogue.setActiveSprite((int)DialogueManager.DirectionsNPC.DOWN);
        playingDialogue.isPlaying = false;
        PlayerState.speed = 1f;
        playingDialogue = null;
    }

    void ShowCanvas() => animator.SetBool("active", true);

    public void HideCanvas() => animator.SetBool("active", false);

    void ClearText() => textDialogue.text = "";

    // Effetto che simula la scrittura del discorso
    IEnumerator TypeWriterEffect(string[] strArray)
    {
        foreach (string sentence in strArray)
        {
            cntChars = CHARSROW;
            foreach (string str in sentence.Replace("NAME", PlayerState.name).Split(' '))
            {
                if ((cntChars -= str.Length) >= 0) cntChars--;
                else
                {
                    textDialogue.text += "\n";
                    cntChars = CHARSROW - str.Length;
                }
                foreach (char c in str.ToCharArray())
                {
                    textDialogue.text += c;
                    yield return new WaitForSeconds(1f / 30f);
                }
                textDialogue.text += ' ';
            }


            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
            ClearText();
        }
        isTyping = false;
    }
}
