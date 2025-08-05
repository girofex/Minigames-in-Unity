using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 8f;
    [SerializeField] float boostSpeed = 10f;
    [SerializeField] float baseSpeed = 5f;
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    bool canMove = true;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindAnyObjectByType<SurfaceEffector2D>();
    }

    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }

    void RespondToBoost()
    {
        if (Input.GetKey("up"))
            surfaceEffector2D.speed = boostSpeed;

        else
            surfaceEffector2D.speed = baseSpeed;
    }

    void RotatePlayer()
    {
        if (Input.GetKey("left"))
            rb2d.AddTorque(torqueAmount);

        else if (Input.GetKey("right"))
            rb2d.AddTorque(-torqueAmount);
    }
}
