using UnityEngine;

public class BossScript : MonoBehaviour
{

    [SerializeField]
    protected float Speed = 1f;

    [SerializeField]
    protected float attackDelay = 5f;

    [SerializeField]
    private float movementDelay = 1f;

    [SerializeField]
    protected Vector2 Velocity = new Vector2(0, 0);

    [SerializeField]
    protected Vector2 Min, Max;

    protected GameController gameController;

    [SerializeField]
    protected int scoreValue = 500;

    protected float lastSetPos;

    protected virtual void MoveShipProtected()
    {
        float newX = transform.position.x + (Velocity.x * Speed * Time.deltaTime);
        float newY = transform.position.y + (Velocity.y * Speed * Time.deltaTime);
        newX = Mathf.Clamp(newX, Min.x, Max.x);
        newY = Mathf.Clamp(newY, Min.y, Max.y);
        transform.position = new Vector2(newX, newY); 
    }


    protected virtual void SetPositionProtected()
    {
        float newX = Random.Range(-1f,1f);
        float newY = Random.Range(-1f, 1f); 
        Velocity.x = newX;
        Velocity.y = newY;
        lastSetPos = Time.time;
    }

    protected bool IsReadyForSetPos()
    {
        return Time.time >= (lastSetPos + movementDelay);
    }

    public void MoveShip()
    {
        MoveShipProtected();
    }

    public void SetPosition()
    {
        SetPositionProtected();
    }

    public void SetController(GameController controller)
    {
        gameController = controller;
    }

}
