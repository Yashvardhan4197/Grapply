
using System;
using UnityEngine;

public class PlayerController
{
    private PlayerView playerView;
    private bool isDead;
    private float grappleDistance;
    private float grappleSpeed;
    private bool isGrappling;
    private Animator playerAnimator;
    public bool IsDead {  get { return isDead; } }
    public float GrappleDistance {  get { return grappleDistance; } }
    public bool IsGrappling { get { return isGrappling; } }
    public PlayerController(PlayerView playerView)
    {
        this.playerView = playerView;
        this.playerView.SetController(this);
        playerAnimator = playerView.GetPlayerAnimator();
        grappleDistance = 10f;
        grappleSpeed = 5f;
    }

    public void OnGameStart()
    {
        SetPlayerAliveStatus(true);
    }


    public void SetPlayerDirection(Vector3 mouseWorldPos)
    {
        Vector3 direction=(mouseWorldPos-playerView.transform.position).normalized;
        playerAnimator.SetFloat("x", direction.x);
        playerAnimator.SetFloat ("y", direction.y);
    }

    public void SetPlayerAliveStatus(bool isAlive)
    {
        if(isAlive)
        {
            isDead=false;
            
        }
        else
        {
            isDead = true;
        }
        playerAnimator.SetBool("isDead", isDead);
    }



    public void SetIsGrapple(bool isGrapple)
    {
        isGrappling = isGrapple;
    }


    public void PullObject(Transform target)
    {
        Rigidbody2D rb2D = target.GetComponent<Rigidbody2D>();
        if(rb2D!=null)
        {
            Debug.Log("hit");
            rb2D.velocity = (playerView.transform.position - target.position).normalized * grappleSpeed;
        }
    }
    public void EndGrapple(Transform grappledObjectTransform)
    {
        //playerView.GetLineRenderer().enabled = false;
        SetIsGrapple(false);
        grappledObjectTransform = null;
    }
}
