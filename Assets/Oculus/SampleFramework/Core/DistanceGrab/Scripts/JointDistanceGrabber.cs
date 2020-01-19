using UnityEngine;

namespace OculusSampleFramework
{
    public class JointDistanceGrabber : DistanceGrabber
    {
        private FixedJoint _fixedJoint;
        protected override void Start()
        {
            base.Start();
            _fixedJoint = GetComponent<FixedJoint>();
        }

        protected override void MoveGrabbedObject(Vector3 pos, Quaternion rot, bool forceTeleport = false)
        {
            if (m_grabbedObj == null)
            {
                return;
            }

            if (m_movingObjectToHand)
            {
                base.MoveGrabbedObject(pos, rot, forceTeleport);
            }
            else
            {
                if (_fixedJoint.connectedBody == null)
                {
                    _fixedJoint.connectedBody = m_grabbedObj.grabbedRigidbody;
                }
            }
        }

        protected override void GrabEnd()
        {
            _fixedJoint.connectedBody = null;
            base.GrabEnd();
        }
    }
}
