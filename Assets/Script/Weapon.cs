using UnityEngine;

public class Weapon : MonoBehaviour
{
   public int id;
   public int prefabId;
   public float damage;
   public int count;
   public float speed;
   float timer;
   PlayerControl player;
   
    private void Awake() {
        player = GetComponentInParent<PlayerControl>();
   }

   void Start ()
   {   
        Init();
   }

    void Update ()
    {
        switch (id)
        {
            case 0:
                transform.Rotate(Vector3.back * speed * Time.deltaTime);
                break;
            case 1:
                
            default:
                timer += Time.deltaTime;

                if(timer > speed) {
                    timer = 0;
                    Fire();
                }
                break;
        }

        //.. Test code..
        if(Input.GetButtonDown("Jump"))
        {
            count++;
            damage++;
            Levelup(damage, count);
        }
    }

    public void Levelup(float damage, int count)
    {
        this.damage = damage;
        this.count = count;

        if(id == 0) Batch();
    }

   public void Init()
   {
        switch (id)
        {
            case 0:
                speed = 150;
                Batch();
                break;
            case 1:
                speed = 1f;
                
                break;
            default:
                break;
        }
   }

   void Batch()
   {
        for(int i = 0; i < count;i++)
        {
            Transform bullet;

            if(i < transform.childCount) {
                bullet = transform.GetChild(i);
            }
            else
            {
                bullet = GameManager.instance.pool.Get(prefabId).transform;
                bullet.parent = transform;
            }
           

            bullet.localPosition = Vector3.zero;
            bullet.localRotation = Quaternion.identity;

            Vector3 rotVec = Vector3.forward * 360 * i / count;
            bullet.Rotate(rotVec);
            bullet.Translate(bullet.up * 1.5f, Space.World);
            bullet.GetComponent<Bullet>().Init(damage, -1, Vector3.zero); // -1 is Infinity Per.
        }
   }

   void Fire()
   {
        if(!player.scaner.nearestTarget) return;

        Vector3 targetPos = player.scaner.nearestTarget.position;
        Vector3 dir = targetPos - transform.position;
        dir = dir.normalized;

        Transform bullet = GameManager.instance.pool.Get(prefabId).transform;
        bullet.position = transform.position;
        bullet.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        bullet.GetComponent<Bullet>().Init(damage, count, dir);


   }
}
