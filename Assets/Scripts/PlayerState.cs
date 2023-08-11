using UnityEngine;

public static class PlayerState
{
    public static VectorValue position = null;
    public static float speed = 1;
    public static string name = null;


    public static Vector2 getPosition()
    {
        return position == null ? new Vector2(0.067f, -0.825f) : position.initialValue;
    }

    public static void setPosition(VectorValue newPosition)
    {
        position = newPosition;
    }
}
