using UnityEngine;
using UnityEngine.Rendering;

public class DistanceChanger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Camera _camera;
    public float modifier;
    public float maxDistance;
    public float minRateAmount;
    public float maxParticleSpeed;
    void Start()
    {
        _camera = FindFirstObjectByType<Camera>();
    }

    void Update()
    {
        modifier = Mathf.Clamp01((DistanceChecker(this.gameObject.transform, _camera.transform))/maxDistance);
        var emissionValue = this.gameObject.GetComponent<ParticleSystem>().emission;
        emissionValue.rateOverTime = Mathf.Clamp((minRateAmount/Mathf.Pow(modifier,4)), minRateAmount, 7500);
        var velocityValue = this.gameObject.GetComponent<ParticleSystem>().velocityOverLifetime;
        velocityValue.speedModifier = maxParticleSpeed/modifier;


    }

    float DistanceChecker(Transform object1, Transform object2)
    {

        return Vector3.Distance(object1.position, object2.position);
    }
}
