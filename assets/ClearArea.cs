using UnityEngine;
using System.Collections.Generic;

public class RemoveVegetation : MonoBehaviour
{
    [Range(0f, 100f)]
    public float radius = 10f; // The radius of the area to remove vegetation from

    void Start()
    {
        Collider[] vegetationColliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider collider in vegetationColliders)
        {
            MeshCollider meshCollider = collider.GetComponent<MeshCollider>();
            StaticPhysics staticPhysics = collider.GetComponent<StaticPhysics>();

            if (meshCollider != null && staticPhysics != null)
            {
                Destroy(collider.gameObject);
            }
        }
    }
}
