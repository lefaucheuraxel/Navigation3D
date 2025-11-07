using UnityEngine;

public class DisableInteractor : MonoBehaviour
{

    public GameObject AssociatedInteractor;

    private void OnEnable()
    {
       if (AssociatedInteractor != null) AssociatedInteractor.SetActive(true);
    }

    private void OnDisable()
    {
        if (AssociatedInteractor != null) AssociatedInteractor.SetActive(false);
    }
}
