using UnityEngine;

public class AlignHouse : MonoBehaviour
{
    // Distância de segurança para garantir que a casa não entre no terreno
    public float distanciaDeSeguranca = 0.1f;

    // Tamanho mínimo para evitar que o Raycast "penetre" em montanhas
    public float alturaMinima = 1.0f;

    void Start()
    {
        // Verificar se a casa não começa em uma posição muito baixa
        if (transform.position.y < 1f)
        {
            transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
        }
    }

    void Update()
    {
        // Alinhar a casa ao solo a cada frame
        AjustarCasaNoChao();
    }

    void AjustarCasaNoChao()
    {
        RaycastHit hit;

        // Dispara um raio para baixo a partir da posição da casa
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            // Verificar a altura do ponto de impacto antes de ajustar a casa
            if (hit.point.y >= alturaMinima)
            {
                // Ajusta a posição Y da casa para o ponto onde o raio bateu, com uma distância de segurança
                transform.position = new Vector3(transform.position.x, hit.point.y + distanciaDeSeguranca, transform.position.z);
            }
            else
            {
                // Se o ponto de impacto está abaixo do limite mínimo, a casa não é ajustada
                Debug.Log("Ponto de impacto muito baixo, mantendo a posição atual.");
            }
        }
    }
}
