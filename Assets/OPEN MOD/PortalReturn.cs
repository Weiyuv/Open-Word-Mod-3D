using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalReturn : MonoBehaviour
{
    private bool playerInRange = false; // Verifica se o jogador est� dentro do alcance do portal
    private Transform player; // Refer�ncia ao jogador

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

    // Teleporta o jogador de volta � �ltima cena e posi��o registrada
    void TeleportPlayerBack()
    {
        // Recupera os dados salvos no TeleportManager
        (string lastScene, Vector3 lastPosition) = TeleportManager.Instance.GetTeleportData();

        // Verifica se os dados est�o corretos
        if (!string.IsNullOrEmpty(lastScene))
        {
            // Carrega a cena anterior
            SceneManager.LoadScene(lastScene);

            // Espera um quadro para garantir que a cena foi carregada
            Invoke("TeleportToSavedPosition", 0.1f);
        }
        else
        {
            Debug.LogWarning("Cena anterior n�o encontrada!");
        }
    }

    // Teleporta o jogador para a posi��o salva ap�s a cena ser carregada
    void TeleportToSavedPosition()
    {
        (string lastScene, Vector3 lastPosition) = TeleportManager.Instance.GetTeleportData();

        // Move o jogador para a posi��o salva
        player.position = lastPosition;

        // Opcional: adicionar l�gica para atualizar anima��es ou estados do jogador
        Debug.Log("Jogador teleportado para a posi��o: " + lastPosition);
    }
}
