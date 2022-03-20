using Unity.Netcode;
using UnityEngine;

namespace GameManagement
{
    public class GameManager : NetworkBehaviour
    {
        /// <summary>
        ///     <para>
        ///         Identifies if the networkSpawner has been spawned
        ///     </para>
        /// </summary>
        private bool networkSpawnerIn = false;

        /// <summary>
        ///     <para>
        ///         NetworkObject component on the networkSpawner asset
        ///     </para>
        /// </summary>
        [SerializeField]
        private NetworkObject networkSpawner;

        private void Update()
        {
            if ( IsServer && !networkSpawnerIn )
            {
                NetworkObject netSpawnerInstance = Instantiate( networkSpawner, transform );

                netSpawnerInstance.Spawn();

                networkSpawnerIn = true;
            }
        }

        /* The code below is provided by the Unity Netcode "Building on 'Hello World'"
         * tutorial as an introduction to creating and displaying UI to the Host
         * and Clients
         * 
         * Link to that tutorial:
         * https://docs-multiplayer.unity3d.com/docs/tutorials/helloworld/helloworldtwo/index.html
         */
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
    }
}