using UnityEngine;

public class Soldier : MonoBehaviour
{
    [SerializeField] Sprite hasNotLootSprite;
    [SerializeField] Sprite hasLootSprite;

    public float moveSpeed = 10f;
    ReturnLoot king;
    [SerializeField] bool hasLoot = false;

    [SerializeField] Sprite[] soldierSprites; //lägg in cat och hund sprites här yesyes

    SpriteRenderer spriteRenderer;
    Rigidbody2D _rigidbody;

    private void Awake()
    {
        king = Object.FindFirstObjectByType<ReturnLoot>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();

        UpdateSprite();
    }

    private void FixedUpdate()
    {
        if (!hasLoot)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            _rigidbody.linearVelocity = Vector2.right * moveSpeed;
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            _rigidbody.linearVelocity = Vector2.left * moveSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Loot"))
        {
            SetHasLoot(true);
        }
        else if (other.CompareTag("Base")) // lägg in så att man får pengar 
        {
            Destroy(gameObject);
            king.GetComponent<ReturnLoot>().LootGet();
        }
    }

    public void SetHasLoot(bool hasLoot)
    {
        this.hasLoot = hasLoot;

        transform.position += new Vector3(0f, -2f, 0f);

        UpdateSprite();
    }

    void UpdateSprite()
    {
        spriteRenderer.sprite = hasLoot ? hasLootSprite : hasNotLootSprite;
    }

    public void SetSpritePair(Sprite noLoot, Sprite withLoot)
    {
        hasNotLootSprite = noLoot;
        hasLootSprite = withLoot;
        UpdateSprite();
    }
}
