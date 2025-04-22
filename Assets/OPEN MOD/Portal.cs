using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string sceneToLoad; // Nome da cena para onde o jogador será teleportado
    public float activationDistance = 5f; // Distância de ativação do portal
    private bool playerInRange = false; // Verifica se o jogador está dentro do alcance do portal
    private Transform player; // Referência ao jogador

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            TeleportPlayer();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    // Salva a cena e a posição do jogador antes de teleportar
    void TeleportPlayer()
    {
        // Salva a cena atual e a posição do jogador no TeleportManager
        TeleportManager.Instance.SaveTeleportData(SceneManager.GetActiveScene().name, player.position);

        // Teleporta o jogador para a nova cena
        SceneManager.LoadScene(sceneToLoad);
    }
}
