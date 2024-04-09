using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDetector : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 startPosition;
    private Vector3 offset;

    private Vector3 initialPosition;

    private Rigidbody rigdRigidbody;

    public GameObject Objectives;

    private void Start()
    {
        initialPosition = transform.position;
        rigdRigidbody = GetComponent<Rigidbody>();
        rigdRigidbody.useGravity = false; // Desativa a gravidade no in�cio
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // Verifique se o toque come�ou dentro do objeto
                        rigdRigidbody.useGravity = false;
                    if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
                    {
                        Objectives.SetActive(false);
                        isDragging = true;
                        // Salve a posi��o inicial do toque e a posi��o inicial do objeto
                        startPosition = transform.position;
                        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                    }
                    break;
                case TouchPhase.Moved:
                    if (isDragging)
                    {
                        // Atualize a posi��o do objeto enquanto ele est� sendo arrastado
                        Vector3 touchPoint = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                        transform.position = new Vector3(touchPoint.x + offset.x, touchPoint.y + offset.y, transform.position.z);
                    }
                    break;
                case TouchPhase.Ended:
                    // Se o toque terminar, pare de arrastar o objeto
                    isDragging = false;
                    rigdRigidbody.useGravity = true; // Ativa a gravidade quando o objeto � solto
                    Objectives.SetActive(true);
                    break;
            }
        }
        else // Verifica se o objeto est� tocando o ch�o
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 2f))
            {
                rigdRigidbody.useGravity = false; // Desativa a gravidade quando o objeto toca o ch�o
            }
        }
    }
}
