using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    #region Variables and Properties

    [Header("Player")] 
    [SerializeField] private GameObject player;
    [SerializeField] private LayerMask playerLayer;
    public float movementSpeed;
    private Rigidbody2D _rb;

    [Header("Player Input")]
    //[SerializeField] private PlayerInputs playerInput;
    private LaserExtender ex;

    [Header("Obstacles")] 
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private LayerMask obstaclesLayer;
    #endregion

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        ex = GetComponent<LaserExtender>();
    }


    private void FixedUpdate()
    {
        Locomotion();
    }


    private void Locomotion()
    {
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        _rb.MovePosition(transform.position + m_Input * Time.deltaTime * movementSpeed);

        if (Input.GetKey(KeyCode.Space))
        {
            ShootLaser();
        }
    }

    private void ShootLaser()
    {
        ex.ShootLaser();
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Obsticle"))
        {
            _rb.velocity = Vector2.zero;
        }
    }
}
