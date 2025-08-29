using UnityEngine;

namespace ThirdPesonCharacter
{
[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider), (typeof(Animator)))]
[DisallowMultipleComponent]
public class ThirdPersonController : MonoBehaviour
{
    [SerializeField] private float mMovingTurnSpeed = 360;
    [SerializeField] private float mStationaryTurnSpeed = 180;
    [SerializeField] private float mJumpPower = 12f;
    [Range(1f, 4f)] [SerializeField] private float mGravityMultiplier = 2f;
    [Tooltip("Character model specific - change this for other models if you have animation issues")]
    [SerializeField] private float mRunCycleLegOffset = 0.2f;
    [SerializeField] private float mMoveSpeedMultiplier = 1f;
    [SerializeField] private float mAnimSpeedMultiplier = 1f;
    [SerializeField] private float mGroundCheckDistance = 0.1f;

    private Rigidbody _mRigidbody;
    private Animator _mAnimator;
    private bool _mIsGrounded;
    private float _mOrigGroundCheckDistance;
    private const float KHalf = 0.5f;
    private float _mTurnAmount;
    private float _mForwardAmount;
    private Vector3 _mGroundNormal;
    private float _mCapsuleHeight;
    private Vector3 _mCapsuleCenter;
    private CapsuleCollider _mCapsule;
    private bool _mCrouching;

    private void Start()
    {
        _mAnimator = GetComponent<Animator>();
        _mRigidbody = GetComponent<Rigidbody>();
        _mCapsule = GetComponent<CapsuleCollider>();
        _mCapsuleHeight = _mCapsule.height;
        _mCapsuleCenter = _mCapsule.center;

        _mRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY |
                                  RigidbodyConstraints.FreezeRotationZ;
        _mOrigGroundCheckDistance = mGroundCheckDistance;
    }

    public void Move(Vector3 move, bool crouch, bool jump)
    {
        // convert the world relative moveInput vector into a local-relative
        // turn amount and forward amount required to head in the desired
        // direction.
        if (move.magnitude > 1f) move.Normalize();
        move = transform.InverseTransformDirection(move);
        CheckGroundStatus();
        move = Vector3.ProjectOnPlane(move, _mGroundNormal);
        _mTurnAmount = Mathf.Atan2(move.x, move.z);
        _mForwardAmount = move.z;

        ApplyExtraTurnRotation();

        // control and velocity handling is different when grounded and airborne:
        if (_mIsGrounded)
            HandleGroundedMovement(crouch, jump);
        else
            HandleAirborneMovement();

        ScaleCapsuleForCrouching(crouch);
        PreventStandingInLowHeadroom();

        // send input and other state parameters to the animator
        UpdateAnimator(move);
    }

    private void ScaleCapsuleForCrouching(bool crouch)
    {
        if (_mIsGrounded && crouch)
        {
            if (_mCrouching) return;
            _mCapsule.height = _mCapsule.height / 2f;
            _mCapsule.center = _mCapsule.center / 2f;
            _mCrouching = true;
        }
        else
        {
            var crouchRay = new Ray(_mRigidbody.position + Vector3.up * _mCapsule.radius * KHalf, Vector3.up);
            var crouchRayLength = _mCapsuleHeight - _mCapsule.radius * KHalf;
            if (Physics.SphereCast(crouchRay, _mCapsule.radius * KHalf, crouchRayLength, Physics.AllLayers,
                    QueryTriggerInteraction.Ignore))
            {
                _mCrouching = true;
                return;
            }

            _mCapsule.height = _mCapsuleHeight;
            _mCapsule.center = _mCapsuleCenter;
            _mCrouching = false;
        }
    }

    private void PreventStandingInLowHeadroom()
    {
        // prevent standing up in crouch-only zones
        if (!_mCrouching)
        {
            var crouchRay = new Ray(_mRigidbody.position + Vector3.up * _mCapsule.radius * KHalf, Vector3.up);
            var crouchRayLength = _mCapsuleHeight - _mCapsule.radius * KHalf;
            if (Physics.SphereCast(crouchRay, _mCapsule.radius * KHalf, crouchRayLength, Physics.AllLayers,
                    QueryTriggerInteraction.Ignore)) _mCrouching = true;
        }
    }

    private void UpdateAnimator(Vector3 move)
    {
        // update the animator parameters
        _mAnimator.SetFloat("Forward", _mForwardAmount, 0.1f, Time.deltaTime);
        _mAnimator.SetFloat("Turn", _mTurnAmount, 0.1f, Time.deltaTime);
        _mAnimator.SetBool("Crouch", _mCrouching);
        _mAnimator.SetBool("OnGround", _mIsGrounded);
        if (!_mIsGrounded) _mAnimator.SetFloat("Jump", _mRigidbody.velocity.y);

        // calculate which leg is behind, so as to leave that leg trailing in the jump animation
        // (This code is reliant on the specific run cycle offset in our animations,
        // and assumes one leg passes the other at the normalized clip times of 0.0 and 0.5)
        var runCycle =
            Mathf.Repeat(
                _mAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime + mRunCycleLegOffset, 1);
        var jumpLeg = (runCycle < KHalf ? 1 : -1) * _mForwardAmount;
        if (_mIsGrounded) _mAnimator.SetFloat("JumpLeg", jumpLeg);

        // the anim speed multiplier allows the overall speed of walking/running to be tweaked in the inspector,
        // which affects the movement speed because of the root motion.
        if (_mIsGrounded && move.magnitude > 0)
            _mAnimator.speed = mAnimSpeedMultiplier;
        else
            // don't use that while airborne
            _mAnimator.speed = 1;
    }

    private void HandleAirborneMovement()
    {
        // apply extra gravity from multiplier:
        var extraGravityForce = Physics.gravity * mGravityMultiplier - Physics.gravity;
        _mRigidbody.AddForce(extraGravityForce);

        mGroundCheckDistance = _mRigidbody.velocity.y < 0 ? _mOrigGroundCheckDistance : 0.01f;
    }

    private void HandleGroundedMovement(bool crouch, bool jump)
    {
        // check whether conditions are right to allow a jump:
        if (jump && !crouch && _mAnimator.GetCurrentAnimatorStateInfo(0).IsName("Grounded"))
        {
            // jump!
            _mRigidbody.velocity = new Vector3(_mRigidbody.velocity.x, mJumpPower, _mRigidbody.velocity.z);
            _mIsGrounded = false;
            _mAnimator.applyRootMotion = false;
            mGroundCheckDistance = 0.1f;
        }
    }

    private void ApplyExtraTurnRotation()
    {
        // help the character turn faster (this is in addition to root rotation in the animation)
        var turnSpeed = Mathf.Lerp(mStationaryTurnSpeed, mMovingTurnSpeed, _mForwardAmount);
        transform.Rotate(0, _mTurnAmount * turnSpeed * Time.deltaTime, 0);
    }

    public void OnAnimatorMove()
    {
        // we implement this function to override the default root motion.
        // this allows us to modify the positional speed before it's applied.
        if (_mIsGrounded && Time.deltaTime > 0)
        {
            var v = _mAnimator.deltaPosition * mMoveSpeedMultiplier / Time.deltaTime;

            // we preserve the existing y part of the current velocity.
            v.y = _mRigidbody.velocity.y;
            _mRigidbody.velocity = v;
        }
    }

    private void CheckGroundStatus()
    {
        RaycastHit hitInfo;
#if UNITY_EDITOR
        // helper to visualise the ground check ray in the scene view
        Debug.DrawLine(transform.position + Vector3.up * 0.1f,
            transform.position + Vector3.up * 0.1f + Vector3.down * mGroundCheckDistance);
#endif
        // 0.1f is a small offset to start the ray from inside the character
        // it is also good to note that the transform position in the sample assets is at the base of the character
        if (Physics.Raycast(transform.position + Vector3.up * 0.1f, Vector3.down, out hitInfo, mGroundCheckDistance))
        {
            _mGroundNormal = hitInfo.normal;
            _mIsGrounded = true;
            _mAnimator.applyRootMotion = true;
        }
        else
        {
            _mIsGrounded = false;
            _mGroundNormal = Vector3.up;
            _mAnimator.applyRootMotion = false;
        }
    }
}
}