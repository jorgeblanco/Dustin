using UnityEngine;

namespace OculusSampleFramework
{
    public class JointDistanceGrabbable : DistanceGrabbable
    {
        public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
        {
            m_grabbedBy = hand;
            m_grabbedCollider = grabPoint;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
