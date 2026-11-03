using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HanoiGame : MonoBehaviour
{
    [Header("Setup")]
    [Tooltip("Invisible markers at the BOTTOM of each pole: left, middle, right.")]
    public RectTransform[] poles = new RectTransform[3];
    [Tooltip("Your Block objects, BIGGEST first, smallest last.")]
    public RectTransform[] blocks;

    [Header("Win")]
    public GameObject winPanel;             // assign EndScreen
    public UnityEvent onWin;

    [Header("Auto size (canvas units)")]
    public bool autoSize = true;
    public float maxWidth = 380f;       // biggest block (bottom)
    public float minWidth = 220f;       // smallest block (top)
    public float maxHeight = 110f;
    public float minHeight = 90f;
    public float maxStackHeight = 600f; // everything together must fit the poles

    [Header("Moves & stars")]
    public Text moveText;               // live counter on screen
    public Text endMoveText;            // optional: final move count on EndScreen
    public SpriteRenderer[] stars;      // Star1, Star2, Star3 in that order
    public int threeStarMoves = 70;     // moves <= this -> 3 stars
    public int twoStarMoves = 90;       // moves <= this -> 2 stars, otherwise 1
    public Color starOn = Color.white;
    public Color starOff = new Color(0.25f, 0.25f, 0.25f, 1f);
    public GameObject trophy;

    public int Moves { get; private set; }

    readonly List<HanoiBlock>[] stacks = new List<HanoiBlock>[3];
    readonly List<HanoiBlock> blockList = new List<HanoiBlock>();
    bool won;

    void Start()
    {
        if (poles == null || poles.Length != 3 || poles[0] == null || poles[1] == null || poles[2] == null ||
            blocks == null || blocks.Length == 0)
        {
            Debug.LogError("HanoiGame: assign the 3 poles and your blocks.");
            enabled = false;
            return;
        }

        for (int i = 0; i < 3; i++) stacks[i] = new List<HanoiBlock>();
        Canvas.ForceUpdateCanvases();
        if (autoSize) ApplySizes();

        for (int i = 0; i < blocks.Length; i++)
        {
            var hb = blocks[i].GetComponent<HanoiBlock>();
            if (hb == null) hb = blocks[i].gameObject.AddComponent<HanoiBlock>();
            hb.Init(this, blocks.Length - i);   // first in the list = biggest
            blockList.Add(hb);
        }

        ResetGame();
    }

    // Hook this to RestartButton's OnClick.
    public void ResetGame()
    {
        won = false;
        Moves = 0;
        foreach (var s in stacks) s.Clear();
        foreach (var b in blockList)
        {
            b.PoleIndex = 0;
            stacks[0].Add(b);                   // biggest ends up at the bottom
        }
        if (winPanel != null) winPanel.SetActive(false);
    }

    // Re-positions every block each frame (except the one being dragged),
    // stacking by each block's real height. Illegal drops snap back automatically.
    void LateUpdate()
    {
        for (int p = 0; p < 3; p++)
        {
            RectTransform pole = poles[p];
            Vector3 pos = pole.TransformPoint(new Vector3(pole.rect.center.x, pole.rect.yMin, 0f));

            foreach (var b in stacks[p])
            {
                float h = b.Rect.rect.height * b.Rect.lossyScale.y;
                if (!b.IsDragging) b.Rect.position = pos + new Vector3(0f, h * 0.5f, 0f);
                pos.y += h;
            }
        }
    }

    public bool CanDrag(HanoiBlock b)
    {
        if (won) return false;
        var s = stacks[b.PoleIndex];
        return s[s.Count - 1] == b;             // only the top block of a pole
    }

    public void Drop(HanoiBlock b)
    {
        int target = NearestPole(b.Rect.position.x);
        if (target == b.PoleIndex) return;

        var dest = stacks[target];
        if (dest.Count > 0 && dest[dest.Count - 1].Size < b.Size) return;   // bigger onto smaller: no

        stacks[b.PoleIndex].Remove(b);
        dest.Add(b);
        b.PoleIndex = target;
        Moves++;
        UpdateMoveUI();

        if (stacks[2].Count == blockList.Count) Win();
    }

    int NearestPole(float worldX)
    {
        int best = 0;
        float bestDist = float.MaxValue;
        for (int i = 0; i < 3; i++)
        {
            float d = Mathf.Abs(poles[i].position.x - worldX);
            if (d < bestDist) { bestDist = d; best = i; }
        }
        return best;
    }
    void Win()
    {
        won = true;
        Debug.Log("Hanoi solved in " + Moves + " moves!");
        if (winPanel != null)
        {
            ShowStars();
            if (endMoveText != null)
            {
                endMoveText.text = "Gājieni: " + Moves;
                winPanel.SetActive(true);
                onWin?.Invoke();
            }
            trophy.SetActive(true);
        }
    }

    void ApplySizes()
    {
        int n = blocks.Length;
        var sizes = new Vector2[n];
        float total = 0f;

        for (int i = 0; i < n; i++)
        {
            float t = n > 1 ? 1f - i / (float)(n - 1) : 1f;   // first = 1 (biggest), last = 0
            sizes[i] = new Vector2(Mathf.Lerp(minWidth, maxWidth, t),
                                   Mathf.Lerp(minHeight, maxHeight, t));
            total += sizes[i].y;

            // Preserve Aspect would cancel the "wider" effect, so let the sprite fill the rect
            var img = blocks[i].GetComponent<Image>();
            if (img != null) img.preserveAspect = false;
        }

        float k = total > maxStackHeight ? maxStackHeight / total : 1f;
        for (int i = 0; i < n; i++)
            blocks[i].sizeDelta = sizes[i] * k;
    }

    void UpdateMoveUI()
    {
        if (moveText != null) moveText.text = "Gājieni: " + Moves;
    }

    int StarsFor(int moves)
    {
        if (moves <= threeStarMoves) return 3;
        if (moves <= twoStarMoves) return 2;
        return 1;
    }

    void ShowStars()
    {
        if (stars == null) return;
        int lit = StarsFor(Moves);
        for (int i = 0; i < stars.Length; i++)
            if (stars[i] != null) stars[i].color = i < lit ? starOn : starOff;
    }

    // Called by RewardedAds after a completed rewarded ad.
    public void ReduceMoves(int amount)
    {
        Moves = Mathf.Max(0, Moves - amount);
        UpdateMoveUI();
    }
    public class HanoiBlock : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public int Size { get; private set; }           // bigger number = bigger block
        public int PoleIndex { get; set; }
        public bool IsDragging { get; private set; }
        public RectTransform Rect { get; private set; }

        HanoiGame game;
        RectTransform parentRect;
        Vector3 grabOffset;
        bool dragAllowed;

        public void Init(HanoiGame g, int size)
        {
            game = g;
            Size = size;
            Rect = (RectTransform)transform;
            parentRect = (RectTransform)transform.parent;
        }

        public void OnBeginDrag(PointerEventData e)
        {
            dragAllowed = game.CanDrag(this);
            if (!dragAllowed) return;

            IsDragging = true;
            transform.SetAsLastSibling();               // draw above everything while dragging
            grabOffset = Rect.position - PointerToWorld(e);
        }

        public void OnDrag(PointerEventData e)
        {
            if (!dragAllowed) return;
            Rect.position = PointerToWorld(e) + grabOffset;
        }

        public void OnEndDrag(PointerEventData e)
        {
            if (!dragAllowed) return;
            dragAllowed = false;
            IsDragging = false;
            game.Drop(this);                            // illegal drops simply snap back
        }

        Vector3 PointerToWorld(PointerEventData e)
        {
            RectTransformUtility.ScreenPointToWorldPointInRectangle(parentRect, e.position, e.pressEventCamera, out Vector3 world);
            return world;
        }
    }
}
