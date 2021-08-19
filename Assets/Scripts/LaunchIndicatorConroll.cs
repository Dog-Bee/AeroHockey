using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchIndicatorConroll : MonoBehaviour
{
    public Transform Player;
    public Transform Ball;
    private Vector3 indicatorDirection;

    // Update is called once per frame
    void Update()
    {
        indicatorDirection = Vector3.Normalize(Player.position - Ball.position);
        transform.rotation = Quaternion.LookRotation(indicatorDirection);
    }
}
