using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerFootstepManager : MonoBehaviour
{
    public AudioSource PlayerSource;

    public AudioClip GrassClip;
    public AudioClip PathClip;
    public AudioClip ConClip;
    public AudioClip LeafClip;

    RaycastHit hit;

    public Transform FootRay;
    public float FootRaySize;
    public LayerMask GroundLayer;

    public void Steps()
    {
        if(Physics.Raycast(FootRay.position, FootRay.transform.up * -1, out hit, FootRaySize, GroundLayer))
        {
            if (hit.collider.CompareTag("Grass")) PlayFootSound(GrassClip);
            if (hit.collider.CompareTag("Path")) PlayFootSound(PathClip);
            if (hit.collider.CompareTag("Concrete")) PlayFootSound(ConClip);
            if (hit.collider.CompareTag("Leaves")) PlayFootSound(LeafClip);
        }
    }

    public void PlayFootSound(AudioClip GroundClip)
    {
        PlayerSource.pitch = Random.Range(0.9f, 1.0f);
        PlayerSource.PlayOneShot(GroundClip);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(FootRay.position, FootRay.transform.up * -1 * FootRaySize);
    }
}
