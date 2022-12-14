using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


[System.Serializable]
public class Haptic
{
    [Range(0, 1)]
    public float intensity_;
    public float duration_;

    public void TriggerHaptic(BaseInteractionEventArgs eventArgs)
    {
        if (eventArgs.interactorObject is XRBaseControllerInteractor controllerInteractor)
            TriggerHaptic(controllerInteractor.xrController);
    }

    public void TriggerHaptic(XRBaseController controller)
    {
        if (intensity_ > 0)
            controller.SendHapticImpulse(intensity_, duration_);
    }
}

public class HapticInteractable : MonoBehaviour
{
    public Haptic hapticOnActivated;
    public Haptic hapticHoverEntered;
    public Haptic hapticHoverExited;
    public Haptic hapticSelectEntered;
    public Haptic hapticSelectExited;

    // Start is called before the first frame update
    void Start()
    {
        XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();

        interactable.activated.AddListener(hapticOnActivated.TriggerHaptic);
        interactable.hoverEntered.AddListener(hapticOnActivated.TriggerHaptic);
        interactable.hoverExited.AddListener(hapticOnActivated.TriggerHaptic);
        interactable.selectEntered.AddListener(hapticOnActivated.TriggerHaptic);
        interactable.selectExited.AddListener(hapticOnActivated.TriggerHaptic);
    }
}
