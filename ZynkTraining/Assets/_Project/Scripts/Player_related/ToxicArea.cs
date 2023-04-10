using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicArea : MonoBehaviour
{
    public static ToxicArea Instance { get; private set; }
    private void Awake() {
        Instance = this;
    }
    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<Controller>() == null)
            return;
        StartCoroutine(Instance.DamagePlayer());
    }

    private void OnTriggerExit(Collider other) {
        if (other.GetComponent<Controller>() == null)
            return;
        StopAllCoroutines();
    }

    private  IEnumerator DamagePlayer() {
        HealthController.Instance.ChangeHealth(-1);
        yield return new WaitForSecondsRealtime(2f);
        StartCoroutine(Instance.DamagePlayer());
    }
}
