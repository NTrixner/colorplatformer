using UnityEngine;
using UnityEngine.Serialization;

namespace Movement
{
    public class UICanvasControllerInput : MonoBehaviour
    {

        [FormerlySerializedAs("starterAssetsInputs")] [Header("Output")]
        public Inputs inputs;

        public void VirtualMoveInput(Vector2 virtualMoveDirection)
        {
            inputs.MoveInput(virtualMoveDirection);
        }

        public void VirtualLookInput(Vector2 virtualLookDirection)
        {
            inputs.LookInput(virtualLookDirection);
        }

        public void VirtualJumpInput(bool virtualJumpState)
        {
            inputs.JumpInput(virtualJumpState);
        }

    }

}
