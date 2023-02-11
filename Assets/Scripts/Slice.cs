using UnityEngine;
using UnityEngine.UI;

public class Slice : MonoBehaviour
{
    public int score;
    public int highScore;
    [SerializeField] Text scoreText;
    [SerializeField] Text highScoreText;
    [SerializeField] Text gameoverScoreText;
    [SerializeField] Text gameoverHighScoreText;
    [SerializeField] GameObject _heart_1;
    [SerializeField] GameObject _heart_2;
    [SerializeField] GameObject _heart_3;
    public GameOverScreen gameOverScreen;
    public FoodExplosionEffect bigFoodExplosionEffect;
    public FoodExplosionEffect normalFoodExplosionEffect;
    public FoodExplosionEffect smallFoodExplosionEffect;
    public AudioSource shootSound;
    public AudioSource bombDestroySound;
    public AudioSource loseHeartSound;
    public GameObject splashRed;
    public GameObject splashGreen;
    public GameObject splashOrange;
    private ASliceAction _currentSliceAction;
    private SliceActionBigFood _sliceActionBigFood;
    private SliceActionNormalFood _sliceActionNormalFood;
    private SliceActionSmallFood _sliceActionSmallFood;


    private void Start()
    {
        highScoreText.text = "Best: " + PlayerPrefs.GetInt("Best", 0).ToString();
        _sliceActionBigFood = new SliceActionBigFood();
        _sliceActionNormalFood = new SliceActionNormalFood();
        _sliceActionSmallFood = new SliceActionSmallFood();
    }

    void OnTriggerEnter(Collider other)
    {
        _currentSliceAction = null;

        if (other.gameObject.tag == "FoodSmallTag")
        {
            _currentSliceAction = _sliceActionSmallFood;
            score++;
            Destroy(other.gameObject);
            shootSound.Play();
            // Create explosion after food destroy
            var explosion = smallFoodExplosionEffect.CreateExplosion();
            explosion.transform.position = new Vector2(other.gameObject.transform.position.x, other.gameObject.transform.position.y);
            Destroy(explosion, 3);
            // Creaete orange splash after destroy small food 
            var orangeSplash = Instantiate(splashOrange);
            orangeSplash.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, other.gameObject.transform.position.z + 7.0f);
            Destroy(orangeSplash, 5);
        }

        else if (other.gameObject.tag == "FoodNormalTag")
        {
            _currentSliceAction = _sliceActionNormalFood;
            score++;
            Destroy(other.gameObject);
            shootSound.Play();
            // Create explosion after food destroy
            var explosion = normalFoodExplosionEffect.CreateExplosion();
            explosion.transform.position = new Vector2(other.gameObject.transform.position.x, other.gameObject.transform.position.y);
            Destroy(explosion, 3);
            // Creaete green splash after destroy small food 
            var greenSplash = Instantiate(splashGreen);
            greenSplash.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, other.gameObject.transform.position.z + 7.0f);
            Destroy(greenSplash, 5);



        }

        else if (other.gameObject.tag == "FoodBigTag")
        {
            _currentSliceAction = _sliceActionBigFood;
            score++;
            Destroy(other.gameObject);
            shootSound.Play();
            // Create explosion after food destroy
            var explosion = bigFoodExplosionEffect.CreateExplosion();
            explosion.transform.position = new Vector2(other.gameObject.transform.position.x, other.gameObject.transform.position.y);
            Destroy(explosion, 3);
            // Creaete red splash after destroy small food
            var redSplash = Instantiate(splashRed);
            redSplash.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, other.gameObject.transform.position.z + 7.0f);
            Destroy(redSplash, 5);
        }
        else if (other.gameObject.tag == "BombBigTag")
        {
            // Create explosion after bomb destroy
            var explosion = BombExplosionEffect.Instanse.CreateExplosion();
            explosion.transform.position = new Vector2(other.gameObject.transform.position.x, other.gameObject.transform.position.y);
            Destroy(other.gameObject);
            bombDestroySound.Play();
            if (_heart_1.activeInHierarchy)
            {
                _heart_1.SetActive(false);
            }
            else if (_heart_2.activeInHierarchy)
            {
                _heart_2.SetActive(false);
            }
            else if (_heart_3.activeInHierarchy)
            {
                _heart_3.SetActive(false);
                gameOverScreen.Setup();
            }
            loseHeartSound.Play();
        }
        else if (other.gameObject.tag == "BombNormalTag")
        {
            // Create explosion after bomb destroy
            var explosion = BombExplosionEffect.Instanse.CreateExplosion();
            explosion.transform.position = new Vector2(other.gameObject.transform.position.x, other.gameObject.transform.position.y);
            Destroy(other.gameObject);
            bombDestroySound.Play();
            if (_heart_1.activeInHierarchy)
            {
                _heart_1.SetActive(false);
                _heart_2.SetActive(false);
            }
            else
            {
                _heart_2.SetActive(false);
                _heart_3.SetActive(false);
                gameOverScreen.Setup();
            }
        }
        else if (other.gameObject.tag == "BombSmallTag")
        {
            Destroy(other.gameObject);
            bombDestroySound.Play();
            _heart_1.SetActive(false);
            _heart_2.SetActive(false);
            _heart_3.SetActive(false);
            gameOverScreen.Setup();
        }
        if (_currentSliceAction != null)
        {
            _currentSliceAction.BehaviourAfterSlice(other.gameObject.transform.position);
        }

    }
    private void Update()
    {
        scoreText.text = score.ToString();
        gameoverScoreText.text = "Score: " + score.ToString();
        gameoverHighScoreText.text = "Best: " + PlayerPrefs.GetInt("Best", 0);

        if (score > PlayerPrefs.GetInt("Best", 0))
        {
            PlayerPrefs.SetInt("Best", score);
            highScoreText.text = "Best: " + score.ToString();
            gameoverHighScoreText.text = "Best: " + score.ToString();

        }
    }
}