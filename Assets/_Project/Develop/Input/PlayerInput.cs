using UnityEngine;

public class PlayerInput: IMovementInput, IFeatureActivator
{
    private const string HorizontalKey = "Horizontal";
    private const string VerticalKey = "Vertical";
    private const KeyCode FeatuteActivationKey = KeyCode.Space;
    
    public Vector3 GetDirection() => new(Input.GetAxis(HorizontalKey), 0f, Input.GetAxis(VerticalKey));
    
    public bool Activate() => Input.GetKeyDown(FeatuteActivationKey);
}
