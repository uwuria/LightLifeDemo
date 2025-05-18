 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.Rendering.Universal;

public class PlayerLightManager : MonoBehaviour
{
    [Header("Parámetros de luz dinámica")]
    public float maxConnectionDistance = 10f;
    public float minIntensity = 0.2f;
    public float maxIntensity = 1f;
    public float minRadius = 1f;
    public float maxRadius = 5f;
    [Header("Parámetros de aislamiento")]
    public float safeLightRadius = 5f;
    public LayerMask obstructionMask;
    [Header("Referencias del jugador")]
    public Light2D playerLight;
    public PlayerMovement movementScript;
    public List<Transform> safeLightSources;
    private bool isIsolated = false;
    private static List<PlayerLightManager> allPlayers;

    void Awake()
    {
        if (allPlayers == null)
            allPlayers = new List<PlayerLightManager>();
            allPlayers.Add(this);
    }

    void OnDestroy()
    {
        allPlayers.Remove(this);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float closestDistance = float.MaxValue;
        bool isConnected = false;
        foreach (var other in allPlayers)
        {
            if (other == this) continue;
            float distance = Vector2.Distance(transform.position, other.transform.position);
            if (distance < closestDistance)
                closestDistance = distance;
            if (distance <= maxConnectionDistance)
            {
                Vector2 dir = (other.transform.position - transform.position).normalized;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, distance, obstructionMask);
                if (!hit)
                {
                    isConnected = true;
                    break;
                }
            }
        }
        // Verificar salvaguardas
        if (!isConnected)
        {
            foreach (Transform source in safeLightSources)
            {
                if (Vector2.Distance(transform.position, source.position) <= safeLightRadius)
                {
                    isConnected = true;
                    break;
                }
            }
        }
        // Cambiar estado de aislamiento
        if (isConnected && isIsolated)
        {
            movementScript.enabled = true;
            playerLight.enabled = true;
            isIsolated = false;
        }
        else if (!isConnected && !isIsolated)
        {
            movementScript.enabled = false;
            playerLight.enabled = false;
            isIsolated = true;

            //Detener físicamente al jugador
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {

                rb.velocity = Vector2.zero;
                rb.angularVelocity = 0f;
            }
        }
        // Calcular efecto visual por distancia (aunque esté aislado)

        float t = Mathf.InverseLerp(0f, maxConnectionDistance, closestDistance);
        float currentIntensity = Mathf.Lerp(maxIntensity, minIntensity, t);
        playerLight.intensity = currentIntensity;






    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        foreach (Transform lightSource in safeLightSources)
        {
            Gizmos.DrawWireSphere(lightSource.position, safeLightRadius);

            //a
        }
    }
}
