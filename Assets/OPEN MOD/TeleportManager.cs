using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    public static TeleportManager Instance; // Inst�ncia �nica do manager
    private string lastScene; // �ltima cena visitada
    private Vector3 lastPlayerPosition; // Posi��o do jogador na �ltima cena

    void Awake()
    {
        // Verifica se j� existe uma inst�ncia do TeleportManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Mant�m o TeleportManager entre as cenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Salva os dados de teleporta��o (�ltima cena e posi��o do jogador)
    public void SaveTeleportData(string scene, Vector3 position)
    {
        lastScene = scene;
        lastPlayerPosition = position;
    }

    // Retorna os dados de teleporta��o salvos
    public (string, Vector3) GetTeleportData()
    {
        return (lastScene, lastPlayerPosition);
    }
}
