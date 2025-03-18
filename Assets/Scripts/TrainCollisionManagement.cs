using UnityEngine;

public class IgnoreSplineCollision : MonoBehaviour
{
    void Start()
    {
        int splineLayer = LayerMask.NameToLayer("Spline");
        int trainLayer = LayerMask.NameToLayer("Train");

        // Ignore collision between Train and Spline
        Physics.IgnoreLayerCollision(trainLayer, splineLayer, true);
    }
}
