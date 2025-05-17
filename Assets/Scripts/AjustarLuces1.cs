using UnityEngine;
using UnityEngine.Rendering.Universal;

public class AjustarLuces1 : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public Light2D light1;
    public Light2D light2;

    public float maxDistance = 10f;

    [Header("Intensidad")]
    public float minIntensity = 0f;
    public float maxIntensity = 4f;

    [Header("Radio")]
    public float minRadius = 1f;
    public float maxRadius = 6f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(player1.position, player2.position);
        float t = Mathf.InverseLerp(0f, maxDistance, distance);
        float currentIntensity = Mathf.Lerp(maxIntensity, minIntensity, t);
        float currentRadius = Mathf.Lerp(maxRadius, minRadius, t);
        light1.intensity = currentIntensity;
        light2.intensity = currentIntensity;

        

    
    }
}
