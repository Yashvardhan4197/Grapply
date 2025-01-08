
using System;
using UnityEngine;

public class PlayerView : MonoBehaviour
{

    private PlayerController playerController;
    private Transform grappledObjectTransform;
    private Vector2 currentDirection;
    [SerializeField] Animator playerAnimator;
    [SerializeField] Transform grappleGunTransform;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] LayerMask ignoreLayer;
    public void SetController(PlayerController playerController)
    {
        this.playerController = playerController;
    }

    private void Update()
    {
        if(playerController?.IsDead==false)
        {
            Vector3 mousePos= Input.mousePosition;
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0));
            playerController?.SetPlayerDirection(mouseWorldPos);
            Grapple(mouseWorldPos);
            if(playerController.IsGrappling==true&&grappledObjectTransform!=null)
            {
                UpdateLineRenderer();
            }
        }
    }

    private void UpdateLineRenderer()
    {
        lineRenderer.SetPosition(0,grappleGunTransform.position);
        lineRenderer.SetPosition(1,grappledObjectTransform.position);

        if((Vector2)(this.transform.position-lineRenderer.GetPosition(1)).normalized!=currentDirection)
        {
            playerController.EndGrapple(grappledObjectTransform);
        }
    }



    private void Grapple(Vector3 mouseWorldPos)
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray2D ray = new Ray2D();
            ray.origin = grappleGunTransform.position;
            ray.direction=((Vector2)mouseWorldPos-ray.origin).normalized;
            RaycastHit2D hit= Physics2D.Raycast(ray.origin,ray.direction,playerController.GrappleDistance,~ignoreLayer);
            if(hit.collider!=null)
            {
                
                grappledObjectTransform = hit.transform;
                playerController.SetIsGrapple(true);
                playerController.PullObject(grappledObjectTransform);

                lineRenderer.enabled = true;
                lineRenderer.SetPosition(0,ray.origin);
                currentDirection = ray.direction;
            }


        }
    }

    public Animator GetPlayerAnimator() => playerAnimator;
    public LineRenderer GetLineRenderer() => lineRenderer;  

}
