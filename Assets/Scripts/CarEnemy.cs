using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CarType { Slow, Normal, Fast, Boss }

public class CarEnemy : Enemy
{
    [SerializeField] private CarType carType;

    void Start()
    {
        switch(carType)
        {
            case CarType.Slow: 
                Speed = 3.0f;
                break;
            case CarType.Normal:
                Speed = 6.0f;
                break;
            case CarType.Fast:
                Speed = 9.0f;
                break;
            case CarType.Boss:
                Speed = 7.0f;
                break;
        }
    }
}
