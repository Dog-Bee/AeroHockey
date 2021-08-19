using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform Player;

    private Touch screenTouch;

    public Transform launchIndicator;

    void Update()
    {
        if (GameManager.singleton.InGame)
        {
            DragPlayer();
            LaunchBall();
        }
    }
    private void LateUpdate()
    {
        ConstraintPosition(gameObject);
    }

    private void DragPlayer()
    {
        
        Transform draggingObject = transform;

        Plane plane = new Plane(Vector3.up, Vector3.zero);

        if (Input.touchCount > 0)
        {
            screenTouch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(screenTouch.position);

            float distance;
            if (plane.Raycast(ray, out distance))
            {
                draggingObject.position = ray.GetPoint(distance);
            }

        }
    }

    private Vector3 ConstraintPosition(GameObject goCharacter)
    {

        Vector3 goCharacterOldPos = goCharacter.transform.position;
        float sideEdgeDistance = GameManager.singleton.SideEdgeDistance;
        float topEdgeDistance = GameManager.singleton.TopBotEdgeDistance;
        float topBotCenterDistance = GameManager.singleton.TopBotCenterDistance;
        goCharacterOldPos.x = Mathf.Clamp(transform.position.x, -sideEdgeDistance, sideEdgeDistance);
        goCharacterOldPos.z = Mathf.Clamp(transform.position.z, -topEdgeDistance, topBotCenterDistance);
        return goCharacter.transform.position = goCharacterOldPos;

    }

    private void LaunchBall()
    {

        if (Input.touchCount > 0 && GameManager.singleton.BallCaught == true)
        {
            GameManager.singleton.BallSpeed = Vector3.Distance(GameManager.singleton.BallPrefab.transform.position, Player.transform.position);
            GameManager.singleton.BallSpeed = Mathf.Clamp(GameManager.singleton.BallSpeed, 16, 48);// 16 and 48 constraint of ballSpeed
            launchIndicator.localScale = new Vector3(1, 1, GameManager.singleton.BallSpeed / 8); //8 needs just for normal view of scaling, it fully division on 16 and 48
            if (screenTouch.phase == TouchPhase.Ended)
            {
                GameManager.singleton.BallRigBody.velocity = Vector3.Normalize(transform.position - GameManager.singleton.BallPrefab.transform.position) * GameManager.singleton.BallSpeed;
                GameManager.singleton.LaunchIndicator.gameObject.SetActive(false);
                GameManager.singleton.BallCaught = false;
            }
        }

    }
}
