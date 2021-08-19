using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestructionController : MonoBehaviour
{
    
    // when ball touches Destructuble object count of destruction increase, when count = 3 difficulty level rise
    private void OnTriggerEnter(Collider other)
    {
         gameObject.gameObject.SetActive(false);
                 GameManager.singleton.DestructionCount++;
        if(GameManager.singleton.DestructionCount%3==0)
        {
            GameManager.singleton.DestructionCount = 0;
            GameManager.singleton.DifficultyLevel++;
            GameManager.singleton.DestructionObstacle1.gameObject.SetActive(true);
            GameManager.singleton.DestructionObstacle2.gameObject.SetActive(true);
            GameManager.singleton.DestructionObstacle3.gameObject.SetActive(true);
            GameManager.singleton.ScoreLevel.text = GameManager.singleton.DifficultyLevel.ToString();
        }
        GameManager.singleton.BallPrefab.transform.position = GameManager.singleton.BallStartingPos;
        GameManager.singleton.BallRigBody.velocity = Vector3.zero;
        GameManager.singleton.LaunchIndicator.gameObject.SetActive(true);
        GameManager.singleton.BallCaught = true;
    }

}
