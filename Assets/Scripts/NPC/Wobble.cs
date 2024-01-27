using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wobble : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] public float wobbleSpeed = 0.1f;
    bool CanMOve= true;
    private void Awake()
    {
        rb2d.velocity = Random.insideUnitCircle * wobbleSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(CanMOve)
        this.rb2d.velocity = Random.insideUnitCircle * wobbleSpeed;
    }

    public void StopMove ()
    {
        CanMOve = false;
        rb2d.velocity = Vector2.zero;
    }

    public void ResumeMove()
    {
        CanMOve = true;
        rb2d.velocity = Random.insideUnitCircle * wobbleSpeed;
    }
}
