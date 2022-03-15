using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header( "MANAGER ACCESS" )]

    public static GameManager managerInstance;


    [Header( "MENUS" )]

    [SerializeField]
    private GameObject respawnMenu;


    private void Awake()
    {
        managerInstance = this;
    }

    public void RespawnMenuOn()
    {
        respawnMenu.SetActive( true );
    }
}
