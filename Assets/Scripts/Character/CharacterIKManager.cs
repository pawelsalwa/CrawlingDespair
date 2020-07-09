// using Character.Benedict;
// using UnityEngine;
//
// namespace Character
// {
// 	public class CharacterIKManager : MonoBehaviour
// 	{
// 		#region Variables
//
// 		[SerializeField]
// 		private float _minYSpeedToPlayHitMotion = 1f;
//
// 		[SerializeField]
// 		private IkMotionMocker hitGroundMocker = null;
//
// 		[SerializeField]
// 		private IkMotionMocker hookPullMocker = null;
//
// 		[SerializeField]
// 		private IkMotionMocker takeDamageFromRightMocker = null;
//
// 		[SerializeField]
// 		private IkMotionMocker takeDamageFromLeftMocker = null;
//
// 		// [SerializeField]
// 		// private IkMotionMocker takeDamageFromUpMocker = null;
// 		//
// 		// [SerializeField]
// 		// private IkMotionMocker takeDamageFromDownMocker = null;
//
// 		[SerializeField]
// 		private IkMotionMocker shootImpactMocker = null;
//
// 		[SerializeField]
// 		private IkMotionMocker elbowBlockMocker = null;
//
// 		[SerializeField]
// 		private IkMotionMultiMocker testMultiMocker = null;
//
// 		// [SerializeField]
// 		// private IkMotionMocker wristBlockMocker;
//
// 		#endregion
//
// 		#region Mocks
// 		
// 		private void MockHittingGround(Vector3 dir)
// 		{
// 			if (dir.y > _minYSpeedToPlayHitMotion) return;
// 			hitGroundMocker.TargetsPos = transform.position + Vector3.up + dir.normalized;
// 			hitGroundMocker.PlayIkMotion();
// 		}
//
// 		private void MockTakeDamage(bool fromRight)
// 		{
// 			if (fromRight) takeDamageFromRightMocker.PlayIkMotion();
// 			else takeDamageFromLeftMocker.PlayIkMotion();
// 		}
//
// 		private void MockHookPull(Vector2 dir)
// 		{
// 			hookPullMocker.TargetsPos = transform.position + Vector3.up + new Vector3(dir.normalized.x, dir.normalized.y, 0f); // hak pullowany 1m od mniej wiecej pasa
// 			hookPullMocker.PlayIkMotion();
// 		}
//
// 		private void MockBlock()
// 		{
// 			elbowBlockMocker.PlayIkMotion();
// 		}
//
// 		private void TestMultiMocks()
// 		{
// 			testMultiMocker.PlayIkMotions();
// 		}
//
// 		#endregion
//
// 		#region Initialization
//
// 		public void InitBenedict(CharacterBenedict characterBenedict) // TODO rozkminic inne charactery, moze znowu dziedziczenie.
// 		{
// 			characterBenedict.BipedMovement.OnHookStart += MockHookPull;
// 			characterBenedict.BenedictBlocking.OnBlock += MockBlock;
//
// 			// var move = GetComponent<BipedMovement>();
// 			// if (move != null) move.OnGroundedStart += MockHittingGround;
//
// 			// var shoot = GetComponent<CharacterShooting>();
// 			// if (shoot != null) shoot.OnShoot += MockShoot;
// 			// var hp = GetComponent<CharacterHealth>();
// 			// if (hp != null) hp.OnTakingDmg += MockTakeDamage;
// 			//
// 			// var block = GetComponent<CharacterBlocking>();
// 			// if (block != null) block.OnBlockingStarted += MockBlock;
// 		}
//
// 		#endregion
//
// 	}
// }