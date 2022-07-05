using UnityEngine;

namespace Player
{
  public class Coin : MonoBehaviour
  {

    // public int startWithCoin { get; set; } = 100;
    private UIManager _uiManager;
    [SerializeField] public int startWithCoin = 20;

    [SerializeField] private AudioClip coinInSFX;
    AudioSource _myAudioSource;



    private void Start()
    {
      _uiManager = FindObjectOfType<UIManager>();
      _uiManager.UpdateCoinText(startWithCoin);
      _myAudioSource = GetComponent<AudioSource>();
    }

    // public int startWithCoin = 10;
    public void AddCoin(int income)
    {
      StartCoroutine(_uiManager.AddCoinTextPopUp(income));
      startWithCoin += income;
      _uiManager.UpdateCoinText(startWithCoin);
      _myAudioSource.PlayOneShot(coinInSFX);
    }



    /*IEnumerator CoinTextPopup(Vector3 position)
  {
    GameObject coinText = Instantiate(coinPopUpPrefab, position, Quaternion.identity);
    yield return new WaitForSeconds(1f);
    Destroy(coinText);
  }*/

    public void SubtractCoin(int expense)
    {
      startWithCoin -= expense;
      _uiManager.UpdateCoinText(startWithCoin);
    }


  }
}
