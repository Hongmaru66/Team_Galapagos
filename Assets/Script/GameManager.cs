using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PoolManager pool;
    public PlayerControl player;

    void Awake()
    {
        instance = this;
    }

}
