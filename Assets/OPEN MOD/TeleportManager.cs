using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    public static TeleportManager Instance; // Instância única do manager
    private string lastScene; // Última cena visitada
    private Vector3 lastPlayerPosition; // Posição do jogador na última cena

    void Awake()
    {
        // Verifica se já existe uma instância do TeleportManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Mantém o TeleportManager entre as cenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Salva os dados de teleportação (última cena e posição do jogador)
    public void SaveTeleportData(string scene, Vector3 position)
    {
        lastScene = scene;
        lastPlayerPosition = position;
    }

    // Retorna os dados de teleportação salvos
    public (string, Vector3) GetTeleportData()
    {
        return (lastScene, lastPlayerPosition);
    }
}
