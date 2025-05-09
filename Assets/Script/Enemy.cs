using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxhp;
    public float hp;
    public float speed;
    public Rigidbody2D target;

    bool isLive = true;

    Rigidbody2D rigid;
    SpriteRenderer sprite;

    public void init()
    {
        
    }

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if(!isLive) return;
    

        Vector2 dirVec = target.position - rigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.linearVelocity = Vector2.zero;
    }

    void LateUpdate()
    {
        sprite.flipX = target.position.x < rigid.position.x;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag("Bullet")) return;

        hp -= collision.GetComponent<Bullet>().damage;

        if(hp > 0)
        {
            // Live, Hit Action
        }
        else
        {
            // .. die
            Dead();
        }
    }

    void Dead()
    {
        gameObject.SetActive(false);
    }
}
