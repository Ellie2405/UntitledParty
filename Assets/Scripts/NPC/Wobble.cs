using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wobble : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] float wobbleSpeed = 0.1f;
    private void Awake()
    {
        rb2d.velocity = Random.insideUnitCircle * wobbleSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.rb2d.velocity = Random.insideUnitCircle * wobbleSpeed;
    }
}
