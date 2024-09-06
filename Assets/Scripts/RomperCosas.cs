using UnityEngine;
using UnityEngine.Tilemaps;

public class RomperCosas : MonoBehaviour
{
    public Tilemap destructibleTilemap; 
    public Vector3Int tileOffset; 
    private Animator animator;
    private Vector2 movement;
    private Vector2 lastMovementDirection;

    void Start()
    {
        // inicializar el animator que es componente del granjero
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // obtener movimiento del jugador
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // actualizar la ultima direccion de movimiento si el jugador esta quieto
        if (movement != Vector2.zero)
        {
            lastMovementDirection = movement;
        }

        // mostrar animacion de ataque
        if (Input.GetKeyDown(KeyCode.R))
        {
            animator.SetTrigger("Attack");
            Attack();
        }
    }

    void Attack()
    {
        // determinar la direccion del ataque basado en la ultima dirección de movimiento
        Vector3 attackDirection = new Vector3(lastMovementDirection.x, lastMovementDirection.y, 0);

        // calcular la posición de la casilla a destruir
        Vector3Int tilePosition = destructibleTilemap.WorldToCell(transform.position + attackDirection + (Vector3)tileOffset);

        // destruir la casilla si existe
        if (destructibleTilemap.HasTile(tilePosition))
        {
            destructibleTilemap.SetTile(tilePosition, null);
        }
    }
}
