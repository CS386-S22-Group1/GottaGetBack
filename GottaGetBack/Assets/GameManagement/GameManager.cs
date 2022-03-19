using Unity.Netcode;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void OnGUI()
    {
        GUILayout.BeginArea( new Rect( 10, 10, 300, 300 ) );
        if ( !NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer )
        {
            StartButtons();
        }
        else
        {
            StatusLabels();
        }

        GUILayout.EndArea();
    }

    static void StartButtons()
    {
        if ( GUILayout.Button( "Host" ) ) NetworkManager.Singleton.StartHost();
        if ( GUILayout.Button( "Client" ) ) NetworkManager.Singleton.StartClient();
        if ( GUILayout.Button( "Server" ) ) NetworkManager.Singleton.StartServer();
    }

    static void StatusLabels()
    {
        var mode = NetworkManager.Singleton.IsHost ?
            "Host" : NetworkManager.Singleton.IsServer ? "Server" : "Client";

        GUILayout.Label( "Transport: " +
            NetworkManager.Singleton.NetworkConfig.NetworkTransport.GetType().Name );
        GUILayout.Label( "Mode: " + mode );
    }

    /*
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
    */
}
