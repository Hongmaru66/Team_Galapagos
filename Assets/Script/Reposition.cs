using UnityEngine;

public class Reposition : MonoBehaviour
{
    Collider2D col;

    void Awake()
    {
        col = GetComponent<Collider2D>();
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area")) return;

        Vector2 PlayerPos = GameManager.instance.player.transform.position;
        Vector2 myPos = transform.position;

        float diffX = Mathf.Abs(PlayerPos.x - myPos.x);
        float diffY = Mathf.Abs(PlayerPos.y - myPos.y);

        Vector3 playerDir = GameManager.instance.player.inputVec;
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;

        switch (transform.tag)
        {
            case "Ground":
                if (diffX > diffY)
                {
                    transform.Translate(Vector2.right * dirX * 20 * 2);
                }
                else if (diffX < diffY)
                {
                    transform.Translate(Vector2.up * dirY * 20 * 2);
                }
                break;
            case "Enemy":
                if(col.enabled)
                {
                    transform.Translate(playerDir * 20 + new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0f));
                }
            
                
                break;   
        }

    }

}
