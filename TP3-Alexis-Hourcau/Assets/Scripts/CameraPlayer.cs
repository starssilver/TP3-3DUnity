using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    public Player PlayerMove;  // R�f�rence au joueur
    public float distance = 5f;  // Distance de la cam�ra par rapport au joueur
    public float height = 1.5f;    // Hauteur de la cam�ra par rapport au joueur

    public float minDistance = 2f;  // Distance minimale du zoom
    public float maxDistance = 10f;  // Distance maximale du zoom

    public float sensitivityX = 4f;  // Sensibilit� de la rotation horizontale
    public float sensitivityY = 2f;  // Sensibilit� de la rotation verticale
    public float scrollSensitivity = 2f;  // Sensibilit� du zoom avec la molette

    public float minYAngle = -20f;  // Limite minimale de rotation verticale
    public float maxYAngle = 80f;   // Limite maximale de rotation verticale

    private float currentX = 0f;  // Angle horizontal courant
    private float currentY = 0f;  // Angle vertical courant

    private const string MOUSEX = "Mouse X";
    private const string MOUSEY = "Mouse Y";

    void Update()
    {
        // Rotation de la cam�ra selon la souris
        if (Input.GetMouseButton(1) || Input.GetMouseButton(0))
        {
            currentX += Input.GetAxis(MOUSEX) * sensitivityX;
            currentY -= Input.GetAxis(MOUSEY) * sensitivityY;
            currentY = Mathf.Clamp(currentY, minYAngle, maxYAngle); // Limiter l'angle vertical
        }

        // Gestion du zoom avec la molette de la souris
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        distance -= scroll * scrollSensitivity;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);  // Limiter la distance du zoom
    }

    void LateUpdate()
    {
        // Calcul de la position de la cam�ra par rapport au joueur
        Vector3 direction = new Vector3(0, height, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

        // Mise � jour de la position de la cam�ra
        transform.position = PlayerMove.transform.position + rotation * direction;

        // La cam�ra regarde toujours vers le joueur
        transform.LookAt(PlayerMove.transform.position + Vector3.up * height);

        // Rotation du joueur si le bouton droit est appuy�
        if (Input.GetMouseButton(1))
        {
            PlayerMove.transform.rotation = Quaternion.Euler(0, currentX, 0);
        }
    }
}
