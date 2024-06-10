public class CursorObject : PoolObject
{
    // Animation Event로 호출 _ Animation이 끝나면 자동으로 반환
    public void DisableCursor()
    {
        gameObject.SetActive(false);
    }
}