using UnityEngine;

[CreateAssetMenu(fileName = "VectorValue", menuName = "ScriptableObjects/VectorValue", order = 0)]
public class VectorValue : ScriptableObject
{
    public Vector2 initialValue;

    public VectorValue(Vector2 newPosition){
        this.initialValue = newPosition;
    }
}
