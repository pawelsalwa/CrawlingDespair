using UnityEngine;

namespace Character
{
	public class IkMotionMocker : MonoBehaviour
	{
		// public Action<IkMotionMocker> NotifyOnIkMotionStarted;
		// public Action<IkMotionMocker> NotifyOnIkMotionFinished;
		//
		// #region Variables
		//
		// public HumanoidBaker Baker;
		// public FullBodyBipedIK BodyIk;
		// public bool BakeAnimation = false;
		//
		// [SerializeField]
		// private FullBodyBipedEffector ikType = FullBodyBipedEffector.Body;
		//
		// [SerializeField]
		// private Transform pullTarget = null;
		//
		// [SerializeField]
		// private AnimationCurve animCurve = null;
		//
		// [SerializeField]
		// [Range(0.1f, 5f)]
		// public float totalDuration = 0f;
		//
		// private float progress;
		// private bool shouldUpdate;
		//
		// public Vector3 TargetsPos
		// {
		// 	set => pullTarget.position = value;
		// }
		//
		// #endregion
		//
		// #region MonoBehaviours
		//
		// public void Update()
		// {
		// 	if (shouldUpdate)
		// 	{
		// 		if (progress >= totalDuration)
		// 		{
		// 			shouldUpdate = false;
		//
		// 			if (NotifyOnIkMotionFinished != null)
		// 			{
		// 				NotifyOnIkMotionFinished.Invoke(this);
		// 			}
		// 			else
		// 			{
		// 				if (BakeAnimation)
		// 				{
		// 					Baker.StopBaking();
		// 				}
		// 			}
		// 			return;
		// 		}
		//
		// 		SetProgress((progress += Time.deltaTime) / totalDuration);
		// 	}
		// }
		//
		// #endregion
		//
		// #region IkMotion
		//
		// public void PlayIkMotion()
		// {
		// 	UpdateEffectorTarget();
		//
		// 	progress = 0f;
		// 	shouldUpdate = true;
		// }
		//
		// public void PlayIkMotionFromInspector()
		// {
		// 	UpdateEffectorTarget();
		//
		// 	if (NotifyOnIkMotionStarted != null)
		// 	{
		// 		NotifyOnIkMotionStarted.Invoke(this);
		// 	}
		// 	else
		// 	{
		// 		if (BakeAnimation)
		// 		{
		// 			Baker.StartBaking();
		// 		}
		// 	}
		//
		//
		// 	progress = 0f;
		// 	shouldUpdate = true;
		// }
		//
		// #endregion
		//
		// #region Setting Effector Targets and Progress
		//
		// private void UpdateEffectorTarget()
		// {
		// 	switch (ikType)
		// 	{
		// 		case FullBodyBipedEffector.Body:
		// 			{
		// 				BodyIk.solver.bodyEffector.target = pullTarget;
		// 				break;
		// 			}
		//
		// 		case FullBodyBipedEffector.LeftHand:
		// 			{
		// 				BodyIk.solver.leftHandEffector.target = pullTarget;
		// 				break;
		// 			}
		//
		// 		case FullBodyBipedEffector.RightHand:
		// 			{
		// 				BodyIk.solver.rightHandEffector.target = pullTarget;
		// 				break;
		// 			}
		//
		// 		case FullBodyBipedEffector.LeftShoulder:
		// 			{
		// 				BodyIk.solver.leftShoulderEffector.target = pullTarget;
		// 				break;
		// 			}
		//
		// 		case FullBodyBipedEffector.RightShoulder:
		// 			{
		// 				BodyIk.solver.rightShoulderEffector.target = pullTarget;
		// 				break;
		// 			}
		//
		// 		case FullBodyBipedEffector.LeftThigh:
		// 			{
		// 				BodyIk.solver.leftThighEffector.target = pullTarget;
		// 				break;
		// 			}
		//
		// 		case FullBodyBipedEffector.RightThigh:
		// 			{
		// 				BodyIk.solver.rightThighEffector.target = pullTarget;
		// 				break;
		// 			}
		//
		// 		case FullBodyBipedEffector.LeftFoot:
		// 			{
		// 				BodyIk.solver.leftFootEffector.target = pullTarget;
		// 				break;
		// 			}
		//
		// 		case FullBodyBipedEffector.RightFoot:
		// 			{
		// 				BodyIk.solver.rightFootEffector.target = pullTarget;
		// 				break;
		// 			}
		//
		// 		default:
		// 			{
		// 				throw new ArgumentOutOfRangeException();
		// 			}
		// 	}
		// }
		//
		// private void SetProgress(float percentage)
		// {
		// 	var curveVal = animCurve.Evaluate(percentage);
		//
		// 	switch (ikType)
		// 	{
		// 		case FullBodyBipedEffector.Body:
		// 			{
		// 				BodyIk.solver.bodyEffector.positionWeight = curveVal;
		// 				break;
		// 			}
		//
		// 		case FullBodyBipedEffector.LeftHand:
		// 			{
		// 				BodyIk.solver.leftHandEffector.positionWeight = curveVal;
		// 				break;
		// 			}
		//
		// 		case FullBodyBipedEffector.RightHand:
		// 			{
		// 				BodyIk.solver.rightHandEffector.positionWeight = curveVal;
		// 				BodyIk.solver.rightHandEffector.rotationWeight = curveVal;
		// 				break;
		// 			}
		//
		// 		case FullBodyBipedEffector.LeftShoulder:
		// 			{
		// 				BodyIk.solver.leftShoulderEffector.positionWeight = curveVal;
		// 				break;
		// 			}
		//
		// 		case FullBodyBipedEffector.RightShoulder:
		// 			{
		// 				BodyIk.solver.rightShoulderEffector.positionWeight = curveVal;
		// 				break;
		// 			}
		//
		// 		case FullBodyBipedEffector.LeftThigh:
		// 			{
		// 				BodyIk.solver.leftThighEffector.positionWeight = curveVal;
		// 				break;
		// 			}
		//
		// 		case FullBodyBipedEffector.RightThigh:
		// 			{
		// 				BodyIk.solver.rightThighEffector.positionWeight = curveVal;
		// 				break;
		// 			}
		//
		// 		case FullBodyBipedEffector.LeftFoot:
		// 			{
		// 				BodyIk.solver.leftFootEffector.positionWeight = curveVal;
		// 				break;
		// 			}
		//
		// 		case FullBodyBipedEffector.RightFoot:
		// 			{
		// 				BodyIk.solver.rightFootEffector.positionWeight = curveVal;
		// 				break;
		// 			}
		//
		// 		default:
		// 			{
		// 				throw new ArgumentOutOfRangeException();
		// 			}
		// 	}
		// }
		//
		// #endregion
	}
}
