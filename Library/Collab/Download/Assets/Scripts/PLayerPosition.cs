using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerPosition
{
    public static VectorValue position = null;


    public static Vector2 getPosition()
    {
        try
        {
            return position.initialValue;
        }
        catch (System.NullReferenceException e)
        {
            Debug.Log(e.GetType());
            return new Vector2(0.067f, -0.825f);
        }
    }

    public static void setPosition(VectorValue newPosition)
    {
        position = newPosition;
    }
}
