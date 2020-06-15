using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class separation : MonoBehaviour
{
    public bool testManuelDuTrigger;

    [Tooltip("L'objet à gauche - se déplacera vers la gauche")]
    public Transform lObject;

    [Tooltip("L'objet à droite - se déplacera vers la droite")]
    public Transform rObject;

    // De combien on va faire glisser la porte en x
    public float slideDist;

    // La courbe de l'animation.
    // L'abscisse (horizontalement) représente le temps
    // L'ordonnée (verticale) le déplacement, où 0 c'est le départ, et 1 la position finale (à slideDist)
    [Tooltip("Courbe de l'animation")]
    public AnimationCurve curve;

    // Pour stocker la durée totale de la courbe
    private float curveDuration;

    // Les positions originales en X des deux portes
    private float lOriginalPosX;
    private float rOriginalPosX;

    /*
     * C'est important de savoir si on est en train de se déplacer
     * pour éviter d'initier plusieurs fois en même temps un déplacement.
     * Donc quand on démarre une ouverture, on le sauve dans isMoving
     */
    private bool isMoving;


    // Start is called before the first frame update
    void Start()
    {
        // on fait une fois pour toute le calcul de la courbe
        curveDuration = curve.keys[curve.length - 1].time;

        // on sauve la position en X de départ
        lOriginalPosX = lObject.localPosition.x;
        rOriginalPosX = rObject.localPosition.x;
    }

    void Update()
    {
        // ça c'est juste pour pouvoir tester
        if (testManuelDuTrigger && !isMoving)
        {
            StartCoroutine(Move());
            Debug.Log("ntm");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isMoving)
        {
            StartCoroutine(Move());
        }
    }

    IEnumerator Move()
    {
        isMoving = true;

        // on va utiliser la durée de la courbe pour "arrêter" le while, cette fois
        // on initialise donc notre compteur t (pour Time)
        float t = 0;

        // tant qu'on n'est pas arrivés au bout de la courbe
        while (t <= curveDuration)
        {
            // le déplacement à exécuter sur cette frame-ci
            // "curve.Evaluate(t) renvoie la valeur de la courbe au temps t
            float lPosX = lOriginalPosX - curve.Evaluate(t); // vers la gauche, on décrémente x
            float rPosX = rOriginalPosX + curve.Evaluate(t); // vers la droite, on incrémente x

            // on modifie les position en x
            lObject.localPosition = new Vector3(
                lPosX,

                lObject.localPosition.y,
                lObject.localPosition.z);

            rObject.localPosition = new Vector3(
                rPosX,
                rObject.localPosition.y,
                rObject.localPosition.z);

            // on incrémente le compteur
            // c'est ce qui nous permet "d'avancer" dans la courbe
            // et de finalement arriver au bout et sortir du while
            t += Time.deltaTime;

            // on attend la frame suivante
            yield return null;
        }

        /*
         * Normalement quand on arrive à cet endroit du code, on vient de sortir du WHILE
         * Ça veut dire qu'on a terminé le mouvement. On va bientôt terminer la coroutine,
         * mais avant ...
         *
         * Il faut encore indiquer à tout le monde que le déplacement est terminé
         */

        //isMoving = false;
    }
}