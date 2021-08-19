using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    

    void FixedUpdate()
    {
        TrackBall();
    }

    private void TrackBall()
    {
        Vector3 enemyPosX = new Vector3(transform.position.x, 0, 10);//enemy has constraint position in z axis and y, he can move only on x axis
        Vector3 ballPosx = new Vector3(GameManager.singleton.BallPrefab.position.x, 0, 10);// tracking ball position on x axis
        transform.position = Vector3.MoveTowards(enemyPosX, ballPosx, GameManager.singleton.EnemyMoveSpeed * Time.fixedDeltaTime + (GameManager.singleton.DifficultyLevel/10));
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager.singleton.BallPrefab.position = GameManager.singleton.BallStartingPos;
        GameManager.singleton.BallRigBody.velocity = Vector3.zero;
        GameManager.singleton.LaunchIndicator.gameObject.SetActive(true);
        GameManager.singleton.BallCaught = true;
    }
}
