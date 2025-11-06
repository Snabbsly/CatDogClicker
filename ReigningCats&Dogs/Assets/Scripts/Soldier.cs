using UnityEngine;

public class Soldier : MonoBehaviour
{
    [SerializeField] Sprite hasNotLootSprite;
    [SerializeField] Sprite hasLootSprite;

    [SerializeField] float moveSpeed = 10f;

    [SerializeField] bool hasLoot = false;

    [SerializeField] Sprite[] soldierSprites; //lägg in cat och hund sprites här yesyes

    SpriteRenderer spriteRenderer;
    Rigidbody2D _rigidbody;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();

        UpdateSprite();
    }

    private void FixedUpdate()
    {
        if (hasLoot)
        {
            _rigidbody.linearVelocity = Vector2.left * moveSpeed;
        }
        else
        {
            _rigidbody.linearVelocity = Vector2.right * moveSpeed;
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
