using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    // istanza corrente che si può richiamare all'esterno
    public static DialogueManager current;

    // coda di stringhe che contengono il dialogo
    // negli index pari si trova chi sta parlando
    // negli index dispari si trova il discorso
    private Queue<string> sentences;

    // Testo dell'interlocutore
    public TextMeshProUGUI speaker;
    // Testo del discorso
    public TextMeshProUGUI textDialogue;

    // Variabile per sapere se è stata attivata la coroutine per animare il testo
    private bool isTyping;

    // Variabile che serve per tenere traccia del dialogo corrente
    private Dialogue playingDialogue;

    // TODO: Animzione da fare
    // public Animator animator;

    private void Awake()
    {
        // Serve per evitare la duplicazione del gameobject
        if (current != null && current!=this)
        {
            Destroy(this.gameObject);
            return;
        };

        current = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (!isTyping && playingDialogue != null)
        {
            DisplayNextSentence();
        }
    }

    private string NextString() => sentences.Dequeue();

    public void StartDialogue(Dialogue dialogue)
    {
        playingDialogue = dialogue;
        playingDialogue.isPlaying = true;
        sentences = dialogue.GetQueue();

        PlayerState.SetSpeed(0f);
        //ShowCanvas();


        //foreach (string currentString in sentences)
        //{
        //    ClearText();
        //    //Debug.Log(currentString);

        //}
    }

    void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        // Interlocutore
        speaker.text = sentences.Dequeue();

        StopAllCoroutines();
        isTyping = true;
        ClearText();

        // Discorso
        StartCoroutine(TypeWriterEffect(sentences.Dequeue()));
    }

    void EndDialogue()
    {
        // HideCanvas();
        playingDialogue.isPlaying = false;
        PlayerState.SetSpeed(1f);
        playingDialogue = null;
    }

    //void ShowCanvas() => animator.SetBool("active", true);

    //void HideCanvas() => animator.SetBool("active", false);

    void ClearText() => textDialogue.text = "";

    // Effetto che simula la scrittura del discorso
    IEnumerator TypeWriterEffect(string str)
    {
        foreach (char c in str.ToCharArray())
        {
            textDialogue.text += c;
            yield return null;
        }

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        isTyping = false;
    }

}
