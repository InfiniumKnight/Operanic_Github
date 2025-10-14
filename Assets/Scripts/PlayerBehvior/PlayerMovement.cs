using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement and GameObjects")]
    [SerializeField] private float playerSpeed = 5.0f;
    private float dashSpeed = 20.0f;
    private float jumpHeight = 3f;
    private float gravityValue = -9.81f;

    private CharacterController controller;
    private PlayerInput playerInput;
    private Vector3 playerVelocity;
    public Vector3 move;
    private bool groundedPlayer;
    private InputActionAsset asset;
    [SerializeField] private GameObject PunchHitBox;
    public float dashCooldown = 0f;
    public float dashTime = .08f;

    public Vector3 RespawnCoords;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip JumpSound;
    [SerializeField] private AudioClip PunchSound;
    [SerializeField] private AudioClip DashSound;
    [SerializeField] private AudioClip HurtSound;
    [SerializeField] private float Volume = 50;

    private void Start()
    {
        PunchHitBox.SetActive(false);
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();

        audioSource = GetComponent<AudioSource>();
        audioSource.volume = Volume;

        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;

        // Read input
        Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();
        move = new Vector3(input.x, 0, input.y);
        move = Vector3.ClampMagnitude(move, 1f);
        controller.Move(move * Time.deltaTime * playerSpeed);

        // Jump
        if (playerInput.actions["Jump"].triggered && groundedPlayer)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            audioSource.PlayOneShot(JumpSound);
        }

        if (playerInput.actions["Dash"].triggered && dashCooldown <= 0f)
        {
            StartCoroutine(Dash());
        }
        else if (dashCooldown > 0f)
        {
            dashCooldown -= Time.deltaTime;
        }

        // Apply gravity
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if (input != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0, targetAngle, 0);
            transform.rotation = rotation;
        }

        if (playerInput.actions["Punch"].triggered && PunchHitBox.activeInHierarchy == false)
        {
            Punch();
        }

    }

    public void Punch()
    {
        PunchHitBox.SetActive(true);
        audioSource.PlayOneShot(PunchSound);
        //Debug.Log("Punching");
        StartCoroutine(Delay());
        
    }

    IEnumerator Dash()
    {
        float startTime = Time.time;
        audioSource.PlayOneShot(DashSound);

        while (Time.time < startTime + dashTime)
        {
            controller.Move(move * Time.deltaTime * dashSpeed);
            
            dashCooldown = 1.5f;

            yield return null;
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSecondsRealtime(.5f);
        PunchHitBox.SetActive(false);
    }

    public void Respawn()
    {
        audioSource.PlayOneShot(HurtSound);
        Debug.Log("Respawn Called");
        controller.enabled = false;
        gameObject.transform.position = RespawnCoords;
        controller.enabled = true;
    }
}
