using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject m_PrefabToSpawn;

    XRSocketInteractor m_SocketInteractor;

    const float k_Min = 0.05f;
    const float k_Max = 1.2f;

    void OnEnable()
    {
        m_SocketInteractor = GetComponent<XRSocketInteractor>();
        m_SocketInteractor.onSelectExit.AddListener(ObjectGrabbed);
    }

    void ObjectGrabbed(XRBaseInteractable interactable)
    {
        // object grabbed, spawn another one and set it's size to a random scale between k_Min and k_Max
        GameObject newSphere = Instantiate(m_PrefabToSpawn, transform.position, Quaternion.identity);
        newSphere.transform.localScale = GetRandomScale();

    }

    Vector3 GetRandomScale()
    {
        float val = UnityEngine.Random.Range(k_Min, k_Max);
        return new Vector3(val, val, val);
    }
}
