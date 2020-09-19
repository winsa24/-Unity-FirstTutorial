using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform checkGroundTransform;
    [SerializeField] private LayerMask playerMask;
    private bool jumpKeyPressDown;
    private float horizontalInput;
    private int countJump = 0;
    private int superJump;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyPressDown = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {

        GetComponent<Rigidbody>().velocity = new Vector3(horizontalInput * 2, GetComponent<Rigidbody>().velocity.y, 0);

        if (Physics.OverlapSphere(checkGroundTransform.position, 0.1f, playerMask).Length == 0)
        {

            return;
        }

        if (jumpKeyPressDown)
        {
            if (superJump > 0)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * 10, ForceMode.VelocityChange);
                superJump--;
            }
            else
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * 7, ForceMode.VelocityChange);
            }


            jumpKeyPressDown = false;
            countJump++;
            Debug.Log(countJump);
        }


        //if (countJump < 2)
        //{
            
            
        //}
        //else
        //{
        //    countJump = 0;
        //}

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 9)
        {
            Destroy(other.gameObject);
            superJump++;
        }
    }

}
