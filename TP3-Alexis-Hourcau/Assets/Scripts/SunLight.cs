using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunLight : MonoBehaviour
{

    public Light sun;
    public float dayDuration = 2f;  // Durée du cycle complet en minutes

    public float minIntensity = 0f;
    public float maxIntensity = 1f;

    public float currentTime = 0f;

    void Update()
    {
        // Calculer l'heure virtuelle du jour (en pourcentage, entre 0 et 1)
        currentTime += Time.deltaTime / ( dayDuration * 60f );
        currentTime %= 1;  // Boucle du temps pour revenir à 0 après 1

        float sunRotation = currentTime * 360f - 90f; // -90 pour que 0 soit à minuit
        sun.transform.rotation = Quaternion.Euler(sunRotation, 170f, 0f);

        float intensityMultiplier = Mathf.Clamp01(Mathf.Cos(currentTime * Mathf.PI * 2f)); // Valeurs entre 0 et 1
        sun.intensity = Mathf.Lerp(minIntensity, maxIntensity, intensityMultiplier);
    }
}
