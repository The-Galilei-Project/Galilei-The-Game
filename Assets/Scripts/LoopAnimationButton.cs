using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopAnimationButton : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite pressed;
    public Sprite up;
    public float seconds;

    Coroutine playingAnimation;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        seconds = 0.7f;
    }

    private void Start()
    {
        playingAnimation = StartCoroutine(loop(seconds));
    }

    IEnumerator loop(float seconds)
    {
        spriteRenderer.sprite = up;

        yield return new WaitForSeconds(seconds);

        spriteRenderer.sprite = pressed;

        yield return new WaitForSeconds(seconds);

        StartCoroutine(loop(seconds));
    }
}
