using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    Rigidbody2D rigid;
    SpriteRenderer sprite;
    Animator animator;


   
    void Awake()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
    void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized * speed * Time.deltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }

    void LateUpdate()
    {
        animator.SetFloat("speed", inputVec.magnitude);

        if(inputVec.x != 0)
        {
            sprite.flipX = inputVec.x < 0;
        }
    }
}
