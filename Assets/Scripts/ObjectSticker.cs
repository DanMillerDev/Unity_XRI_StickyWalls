using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectSticker : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    XRGrabInteractable m_GrabInteractable;
    const string k_StickyWallTag = "StickyWall";

    void OnEnable()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_GrabInteractable = GetComponent<XRGrabInteractable>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(k_StickyWallTag))
        {
            m_Rigidbody.isKinematic = true;
            Destroy(m_GrabInteractable);
        }
    }
}
