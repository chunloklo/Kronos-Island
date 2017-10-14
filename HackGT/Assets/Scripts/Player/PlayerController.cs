using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //void Update()
    //{
    //    var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
    //    var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

    //    transform.Rotate(0, x, 0);
    //    transform.Translate(0, 0, z);
    //}

    public float walkSpeed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float runSpeed = 8.0F;
    public float gravity = 20.0F;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private PlayerFireController fireController;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        fireController = gameObject.GetComponentInChildren<PlayerFireController>();
    }

    void Update()
    {
        float timeScale = GameObject.Find("TimeManager").GetComponent<TimeManager>().timeScale;
        if (controller.isGrounded)
        {
            
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= walkSpeed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }
        moveDirection.y -= gravity * Time.deltaTime * timeScale;
        controller.Move(moveDirection * Time.deltaTime * timeScale);

        //attack
        if (Input.GetMouseButtonDown(0)) {
            fireController.Fire();
        }

    }
}