using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker_Circle : MonoBehaviour
{
    public Image circlePalette;
    public Image picker;
    public Color selectedColor;

    private Vector2 sizeOfPalette;
    private CircleCollider2D paletteCollider;

    void Start()
    {
        paletteCollider = paletteCollider.GetComponent<CircleCollider2D>();

        sizeOfPalette = new Vector2(
            paletteCollider.GetComponent<RectTransform>().rect.width,
            paletteCollider.GetComponent<RectTransform>().rect.height
        );
    }

    public void MousePointerDown()
    {
        SelectColor();
    }

    public void MouseDrag()
    {
        SelectColor();
    }

    private Color GetColor()
    {
        Vector2 circlePalettePosition = circlePalette.transform.position;
        Vector2 pickerPosition = picker.transform.position;

        Vector2 position = pickerPosition - circlePalettePosition + sizeOfPalette * 0.5f;
        
        Vector2 normalized = new Vector2(
            (position.x / (circlePalette.GetComponent<RectTransform>().rect.width)),
            (position.y / (circlePalette.GetComponent<RectTransform>().rect.height)));

        Texture2D texture = circlePalette.mainTexture as Texture2D;
        Color circularSelectedColor = texture.GetPixelBilinear(normalized.x, normalized.y);

        return circularSelectedColor;
    }

    private void SelectColor()
    {
        Vector3 offset = Input.mousePosition - transform.position;
        Vector3 diff = Vector3.ClampMagnitude(offset, paletteCollider.radius);

        picker.transform.position = transform.position + diff;
        selectedColor = GetColor();
    }
}
