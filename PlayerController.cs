using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour

{
    public string inputID;
    public Camera mainCamera;
    public Camera hoodCamera;
    public KeyCode switchKey;
   [SerializeField] float speed ;
   [SerializeField] private float horsePower = 0;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;

    [SerializeField] TextMeshProUGUI speedometerText;
   

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void FixedUpdate()
       { // Axis setup
        horizontalInput = Input.GetAxis("Horizontal" + inputID);
        forwardInput = Input.GetAxis("Vertical" + inputID);

        // Move the vehicle forward
        // transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);


        // Rotate the vehicle left and right
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
       
        speed = Mathf.Round(playerRb.velocity.magnitude * 2.237f);
        speedometerText.SetText("Speed:" + speed + "mph");



        
        if (Input.GetKeyDown(switchKey))
        {
            mainCamera.enabled = !mainCamera.enabled; 
            hoodCamera.enabled = !hoodCamera.enabled;
        }



    }

}
