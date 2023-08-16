using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOnTouchRespawnSystem : MonoBehaviour
{
    private Transform selfPosition;
    public Transform touchedToSpawnPosition;
    public Transform selfToSpawnPosition;

    void Start(){
        selfPosition = GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        selfPosition.position = selfToSpawnPosition.position;

        collision.transform.position = touchedToSpawnPosition.position;
    }
}
