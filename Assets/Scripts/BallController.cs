
using UnityEngine;

public class BallController : MonoBehaviour {

    public Rigidbody rb;
    public float impulseForce = 5f;

    private Vector3 startPos;
    private bool ignoreNextCollision;

    public int perfectPass = 0;
    public bool isSuperSpeedActive;


    private void Awake()
    {
        startPos = transform.position; // getting vball start position to use when restting level
    }



    private void OnCollisionEnter(Collision other)
    {
        if (ignoreNextCollision)
            return;
        if (isSuperSpeedActive)
        {
            if (!other.transform.GetComponent<Goal>())
            {
                Destroy(other.transform.gameObject,0.3f);
            }
        }
        else
        {
            //instance of class death part
            //also adding resetting level functionality when deathpart is hit
            DeathPart deathPart = other.transform.GetComponent<DeathPart>();
            if (deathPart) // if death part exists
                deathPart.HitDeathPart();
        }


        FindObjectOfType<AudioManager>().Play("PlayerHit");



        rb.velocity = Vector3.zero; // Remove velocity to not make the ball jump higher after falling done a greater distance
        rb.AddForce(Vector3.up * impulseForce, ForceMode.Impulse);

        ignoreNextCollision = true;
        Invoke("AllowCollision", 0.2f);

        perfectPass = 0;
        isSuperSpeedActive = false;
    }


    private void AllowCollision()
    {
        ignoreNextCollision = false;
    }


    public void ResetBall()
    {
        transform.position = startPos;
    }


    private void Update()
    {
        if(perfectPass >= 3 && !isSuperSpeedActive)
        {
            isSuperSpeedActive = true;
            rb.AddForce(Vector3.down * 20, ForceMode.Impulse);
        }
    }
}
