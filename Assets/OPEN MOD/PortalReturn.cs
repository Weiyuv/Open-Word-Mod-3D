using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalReturn : MonoBehaviour
{
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
            TeleportPlayerBack();
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

    // Teleporta o jogador de volta à última cena e posição registrada
    void TeleportPlayerBack()
    {
        // Recupera os dados salvos no TeleportManager
        (string lastScene, Vector3 lastPosition) = TeleportManager.Instance.GetTeleportData();

        // Verifica se os dados estão corretos
        if (!string.IsNullOrEmpty(lastScene))
        {
            // Carrega a cena anterior
            SceneManager.LoadScene(lastScene);

            // Espera um quadro para garantir que a cena foi carregada
            Invoke("TeleportToSavedPosition", 0.1f);
        }
        else
        {
            Debug.LogWarning("Cena anterior não encontrada!");
        }
    }

    // Teleporta o jogador para a posição salva após a cena ser carregada
    void TeleportToSavedPosition()
    {
        (string lastScene, Vector3 lastPosition) = TeleportManager.Instance.GetTeleportData();

        // Move o jogador para a posição salva
        player.position = lastPosition;

        // Opcional: adicionar lógica para atualizar animações ou estados do jogador
        Debug.Log("Jogador teleportado para a posição: " + lastPosition);
    }
}
