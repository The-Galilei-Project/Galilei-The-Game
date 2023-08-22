using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player current;

    private void Awake()
    {
        if (current != null && current != this)
            Destroy(this.gameObject);
        else
        {
            current = this;
        }
    }

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        CameraMotor.lookAt = this.transform;
    }

    public void ChangePosition(){
        this.transform.position = PlayerState.getPosition();
    }

    public void ChangePosition(Vector2 newPosition){
        PlayerState.setPosition(new VectorValue(newPosition));
        this.transform.position = newPosition;
    }

    public void ChangePosition(VectorValue newPosition){
        PlayerState.setPosition(newPosition);
        this.transform.position = newPosition.initialValue;
    }
}
