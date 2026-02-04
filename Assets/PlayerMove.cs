using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float gravity = -20f;
    public float jumpForce = 8f;
    public bool debug = true;

    CharacterController cc;
    Vector3 velocity;
    bool wasGrounded;

    void Awake()
    {
        cc = GetComponent<CharacterController>();
        gameObject.tag = "Player";
    }

    void DLog(string msg)
    {
        if (debug) Debug.Log(msg);
    }

    void Update()
    {
        // Toggle debug
        if (Input.GetKeyDown(KeyCode.F3))
        {
            debug = !debug;
            Debug.Log("DEBUG: " + (debug ? "ON" : "OFF"));
        }

        float x =
            (Input.GetKey(KeyCode.D) ? 1f : 0f) -
            (Input.GetKey(KeyCode.A) ? 1f : 0f);

        float z =
            (Input.GetKey(KeyCode.W) ? 1f : 0f) -
            (Input.GetKey(KeyCode.S) ? 1f : 0f);

        if (debug && (x != 0f || z != 0f))
            DLog($"Move → x:{x} z:{z}");

        Vector3 move = (transform.right * x + transform.forward * z).normalized;
        cc.Move(move * moveSpeed * Time.deltaTime);

        // Jump
        // if (cc.isGrounded)
        {
            if (velocity.y < 0f)
                velocity.y = -2f;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocity.y = jumpForce;
                DLog("Jump!");
            }
        }

        // Gravity
        velocity.y += gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);

        // Grounded state change
        if (cc.isGrounded != wasGrounded)
        {
            DLog("Grounded: " + cc.isGrounded);
            wasGrounded = cc.isGrounded;
        }
    }
}
