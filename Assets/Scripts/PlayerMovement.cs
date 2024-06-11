using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {
    Rigidbody2D rb;
    Vector2 moveInput;
    public float moveSpeed;
    Animator animator;
    SpriteRenderer spriteRenderer;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMove(InputValue value) {
        moveInput = value.Get<Vector2>();

        // animation
        if (moveInput == Vector2.zero) {
            animator.SetBool("isWalking", false);
        }
        else {
            animator.SetBool("isWalking", true);
            if (moveInput.x > 0) {
                spriteRenderer.flipX = false;
            }
            if (moveInput.x < 0) {
                spriteRenderer.flipX = true;
            }

        }
    }

    private void FixedUpdate() {
        if (DialogManager.isActive == true) return;
        rb.AddForce(moveInput * moveSpeed);
    }
}
