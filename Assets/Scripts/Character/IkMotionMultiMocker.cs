// using System;
// using System.Collections.Generic;
// using RootMotion;
// using UnityEngine;
//
// namespace Character
// {
// 	public class IkMotionMultiMocker : MonoBehaviour
// 	{
// 		#region Variables
// 		public HumanoidBaker Baker;
// 		public bool BakeAnimation = false;
//
// 		public List<IkMotionMocker> MotionMockers = new List<IkMotionMocker>();
//
// 		private int numberOfMockersStarted;
// 		private int numberOfMockersFinished;
//
// 		#endregion
//
// 		#region MonoBehaviours
//
// 		private void OnValidate()
// 		{
// 			foreach (var ikMotionMocker in MotionMockers)
// 			{
// 				ikMotionMocker.NotifyOnIkMotionStarted += OnIkMotionStarted;
// 				ikMotionMocker.NotifyOnIkMotionFinished += OnIkMotionFinished;
// 			}
// 		}
//
// 		#endregion
//
// 		#region IkMotion
//
// 		public void PlayIkMotions()
// 		{
// 			foreach (var ikMotionMocker in MotionMockers)
// 			{
// 				ikMotionMocker.PlayIkMotion();
// 			}
// 		}
//
// 		public void PlayIkMotionsFromInspector()
// 		{
// 			foreach (var ikMotionMocker in MotionMockers)
// 			{
// 				ikMotionMocker.PlayIkMotionFromInspector();
// 			}
// 		}
//
// 		#endregion
//
// 		#region Utilities
//
// 		private void OnIkMotionStarted(IkMotionMocker mocker)
// 		{
// 			numberOfMockersStarted++;
//
// 			if (numberOfMockersStarted == MotionMockers.Count)
// 			{
// 				numberOfMockersStarted = 0;
//
// 				if (BakeAnimation)
// 				{
// 					Baker.StartBaking();
// 				}
// 			}
// 		}
//
// 		private void OnIkMotionFinished(IkMotionMocker mocker)
// 		{
// 			numberOfMockersFinished++;
//
// 			if (numberOfMockersFinished == MotionMockers.Count)
// 			{
// 				numberOfMockersFinished = 0;
//
// 				if (BakeAnimation)
// 				{
// 					Baker.StopBaking();
// 				}
// 			}
// 		}
//
// 		#endregion
//
// 	}
// }
