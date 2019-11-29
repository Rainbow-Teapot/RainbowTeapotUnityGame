// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SplineWalker.cs" company="Exit Games GmbH">
//   Part of: Photon Unity Networking Demos
// </copyright>
// <summary>
//  Original: http://catlikecoding.com/unity/tutorials/curves-and-splines/
//  Used in SlotRacer Demo
// </summary>
// <author>developer@exitgames.com</author>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine;

namespace Photon.Pun.Demo.SlotRacer.Utils
{
	[ExecuteInEditMode]
	public class SplineWalker : MonoBehaviour {

		public BezierSpline spline;

		public float Speed = 0f;

		public bool lookForward;

		public bool reverse;

		private float progress;

		public float currentDistance =0f;

		public float currentClampedDistance;

        public Vector3 networkPosition;
        public float velX;

        private PhotonView pv;

		public void SetPositionOnSpline(float position)
		{
			currentDistance = position;
			ExecutePositioning ();
		}

        private void Awake()
        {
            pv = GetComponent<PhotonView>();
        }

        void Update()
		{
			// update the distance used.
			currentDistance += Speed * Time.deltaTime;
			ExecutePositioning ();
		}

		public void ExecutePositioning()
		{
			if(spline==null)
			{
				return;
			}
			// move the transform to the new point
			Vector3 bezierPosition = spline.GetPositionAtDistance(currentDistance,this.reverse);

            if (pv.IsMine)
            {
                transform.position = new Vector3(transform.position.x + velX,transform.position.y, bezierPosition.z);
            }
            else
            {
                Vector3 realPosition = Vector3.Lerp(transform.position, networkPosition, 0.1f);
                transform.position = new Vector3(realPosition.x, transform.position.y, bezierPosition.z);
            }
			// update the distance used.
			currentDistance += Speed * Time.deltaTime;


			if (lookForward) {
				transform.LookAt(spline.GetPositionAtDistance(currentDistance+1,this.reverse));
			}
		}
	}	
}