using UnityEngine;
using UnityEngine.InputSystem;

using Unity.XR.CoreUtils;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using UnityEngine.XR.Interaction.Toolkit.Locomotion;

public class ContinuousScaleChangeProvider : LocomotionProvider
{
    [SerializeField]
    [Tooltip("The factor used to change the scale.")]
    public float m_ScaleFactor = 0.01f;

    /// <summary>
    /// The factor used to change the scale.
    /// </summary>
    public float scaleFactor
    {
        get => m_ScaleFactor;
        set => m_ScaleFactor = value;
    }

    [SerializeField]
    [Tooltip("The Input System Action that will be used to read Scale data from the left hand controller. Must be a Value Vector2 Control.")]
    InputActionProperty m_LeftHandScaleAction;
    /// <summary>
    /// The Input System Action that Unity uses to read Move data from the left hand controller. Must be a <see cref="InputActionType.Value"/> <see cref="Vector2Control"/> Control.
    /// </summary>
    public InputActionProperty leftHandScaleAction
    {
        get => m_LeftHandScaleAction;
        set => SetInputActionProperty(ref m_LeftHandScaleAction, value);
    }

    [SerializeField]
    [Tooltip("The Input System Action that will be used to read Scale data from the right hand controller. Must be a Value Vector2 Control.")]
    InputActionProperty m_RightHandScaleAction;
    /// <summary>
    /// The Input System Action that Unity uses to read Move data from the right hand controller. Must be a <see cref="InputActionType.Value"/> <see cref="Vector2Control"/> Control.
    /// </summary>
    public InputActionProperty rightHandScaleAction
    {
        get => m_RightHandScaleAction;
        set => SetInputActionProperty(ref m_RightHandScaleAction, value);
    }

    /// <summary>
    /// See <see cref="MonoBehaviour"/>.
    /// </summary>
    protected void OnEnable()
    {
        m_LeftHandScaleAction.EnableDirectAction();
        m_RightHandScaleAction.EnableDirectAction();
    }

    /// <summary>
    /// See <see cref="MonoBehaviour"/>.
    /// </summary>
    protected void OnDisable()
    {
        m_LeftHandScaleAction.DisableDirectAction();
        m_RightHandScaleAction.DisableDirectAction();
    }

    /// <inheritdoc />
    protected Vector2 ReadInput()
    {
        Vector2 leftHandValue = m_LeftHandScaleAction.action?.ReadValue<Vector2>() ?? Vector2.zero;
        Vector2 rightHandValue = m_RightHandScaleAction.action?.ReadValue<Vector2>() ?? Vector2.zero;

        return leftHandValue + rightHandValue;
    }

    void SetInputActionProperty(ref InputActionProperty property, InputActionProperty value)
    {
        if (Application.isPlaying)
            property.DisableDirectAction();

        property = value;

        if (Application.isPlaying && isActiveAndEnabled)
            property.EnableDirectAction();
    }


    // Update is called once per frame
    void Update()
    {
        // Retrieve the mediator from the superclass
        XROrigin xrOrigin = mediator.xrOrigin;
        if (xrOrigin == null)
            return;

        // TODO: read the input

        // TODO: change the scale of the mediator

    }
}
