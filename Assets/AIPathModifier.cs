using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AIPathModifier : MonoBehaviour
{
    private AIPath aiPath;
    // Start is called before the first frame update
    void Start()
    {
        aiPath.canMove=false;
    }
}
