using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerControl player;

    void Awake()
    {
        instance = this;
    }

}
