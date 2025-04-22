using UnityEngine;

public class AlignHouse : MonoBehaviour
{
    // Dist�ncia de seguran�a para garantir que a casa n�o entre no terreno
    public float distanciaDeSeguranca = 0.1f;

    // Tamanho m�nimo para evitar que o Raycast "penetre" em montanhas
    public float alturaMinima = 1.0f;

    void Start()
    {
        // Verificar se a casa n�o come�a em uma posi��o muito baixa
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

        // Dispara um raio para baixo a partir da posi��o da casa
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            // Verificar a altura do ponto de impacto antes de ajustar a casa
            if (hit.point.y >= alturaMinima)
            {
                // Ajusta a posi��o Y da casa para o ponto onde o raio bateu, com uma dist�ncia de seguran�a
                transform.position = new Vector3(transform.position.x, hit.point.y + distanciaDeSeguranca, transform.position.z);
            }
            else
            {
                // Se o ponto de impacto est� abaixo do limite m�nimo, a casa n�o � ajustada
                Debug.Log("Ponto de impacto muito baixo, mantendo a posi��o atual.");
            }
        }
    }
}
