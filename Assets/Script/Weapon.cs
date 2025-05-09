using UnityEngine;

public class Weapon : MonoBehaviour
{
   public int id;
   public int prefabId;
   public float damage;
   public int count;
   public float speed;

   public void Init()
   {
        switch (id)
        {
            case 0:
                speed = -150;
                Batch();

                break;
            default:
                break;
        }
   }

   void Batch()
   {
        for(int i = 0; i < count;i++)
        {
            GameManager.instance.pool.Get();
        }
   }
}
