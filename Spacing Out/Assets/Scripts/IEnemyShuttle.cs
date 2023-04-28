using UnityEngine;

public interface IEnemyShuttle
{
    static float Speed;

    static Vector2 Velocity;

    static Vector2 Min, Max;
    static float MinFaultX, MaxFaultX;

    void MoveShip();
    
    void SetPosition();
}
