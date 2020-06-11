using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mer_separation : MonoBehaviour
{
    /*
     * C'est important de savoir si on est en train de se déplacer
     * pour éviter d'initier plusieurs fois en même temps un déplacement.
     * Donc quand on démarre une ouverture, on le sauve dans isMoving
     */
    private bool isMoving;

    // de combien on va faire glisser la porte en x
    public float slideDist;

    // quand on code un déplacement, la vélocité donne à la fois la vitesse et la direction
    // ("5" ça sera par exemple vite vers la droite, "-0.1" ça sera plus lentement vers la gauche
    public float slideVelocity;

   


    // Start is called before the first frame update
    void Start()
    {
        // ici je la démarre automatiquement, il faudrait qu'elle démarre grâce au trigger
        // ET à condition qu'elle ne soit pas déjà en mouvement (isSliding)
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.name == "Joueur")
        {
            StartCoroutine(Move(slideDist, slideVelocity));
            Debug.Log("ntm");

        }

    }


    // Coroutine - son exécution est indépendante du update
    IEnumerator Move(float dist, float velocity)
    {
        isMoving = true;

        // on va enregistrer de combien on s'est déplacés
        // pour pouvoir arrêter le while quand on a fini le déplacement
        float movedDistance = 0f;

        /*
         * "tant que la distance parcourue est plus petite que la distance à parcourir"
         * Traditionellement un while s'exécute d'un coup - sur une seule frame
         * mais dans cette coroutine, on va l'étaler sur plusieurs frames
         */
        while (movedDistance < dist)
        {

            // le déplacement à exécuter sur cette frame-ci
            float moveX = velocity * Time.deltaTime;

            // on ajoute ce déplacement à la position en x
            transform.position = new Vector3(
                transform.localPosition.x + moveX,
                transform.localPosition.y,
                transform.localPosition.z);

            // puisque le déplacement peut être positif ou négatif
            // on prend la valeur absolue pour juste savoir de combien on s'est déplacés
            // sans se préoccuper de la direction
            movedDistance += Mathf.Abs(moveX);

            // ça, ça veut dire "maintenant on interrompt la coroutine dans son état actuel
            // et on reprendra le code à cet endroit à la prochaine frame"
            // ce qui permet d'étaler le while sur plusieurs frames
            yield return null;
        }

        /*
         * Normalement quand on arrive à cet endroit du code, on vient de sortir du WHILE
         * Ça veut dire qu'on a terminé le mouvement. On va bientôt terminer la coroutine,
         * mais avant ...
         *
         * Il faut encore indiquer à tout le monde que le déplacement est terminé
         */

        isMoving = false;
    }
}




